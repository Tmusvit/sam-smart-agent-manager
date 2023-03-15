using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam
{
    internal class AudioLoopback
    {
        WaveIn loopbackSourceStream;
        BufferedWaveProvider loopbackWaveProvider;
        WaveOut[] loopbackWaveOut;

        public void StartLoopback(int captureDeviceNumber, int playbackDeviceNumber, int headphonesDeviceNumber)
        {
            if (captureDeviceNumber < 0 || playbackDeviceNumber < 0 || headphonesDeviceNumber < 0)
                throw new ArgumentException("Device number cannot be negative.");

            if (loopbackSourceStream == null)
                loopbackSourceStream = new WaveIn();

            loopbackSourceStream.DeviceNumber = captureDeviceNumber;
            loopbackSourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(captureDeviceNumber).Channels);
            loopbackSourceStream.BufferMilliseconds = 25;
            loopbackSourceStream.NumberOfBuffers = 5;
            loopbackSourceStream.DataAvailable += loopbackSourceStream_DataAvailable;

            loopbackWaveProvider = new BufferedWaveProvider(loopbackSourceStream.WaveFormat);
            loopbackWaveProvider.DiscardOnBufferOverflow = true;

            loopbackWaveOut = new WaveOut[2];

            if (loopbackWaveOut[0] == null)
                loopbackWaveOut[0] = new WaveOut();

            loopbackWaveOut[0].DeviceNumber = playbackDeviceNumber;
            loopbackWaveOut[0].DesiredLatency = 125;
            loopbackWaveOut[0].Init(loopbackWaveProvider);

            if (loopbackWaveOut[1] == null)
                loopbackWaveOut[1] = new WaveOut();

            loopbackWaveOut[1].DeviceNumber = headphonesDeviceNumber;
            loopbackWaveOut[1].DesiredLatency = 125;
            loopbackWaveOut[1].Init(loopbackWaveProvider);

            //set the selected capture device
            loopbackSourceStream.StartRecording();

            //play the recorded audio to the selected playback devices
            using (var devEnum = new MMDeviceEnumerator())
            {
                var dev1 = devEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ElementAtOrDefault(playbackDeviceNumber);
                if (dev1 != null)
                {
                    var volumes1 = dev1.AudioEndpointVolume;
                    volumes1.Mute = false;
                    volumes1.MasterVolumeLevelScalar = 1f;
                }

                var dev2 = devEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ElementAtOrDefault(headphonesDeviceNumber);
                if (dev2 != null)
                {
                    var volumes2 = dev2.AudioEndpointVolume;
                    volumes2.Mute = false;
                    volumes2.MasterVolumeLevelScalar = 1f;
                }
            }

            loopbackWaveOut[0].Play();
            loopbackWaveOut[1].Play();
        }

        public void StopLoopback()
        {
            if (loopbackSourceStream != null)
            {
                loopbackSourceStream.StopRecording();
                loopbackSourceStream.Dispose();
                loopbackSourceStream = null;
            }

            if (loopbackWaveOut != null)
            {
                for (int i = 0; i < loopbackWaveOut.Length; i++)
                {
                    if (loopbackWaveOut[i] != null)
                    {
                        loopbackWaveOut[i].Stop();
                        loopbackWaveOut[i].Dispose();
                        loopbackWaveOut[i] = null;
                    }
                }
            }

            if (loopbackWaveProvider != null)
            {
                loopbackWaveProvider.ClearBuffer();
                loopbackWaveProvider = null;
            }
        }

        private void loopbackSourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (loopbackWaveProvider != null && loopbackWaveProvider.BufferedDuration.TotalMilliseconds <= 100)
                loopbackWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
    }
}
