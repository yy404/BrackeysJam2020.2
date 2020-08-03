using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOscillator : MonoBehaviour
{
    public float frequency;

    private double sampling_frequency;
    private float[] frequencies;
    private bool isPause = true;
    private double phase = 0;
    private double increment = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //
    // }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if(!isPause)
        {
            // phase = 0;
            increment = frequency * 2.0 * Mathf.PI / sampling_frequency;
            for (int i = 0; i < data.Length; i += channels)
            {
                phase += increment;

                // Sinus Wave
                data[i] = (float) (Mathf.Sin((float)phase));

                if (phase > (Mathf.PI * 2))
                {
                    phase -= Mathf.PI * 2;
                }

                if (channels == 2)
                {
                    data[i+1] = data[i];
                }
            }
        }
    }

    void Init()
    {
        sampling_frequency = AudioSettings.outputSampleRate; //48000.0

        frequencies = new float[8];
        frequencies[0] = 0;
        frequencies[1] = 261.63f;
        frequencies[2] = 293.66f;
        frequencies[3] = 329.63f;
        frequencies[4] = 349.23f;
        frequencies[5] = 392.00f;
        frequencies[6] = 440.00f;
        frequencies[7] = 493.88f;
    }

    public void PlayKey(int keyValue)
    {
        Debug.Log(keyValue);
        frequency = frequencies[keyValue];
        isPause = false;
    }

    public void Stop()
    {
        isPause = true;
    }
}
