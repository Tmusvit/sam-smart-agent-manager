using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam
{
    using NAudio.CoreAudioApi;
    using NAudio.Wave;
    using System;
    using System.Linq;

    internal class AudioLoopback
    {
        private WaveIn _loopbackSourceStream;
        private BufferedWaveProvider _loopbackWaveProvider;
        private WaveOut _playbackWaveOut;
        private WaveOut _headphonesWaveOut;

        public void StartLoopback(int captureDeviceNumber, int playbackDeviceNumber, int headphonesDeviceNumber)
        {
            if (captureDeviceNumber < 0 || playbackDeviceNumber < 0 || headphonesDeviceNumber < 0)
                throw new ArgumentException("Device number cannot be negative.");

            _loopbackSourceStream = new WaveIn();
            _loopbackSourceStream.DeviceNumber = captureDeviceNumber;
            _loopbackSourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(captureDeviceNumber).Channels);
            _loopbackSourceStream.BufferMilliseconds = 25;
            _loopbackSourceStream.NumberOfBuffers = 5;
            _loopbackSourceStream.DataAvailable += LoopbackSourceStream_DataAvailable;

            _loopbackWaveProvider = new BufferedWaveProvider(_loopbackSourceStream.WaveFormat);
            _loopbackWaveProvider.DiscardOnBufferOverflow = true;

            _playbackWaveOut = new WaveOut();
            _playbackWaveOut.DeviceNumber = playbackDeviceNumber;
            _playbackWaveOut.DesiredLatency = 125;
            _playbackWaveOut.Init(_loopbackWaveProvider);

            _headphonesWaveOut = new WaveOut();
            _headphonesWaveOut.DeviceNumber = headphonesDeviceNumber;
            _headphonesWaveOut.DesiredLatency = 125;
            _headphonesWaveOut.Init(_loopbackWaveProvider);

            _loopbackSourceStream.StartRecording();

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

            _playbackWaveOut.Play();
            _headphonesWaveOut.Play();
        }

        public void StopLoopback()
        {
            if (_loopbackSourceStream != null)
            {
                _loopbackSourceStream.StopRecording();
                _loopbackSourceStream.Dispose();
                _loopbackSourceStream = null;
            }

            if (_playbackWaveOut != null)
            {
                _playbackWaveOut.Stop();
                _playbackWaveOut.Dispose();
                _playbackWaveOut = null;
            }

            if (_headphonesWaveOut != null)
            {
                _headphonesWaveOut.Stop();
                _headphonesWaveOut.Dispose();
                _headphonesWaveOut = null;
            }

            if (_loopbackWaveProvider != null)
            {
                _loopbackWaveProvider.ClearBuffer();
                _loopbackWaveProvider = null;
            }
        }

        private void LoopbackSourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_loopbackWaveProvider != null &&
                _loopbackWaveProvider.BufferedDuration.TotalMilliseconds <= _loopbackSourceStream.BufferMilliseconds * _loopbackSourceStream.NumberOfBuffers)
            {
                _loopbackWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
            }
        }
    }

}
