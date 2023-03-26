using System;
using System.IO;
using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.CoreAudioApi;
using NAudio.Wave;

public class NAudioStream : PullAudioInputStreamCallback
{
    private MemoryStream memoryStream;
    private ManualResetEvent newData;

    public NAudioStream(WaveFileWriter waveFileWriter)
    {
        
        this.memoryStream = new MemoryStream();
        this.newData = new ManualResetEvent(false);
    }

    public void Write(byte[] buffer, int offset, int count)
    {
        // Write data to the memory stream and set the reset event
         memoryStream.Write(buffer, offset, count);
         newData.Set();

    }

    public void Close()
    {
        newData.Set();
    }

    private int bytesCounter = 0;

    public override int Read(byte[] dataBuffer, uint size)
    {

        if (memoryStream == null)
        {
            return 0;
        }

        int bytesRead = 0;

        while (bytesRead < size)
        {
            newData.WaitOne(); // Block until there are bytes to read

            byte[] wavBuffer = memoryStream.ToArray();
            int bytesToRead = (int)(size - bytesRead);

            if (bytesToRead > wavBuffer.Length - bytesCounter)
            {
                bytesToRead = wavBuffer.Length - bytesCounter;
            }

            if (bytesToRead > 0)
            {
                Array.Copy(wavBuffer, bytesCounter, dataBuffer, bytesRead, bytesToRead);
                bytesRead += bytesToRead;
                bytesCounter += bytesToRead;
            }
            newData.Reset();
        }

        return (int)bytesRead;


    }

}
