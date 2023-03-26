using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam.audio
{
    using Microsoft.CognitiveServices.Speech.Audio;
    using NAudio.CoreAudioApi;
    using NAudio.Wave;
    using System.IO;

    public class AudioOutputPullStream : PullAudioInputStreamCallback
    {
        private readonly int sampleRate;
        private readonly int channels;
        private readonly MMDevice sourceDevice;
        private readonly MemoryStream audioStream = new MemoryStream();

        public AudioOutputPullStream(MMDevice sourceDevice)
        {
            this.sourceDevice = sourceDevice;
            sampleRate = sourceDevice.AudioClient.MixFormat.SampleRate;
            channels = sourceDevice.AudioClient.MixFormat.Channels;

            var computerAudioCapture = new WasapiLoopbackCapture(sourceDevice);
            computerAudioCapture.DataAvailable += OnDataAvailable;
            computerAudioCapture.StartRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (audioStream.CanWrite)
            {
                if (e.BytesRecorded > 0)
                {
                    audioStream.Write(e.Buffer, 0, e.BytesRecorded);
                }
            }
        }

        public override int Read(byte[] dataBuffer, uint size)
        {
            // Wait until there is data available to read
            while (audioStream.Position == 0)
            {
                Thread.Sleep(10);
            }

            // Only return data if there is data available to read
            var bytesRead = 0;
            while (bytesRead == 0)
            {
                bytesRead = audioStream.Read(dataBuffer, 0, (int)size);
                // Wait for more data to become available

            }
            return bytesRead;

        }

        public override void Close()
        {
            // audioStream.Dispose();
        }
    }

}
