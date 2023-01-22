using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Flower : MonoBehaviour
{
    public GameObject[] petals;

    private double frequency = 440.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 44100.0;

    public float gain = 0f;
    public float volume = 0.05f;

    private bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying)
        {
            
            StartCoroutine(PlayMusic());
        }
    }

    IEnumerator PlayMusic()
    {
        isPlaying = true;

        foreach (GameObject petal in petals)
        {
           
            // Get the color of the petal
            Colors color = petal.GetComponent<Petal>().color;
            // Get the sound associated to the color
            frequency = ColorSound.GetSoundFrequencyFromColor(color);
            Debug.Log(frequency);
            gain = volume;
            // Play the sound
            yield return new WaitForSeconds(1);
            gain = 0f;
        }
        isPlaying = false;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;
        Debug.Log("Increment: " + increment);
        for (int i = 0; i < data.Length; i += channels) {
            phase += increment;

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
