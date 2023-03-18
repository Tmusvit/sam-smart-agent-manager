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
        

        public void StartLoopback(int playbackDeviceNumber, int captureDeviceNumber)
        {
            if (captureDeviceNumber < 0 || playbackDeviceNumber < 0)
                throw new ArgumentException("Device number cannot be negative.");

            _loopbackSourceStream = new WaveIn();
            _loopbackSourceStream.DeviceNumber = captureDeviceNumber;
            _loopbackSourceStream.WaveFormat = new WaveFormat(41000, WaveIn.GetCapabilities(captureDeviceNumber).Channels);
            _loopbackSourceStream.BufferMilliseconds = 125;
            _loopbackSourceStream.NumberOfBuffers = 5;
            _loopbackSourceStream.DataAvailable += LoopbackSourceStream_DataAvailable;

            _loopbackWaveProvider = new BufferedWaveProvider(_loopbackSourceStream.WaveFormat);
            _loopbackWaveProvider.DiscardOnBufferOverflow = true;

            _playbackWaveOut = new WaveOut();
            _playbackWaveOut.DeviceNumber = playbackDeviceNumber;
            _playbackWaveOut.DesiredLatency = 125;
            _playbackWaveOut.Init(_loopbackWaveProvider);


            _loopbackSourceStream.StartRecording();


            _playbackWaveOut.Play();
            
        }
        private void LoopbackSourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_loopbackWaveProvider != null &&
                _loopbackWaveProvider.BufferedDuration.TotalMilliseconds <= _loopbackSourceStream.BufferMilliseconds * _loopbackSourceStream.NumberOfBuffers)
            {
                _loopbackWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
            }
        }
        public void StopLoopback()
        {
            if (_loopbackSourceStream != null)
            {
                _loopbackSourceStream.StopRecording();
                _loopbackSourceStream.DataAvailable -= LoopbackSourceStream_DataAvailable;
                _loopbackSourceStream.Dispose();
                _loopbackSourceStream = null;
            }

            if (_playbackWaveOut != null)
            {
                _playbackWaveOut.Stop();
                _playbackWaveOut.Dispose();
                _playbackWaveOut = null;
            }



            if (_loopbackWaveProvider != null)
            {
                _loopbackWaveProvider.ClearBuffer();
                _loopbackWaveProvider = null;
            }
        }

        
    }

}
