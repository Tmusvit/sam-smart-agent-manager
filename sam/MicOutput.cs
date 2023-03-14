using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace sam
{
    internal class MicOutput
    {
       
        private List<WaveInEvent> micCaptures = new List<WaveInEvent>();
        private List<WaveFileWriter> micWriters = new List<WaveFileWriter>();
        public WaveFileWriter computerAudioWriter { get; private set; }
        public WasapiLoopbackCapture computerAudioCapture { get; private set; }

      

        public void PlayFromFile(string filePath)
        {
            
        }

        public void StartRecording()
        {
            // Create the directory for recordings if it does not exist
            Directory.CreateDirectory(@"rec");

            // Set up recording device for computer audio
            string computerAudioFilename = string.Format(@"rec\recording-{0:yyyy-MM-dd-HH-mm-ss}-computerAudio.wav", DateTime.Now);
            computerAudioCapture = new WasapiLoopbackCapture();
            computerAudioCapture.DataAvailable += (sender, e) =>
            {
                // Write data to computer audio WAV file
                computerAudioWriter.Write(e.Buffer, 0, e.BytesRecorded);
            };
            computerAudioWriter = new WaveFileWriter(computerAudioFilename, computerAudioCapture.WaveFormat);

            // Set up recording device for mic audio
            for (int n = 0; n < WaveInEvent.DeviceCount; n++)
            {
                var capabilities = WaveInEvent.GetCapabilities(n);
                if (capabilities.ProductName.Contains("Microphone"))
                {
                    string micFilename = string.Format(@"rec\recording-{0:yyyy-MM-dd-HH-mm-ss}-{1}.wav", DateTime.Now, capabilities.ProductName);
                    var micCapture = new WaveInEvent();
                    micCapture.DeviceNumber = n;
                    var micWriterLocal = new WaveFileWriter(micFilename, micCapture.WaveFormat);
                    micCapture.DataAvailable += (sender, e) =>
                    {
                        // Write data to mic audio WAV file
                        micWriterLocal.Write(e.Buffer, 0, e.BytesRecorded);
                    };
                    micCaptures.Add(micCapture);
                    micWriters.Add(micWriterLocal);
                    micCapture.StartRecording();
                }
            }

            // Start recording
            computerAudioCapture.StartRecording();
        }
        public void StopRecording()
        {
            // Stop recording from the computer audio device
            computerAudioCapture.StopRecording();
            computerAudioWriter.Dispose();
            computerAudioCapture.Dispose();

            // Stop recording from the mic audio device(s)
            foreach (var micCapture in micCaptures)
            {
                micCapture.StopRecording();
                micCapture.Dispose();
            }
            // Stop recording from the mic audio device(s)
            foreach (var micCapture in micWriters)
            {
                micCapture.Dispose();
            }

            // Clear the list of mic captures
            micCaptures.Clear();
            micWriters.Clear();
        }
    }
}
