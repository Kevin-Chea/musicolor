using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public double frequency = 440.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 44000.0;

    public float gain;
    public float volume = 0.05f;

    public float[] frequencies;
    private int thisFrequency = 0;

    private void Start() {
        frequencies = new float[8];
        frequencies[0] = 261.63f;
        frequencies[1] = 293.66f;
        frequencies[2] = 329.63f;
        frequencies[3] = 349.23f;
        frequencies[4] = 392.00f;
        frequencies[5] = 440.00f;
        frequencies[6] = 493.88f;
        frequencies[7] = 523.25f;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            gain = volume;
            frequency = frequencies[thisFrequency];
            thisFrequency++;
            if (thisFrequency >= frequencies.Length) {
                thisFrequency = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            gain = 0.0f;
        }
    }

    private void OnAudioFilterRead(float[] data, int channels) {
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;
        for (int i = 0; i < data.Length; i += channels) {
            phase += increment;
            // this is where we copy audio data to make them “available” to Unity
            // data[i] = (float)(gain * Mathf.Sin((float)phase));

            // Square wave
            if (phase < Mathf.PI) {
                data[i] = (float)(gain * 1.0);
            } else {
                data[i] = (float)(gain * -1.0);
            }

            // if we have stereo, we copy the mono data to each channel
            if (channels == 2) data[i + 1] = data[i];
            if (phase > (Mathf.PI * 2)) phase = 0.0;
        }
        
    }
}
