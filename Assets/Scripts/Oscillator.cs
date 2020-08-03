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

    private bool isPause = false;
    private int[] noteList;
    private float[][] audioData;

    void Start()
    {
        Init();

        noteList = new int[] {0,1,2,3,4,5,6,7};
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

    void Init()
    {
        sampling_frequency = AudioSettings.outputSampleRate; //48000.0
        noteLength = (int) sampling_frequency / 4;

        frequencies = new float[8];
        frequencies[0] = 440;
        frequencies[1] = 494;
        frequencies[2] = 554;
        frequencies[3] = 587;
        frequencies[4] = 659;
        frequencies[5] = 740;
        frequencies[6] = 831;
        frequencies[7] = 880;
    }
}
