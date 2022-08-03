using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Autoclicker.clicker;
using Autoclicker.mouse_control;
using Random = Autoclicker.random_generator.Random;

namespace Autoclicker.sound;

public class ShuffleSounds
{
    private readonly MouseControl _mouseControl;
    private readonly SoundData _soundData;
    
    /* The short answer is that you can't do it with SoundPlayer alone.
     You'll need the use of a couple apis from the winmm.dll library. */
    
    [DllImport("winmm.dll", EntryPoint = "waveOutGetVolume")]
    public static extern int WaveOutGetVolume(IntPtr hwo, out uint dwVolume);

    [DllImport("winmm.dll", EntryPoint="waveOutSetVolume")]
    public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);
    
    public ShuffleSounds(MouseControl mouseControl, SoundData soundData)
    {
        _mouseControl = mouseControl;
        _soundData = soundData;
    }

    public async void RightClickerShuffleThread(object o)
    {
        _soundData.RightClickerCanStartNewSound = false;
        await ShuffleSoundsIterative(SoundData.SongsData.NumberSounds - 1,  SoundData.SongsData.StreamsPlayed, SoundData.SongsData.Streams, SoundData.SongsData.SoundsLength, Constants.ClickerType.RightClicker);
        _soundData.RightClickerCanStartNewSound = true;
        _soundData.RightClickerThreadStarted = false;
    }
    
    public async void LeftClickerShuffleThread(object o)
    {
        _soundData.LeftClickerCanStartNewSound = false;
        await ShuffleSoundsIterative(SoundData.SongsData.NumberSounds - 1,  SoundData.SongsData.StreamsPlayed, SoundData.SongsData.Streams, SoundData.SongsData.SoundsLength, Constants.ClickerType.LeftClicker);
        _soundData.LeftClickerCanStartNewSound = true;
        _soundData.LeftClickerThreadStarted = false;
    }

    private async Task ShuffleSoundsIterative(int numberSamples, int[] arrVisited, Stream[] arrStream, int[] arrDelay, Constants.ClickerType clickerType)
    {
        int pos = 0;

        bool threadStarted = false;
        
        while (true) // pos <= numberSamples && threadStarted
        {
            if (clickerType == Constants.ClickerType.RightClicker)
                threadStarted = _soundData.RightClickerThreadStarted;
            else if (clickerType == Constants.ClickerType.LeftClicker)
                threadStarted = _soundData.LeftClickerThreadStarted;
            
            if (pos > numberSamples || threadStarted == false) break;
            
            int soundSelected = Random.NextIntLinear(0, numberSamples + 1);
            
            if (is_valid(soundSelected, numberSamples, arrVisited))
            {
                /* Add the selected sound to the visited array so that it is no longer considered in subsequent iterations */
                arrVisited[pos] = soundSelected;
                
                /* Get the sound to play */
                Stream stream = arrStream[soundSelected];
                
                /* Get the sound's delay */
                int delay = arrDelay[soundSelected];
                
                /* Play sound */
                WaveOutSetVolume(IntPtr.Zero, uint.MaxValue);
                FadeOutSound.TotalElapsedTime = 0f;
                await PlaySound(stream, delay);
                
                /* Progress towards completion */
                pos++;
            }
        }
    }

    public async Task ShuffleSoundsRecursive(int pos, int numberSamples, int[] arrVisited, Stream[] arrStream, int[] arrDelay)
    {
        if (pos == numberSamples + 1)
        {
            _soundData.RightClickerCanStartNewSound = true;
            return;
        }

        _soundData.RightClickerCanStartNewSound = false;
        //int soundSelected = Random.NextIntLinear(0, numberSamples + 1);
        System.Random rnd = new System.Random();
        int soundSelected = rnd.Next(0, numberSamples + 1);
            
        if (is_valid(soundSelected, numberSamples, arrVisited))
        {
            arrVisited[pos] = soundSelected;
            Stream stream = arrStream[soundSelected];
            int delay = arrDelay[soundSelected];
                
            // TODO: Play sound
            WaveOutSetVolume(IntPtr.Zero, uint.MaxValue);
            FadeOutSound.TotalElapsedTime = 0f;
            await PlaySound(stream, delay);
            
            await ShuffleSoundsRecursive(pos + 1, numberSamples, arrVisited, arrStream, arrDelay);
        }
        else await ShuffleSoundsRecursive(pos, numberSamples, arrVisited, arrStream, arrDelay);
    }

    public async Task PlaySound(Stream stream, int delay)
    {
        stream.Position = 0;
        _mouseControl.SoundPlayer.Stream = Stream.Null;
        _mouseControl.SoundPlayer.Stream = stream;
        _mouseControl.SoundPlayer.Play();
            
        await Task.Delay(delay);
    }
    
    private bool is_valid(int soundSelected, int numberSamples, int[] arrVisited)
    {
        bool isValid = true;
            
        for (int j = 0; j <= numberSamples; j++)
        {
            if (arrVisited[j] == soundSelected)
            {
                isValid = false;
                break;
            }
        }

        return isValid;
    }
}