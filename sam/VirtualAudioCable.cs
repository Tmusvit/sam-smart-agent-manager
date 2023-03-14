using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam
{
    internal class VirtualAudioCable
    {
        private WaveInEvent inputDevice;
        private WaveOutEvent outputDevice;

        public VirtualAudioCable(int deviceId)
        {
            
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            
        }

        public void Start()
        {
            inputDevice?.StartRecording();
        }

        public void Stop()
        {
            inputDevice?.StopRecording();
            outputDevice?.Stop();
            outputDevice?.Dispose();
            inputDevice?.Dispose();
        }

    }
}
