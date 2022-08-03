using System;
using Autoclicker.clicker;
using Autoclicker.mouse_control;

namespace Autoclicker.sound;

public class FadeOutSound
{
    private readonly MouseControl _mouseControl;
    private readonly SoundData _soundData;
    
    /* Source: https://stackoverflow.com/questions/34277066/how-do-i-fade-out-the-audio-of-a-wav-file-using-soundplayer-instead-of-stopping */
    
    // A crude delta time field
    public static float TotalElapsedTime;
    
    // Tweak this value to determine how quickly you want the fade to happen
    private const float Velocity = 0.005f;
    
    
    public FadeOutSound(MouseControl mouseControl, SoundData soundData)
    {
        _mouseControl = mouseControl;
        _soundData = soundData;
    }
    
    public void SoundFadeOut_Tick(object sender, EventArgs e)
    {
        // Amount to interpolate (value between 0 and 1 inclusive)
        float amount = Math.Min(1f, TotalElapsedTime * Velocity);

        // The new channel volume after a lerp
        float lerped = Lerp(ushort.MaxValue, 0, amount);

        // each channel's volume is actually represented as a ushort
        ushort channelVolume = (ushort)lerped;

        // the new volume for all the channels
        uint volume = channelVolume | ((uint)channelVolume << 16);

        // sets the volume 
        ShuffleSounds.WaveOutSetVolume(IntPtr.Zero, volume);

        // checks if the interpolation is finished
        if (amount >= 1f)
        {
            // stop the timer 
            _mouseControl.FadeOutTimer.Stop();

            // stop the player
            _mouseControl.SoundPlayer.Stop();
                
            // stop the Sounds thread
            _soundData.MakeSoundsThread.Abort();
            
            // Restart flags
            if (SoundData.SongsData.ClickerType == Constants.ClickerType.RightClicker)
            {
                _soundData.RightClickerCanStartNewSound = true;
                _soundData.RightClickerThreadStarted = false;
            }
            else if (SoundData.SongsData.ClickerType == Constants.ClickerType.LeftClicker)
            {
                _soundData.LeftClickerCanStartNewSound = true;
                _soundData.LeftClickerThreadStarted = false;
            }
        }

        // add the elapsed milliseconds (very crude delta time)
        TotalElapsedTime += 100;
    }

    private static float Lerp(float value1, float value2, float amount)
    {
        // does a linear interpolation
        return (value1 + ((value2 - value1) * amount));
    }
}