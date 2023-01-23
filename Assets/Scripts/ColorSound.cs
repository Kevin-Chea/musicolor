using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors
{
    Red,
    Blue,
    Yellow,
    Green,
    Purple,
    Orange,
    White,
    Black
}

public enum Sound 
{
    C,
    D,
    E,
    F,
    G,
    A,
    B,
    C2
}

public class ColorSound : MonoBehaviour
{
    

    public static Dictionary<Colors, Sound> colorSounds = new Dictionary<Colors, Sound>()
    {
        {Colors.Red, Sound.C},
        {Colors.Blue, Sound.D},
        {Colors.Yellow, Sound.E},
        {Colors.Green, Sound.F},
        {Colors.Purple, Sound.G},
        {Colors.Orange, Sound.A},
        {Colors.White, Sound.B},
        {Colors.Black, Sound.C2}
    };
    // Dictionary to associate color to its RGB values
    public static Dictionary<Colors, Vector3> colorRGB = new Dictionary<Colors, Vector3>()
    {
        {Colors.Red, new Vector3(1, 0, 0)},
        {Colors.Blue, new Vector3(0, 0, 1)},
        {Colors.Yellow, new Vector3(1, 1, 0)},
        {Colors.Green, new Vector3(0, 1, 0)},
        {Colors.Purple, new Vector3(1, 0, 1)},
        {Colors.Orange, new Vector3(1, 0.5f, 0)},
        {Colors.White, new Vector3(1, 1, 1)},
        {Colors.Black, new Vector3(0, 0, 0)}
    };
    // Dictionary to associate a sound to its frequency
    public static Dictionary<Sound, float> soundFrequency = new Dictionary<Sound, float>()
    {
        {Sound.C, 261.63f},
        {Sound.D, 293.66f},
        {Sound.E, 329.63f},
        {Sound.F, 349.23f},
        {Sound.G, 392.00f},
        {Sound.A, 440.00f},
        {Sound.B, 493.88f},
        {Sound.C2, 523.25f}
    };

    public static float GetSoundFrequency(Sound sound)
    {
        return soundFrequency[sound];
    }

    public static float GetSoundFrequencyFromColor(Colors color)
    {
        Sound sound = colorSounds[color];
        return soundFrequency[sound];
    }
}
