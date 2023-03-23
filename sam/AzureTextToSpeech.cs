using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace sam
{
    internal class AzureTextToSpeech
    {
        private readonly string speechKey;
        private readonly string speechRegion;
        private readonly string voiceName;

        public AzureTextToSpeech(string speechKey, string speechRegion, string voiceName)
        {
            this.speechKey = speechKey;
            this.speechRegion = speechRegion;
            this.voiceName = voiceName;
        }

        public async Task<SpeechSynthesisResult> SynthesizeAsync(string text)
        {
            try
            {
                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
                
                speechConfig.SpeechSynthesisVoiceName = voiceName;

                using (var synthesizer = new SpeechSynthesizer(speechConfig))
                {
                    return await synthesizer.SpeakTextAsync(text);
                }
            }
            catch (Exception ex)
            {
                // handle the exception
                Console.WriteLine($"Error in SynthesizeAsync: {ex.Message}");
                return null; // or throw a custom exception
            }
        }

        public async Task<SpeechRecognitionResult> FromMicAsync()
        {
            try
            {
                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
                speechConfig.SpeechRecognitionLanguage = SamUserSettings.Default.AZURE_STT_LANG;
                using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
                using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);


                return await speechRecognizer.RecognizeOnceAsync();
            }
            catch (Exception ex)
            {
                // handle the exception
                Console.WriteLine($"Error in FromMicAsync: {ex.Message}");
                return null; // or throw a custom exception
            }
        }



        public async Task<SpeechRecognitionResult> FromDefaultSpeaker(MMDevice sourceDevice)
        {
            try
            {
                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
                speechConfig.SpeechRecognitionLanguage = SamUserSettings.Default.AZURE_STT_LANG;

                // Create an AudioInputStream that reads audio from the default speaker output
                var oStream = new AudioOutputPullStream(sourceDevice);


                using var audioInputStream = AudioInputStream.CreatePullStream(oStream);
                using var audioConfig = AudioConfig.FromStreamInput(audioInputStream);
                using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

                // Wait for the recognizer to finish recognizing speech
                var result = await speechRecognizer.RecognizeOnceAsync();
                oStream.Close();
                return result;
            }
            catch (Exception ex)
            {
                // handle the exception
                Console.WriteLine($"Error in FromSpeakerAsync: {ex.Message}");
                return null; // or throw a custom exception
            }

        }

        public async Task<string> FromCompAsync(string wavfile)
        {
            try
            {
                // <recognitionContinuousWithFile>
                // Creates an instance of a speech config with specified subscription key and service region.
                // Replace with your own subscription key and service region (e.g., "westus").
                var config = SpeechConfig.FromSubscription(speechKey, speechRegion);
                config.SpeechRecognitionLanguage = SamUserSettings.Default.AZURE_STT_LANG;
                var stopRecognition = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                string recognizedText = "";

                // Creates a speech recognizer using file as audio input.
                // Replace with your own audio file name.
                using (var audioInput = AudioConfig.FromWavFileInput(wavfile))
                {
                    using (var recognizer = new SpeechRecognizer(config, audioInput))
                    {
                        
                        recognizer.Recognized += (s, e) =>
                        {
                            if (e.Result.Reason == ResultReason.RecognizedSpeech)
                            {
                                Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                                if (e.Result.Text != "")
                                {
                                    recognizedText = e.Result.Text;
                                }                                
                            }
                            else if (e.Result.Reason == ResultReason.NoMatch)
                            {
                                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                            }
                        };

                        recognizer.Canceled += (s, e) =>
                        {
                            Console.WriteLine($"CANCELED: Reason={e.Reason}");

                            if (e.Reason == CancellationReason.Error)
                            {
                                Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                                Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                                Console.WriteLine($"CANCELED: Did you update the subscription info?");
                            }

                            stopRecognition.TrySetResult(0);
                        };

                        recognizer.SessionStarted += (s, e) =>
                        {
                            Console.WriteLine("\n    Session started event.");
                        };

                        recognizer.SessionStopped += (s, e) =>
                        {
                            Console.WriteLine("\n    Session stopped event.");
                            Console.WriteLine("\nStop recognition.");
                            stopRecognition.TrySetResult(0);
                        };

                        // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
                        await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                        // Waits for completion.
                        // Use Task.WaitAny to keep the task rooted.
                        Task.WaitAny(new[] { stopRecognition.Task });

                        // Stops recognition.
                        await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
                    }
                }

                return recognizedText.Trim(); // Return the recognized text as a string, removing any leading or trailing whitespace characters
            }
            catch (Exception ex)
            {
                // Handle the exception and attempt speech recognition again if error is SPXERR_UNEXPECTED_EOF
                if (ex.Message == "Exception with an error code: 0x9 (SPXERR_UNEXPECTED_EOF)") // SPXERR_UNEXPECTED_EOF error code
                {
                    Console.WriteLine("Unexpected EOF error. Retrying...");
                    return await FromCompAsync(wavfile);
                }
                else
                {
                    Console.WriteLine($"Error in FromCompAsync: {ex.Message}");
                    return null; // or throw a custom exception
                }

            }
        }
    }
}


