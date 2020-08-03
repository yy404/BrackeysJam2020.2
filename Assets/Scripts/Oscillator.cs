using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oscillator : MonoBehaviour
{
    public int dataIndex;

    private double sampling_frequency;
    private int noteLength;
    private float[] frequencies;

    private bool isPause = true;
    private int[] noteList;
    private float[][] audioData;

    void Start()
    {
        Init();

        noteList = new int[] {1,2,3,4,5,6,7};
        audioData = new float[noteList.Length][];

        for (int i = 0; i < noteList.Length; i++)
        {
            float thisFreq = frequencies[noteList[i]];
            audioData[i] = CreateNoteData(thisFreq);
        }
    }

    void Update()
    {

    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if(!isPause)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                if (dataIndex < 0)
                {
                    dataIndex = 0;
                }
                if (dataIndex < noteLength * noteList.Length)
                {
                    data[i] = audioData[dataIndex/noteLength][dataIndex%noteLength];
                    dataIndex += 1;
                    if (channels == 2)
                    {
                        data[i+1] = data[i];
                    }
                }
            }
        }
    }

    float[] CreateNoteData(float frequency)
    {
        float[] thisNoteData = new float[noteLength];

        double phase;
        double increment;

        phase = 0;
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;
        for (int i = 0; i < noteLength; i ++)
        {
            phase += increment;

            // Sinus Wave
            thisNoteData[i] = (float) (Mathf.Sin((float)phase));

            if (phase > (Mathf.PI * 2))
            {
                phase -= Mathf.PI * 2;
            }
        }

        return thisNoteData;
    }

    public void Rewind()
    {
        dataIndex -= (int) sampling_frequency;
    }

    public void Pause()
    {
        isPause = !isPause;
    }

    public float GetProgressRatio()
    {
        return (float) dataIndex / (noteLength * noteList.Length);
    }

    void Init()
    {
        sampling_frequency = AudioSettings.outputSampleRate; //48000.0
        noteLength = (int) sampling_frequency / 4;

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
}
