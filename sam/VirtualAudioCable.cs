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
            var inputFormat = new WaveFormat(44100, 16, 2);
            inputDevice = new WaveInEvent();
            inputDevice.DeviceNumber = deviceId;
            inputDevice.WaveFormat = inputFormat;
            inputDevice.DataAvailable += OnDataAvailable;

            var outputFormat = new WaveFormat(44100, 16, 2);
            outputDevice = new WaveOutEvent();
            outputDevice.DeviceNumber = deviceId;
            outputDevice.DesiredLatency = 100;
            outputDevice.Init(new IWaveProvider(outputFormat));
            outputDevice.Play();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            outputDevice?.Write(e.Buffer, 0, e.BytesRecorded);
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
