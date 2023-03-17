﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
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




        public async Task<SpeechRecognitionResult> FromSpeakerAsync(string audiofile)
        {
            try
            {
                var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
                speechConfig.SpeechRecognitionLanguage = SamUserSettings.Default.AZURE_STT_LANG;
                using var audioConfig = AudioConfig.FromWavFileInput(audiofile);
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
    }

}
