using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Threading.Channels;

namespace sam
{
    public class SpeechRecognitionService
    {
        private readonly string speechKey;
        private readonly string speechRegion;
        private readonly NAudioStream wavFile;

        public WaveFormat waveFormat { get; private set; }

        private SpeechRecognizer recognizer;
        private TaskCompletionSource<int> stopRecognition;
        private AudioConfig audioInput;

        public SpeechRecognitionService(string speechKey, string speechRegion, NAudioStream wavFile, WaveFormat waveFormat)
        {
            this.speechKey = speechKey;
            this.speechRegion = speechRegion;
            this.wavFile = wavFile;
            this.waveFormat = waveFormat;
        }

        public event Action<string> TextRecognized;

        private void Recognizer_Recognized(object sender, SpeechRecognitionEventArgs e)
        {
            if (e.Result.Reason == ResultReason.RecognizedSpeech)
            {
                Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                if (e.Result.Text != "")
                {
                    TextRecognized?.Invoke(e.Result.Text);
                }
            }
            else if (e.Result.Reason == ResultReason.NoMatch)
            {
                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
            }
        }

        private void Recognizer_Canceled(object sender, SpeechRecognitionCanceledEventArgs e)
        {
            Console.WriteLine($"CANCELED: Reason={e.Reason}");

            if (e.Reason == CancellationReason.Error)
            {
                Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                Console.WriteLine($"CANCELED: Did you update the subscription info?");
            }
        }

        private void Recognizer_SessionStarted(object sender, SessionEventArgs e)
        {
            Console.WriteLine("\n    Session started event.");
        }

        private void Recognizer_SessionStopped(object sender, SessionEventArgs e)
        {
            Console.WriteLine("\n    Session stopped event.");
            Console.WriteLine("\nStop recognition.");
        }
        public async Task StopRecognizeAsync()
        {
            recognizer.StopContinuousRecognitionAsync();
        }

        public async Task RecognizeAsync()
        {
            try
            {
                var config = SpeechConfig.FromSubscription(speechKey, speechRegion);
                config.SpeechRecognitionLanguage = SamUserSettings.Default.AZURE_STT_LANG;
                
                var audioFormat = AudioStreamFormat.GetWaveFormatPCM((uint)waveFormat.SampleRate, (byte)waveFormat.BitsPerSample, (byte)waveFormat.Channels);

                audioInput = AudioConfig.FromStreamInput(wavFile, audioFormat);
                
                recognizer = new SpeechRecognizer(config, audioInput);

                recognizer.Recognized += Recognizer_Recognized;
                recognizer.Canceled += Recognizer_Canceled;
                recognizer.SessionStarted += Recognizer_SessionStarted;
                recognizer.SessionStopped += Recognizer_SessionStopped;
                recognizer.Recognizing += Recognizer_Recognizing;

                recognizer.StartContinuousRecognitionAsync();
                

            }
            catch (Exception ex)
            {
                // Handle the exception and attempt speech recognition again if error is SPXERR_UNEXPECTED_EOF
                if (ex.Message == "Exception with an error code: 0x9 (SPXERR_UNEXPECTED_EOF)") // SPXERR_UNEXPECTED_EOF error code
                {
                    Console.WriteLine("Unexpected EOF error. Retrying...");
                    if (recognizer != null) { recognizer.StopContinuousRecognitionAsync(); }
                    await RecognizeAsync();
                }
                else
                {
                    Console.WriteLine($"Error in RecognizeAsync: {ex.Message}");
                }
            }
        }

        private void Recognizer_Recognizing(object? sender, SpeechRecognitionEventArgs e)
        {
            if (e.Result.Reason == ResultReason.RecognizedSpeech)
            {
                Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                if (e.Result.Text != "")
                {
                    TextRecognized?.Invoke(e.Result.Text);
                }
            }
            else if (e.Result.Reason == ResultReason.NoMatch)
            {
                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
            }
        }
    }

}
