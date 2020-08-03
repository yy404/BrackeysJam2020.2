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
    private bool isRewinding = false;
    private int[] noteList;
    private float[][] audioData;

    void Awake()
    {
        noteList = GeneNoteList();
    }

    void Start()
    {
        Init();

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
                else if (dataIndex < noteLength * noteList.Length)
                {
                    data[i] = audioData[dataIndex/noteLength][dataIndex%noteLength];

                    if (channels == 2)
                    {
                        data[i+1] = data[i];
                    }

                    if (isRewinding)
                    {
                        dataIndex -= 1;
                    }
                    else
                    {
                        dataIndex += 1;
                    }
                }
                else
                {
                    if (isRewinding)
                    {
                        if (dataIndex > noteLength * noteList.Length)
                        {
                            dataIndex = noteLength * noteList.Length;
                        }
                        dataIndex -= 1;
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

    public void SetRewind()
    {
        isRewinding = true;
        isPause = false;
    }

    public void ResetRewind()
    {
        isRewinding = false;
        isPause = true;
    }

    public void Pause()
    {
        isPause = !isPause;
    }

    public float GetProgressRatio()
    {
        return (float) dataIndex / (noteLength * noteList.Length);
    }

    public string GetNoteString()
    {
        string res = "";
        foreach (int i in noteList)
        {
            res = i.ToString() + res;
        }
        return res;
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

    int[] GeneNoteList()
    {
        int[] notelist = new int[] {1,2,3,4,5,6,7};
        for (int i = 0; i < notelist.Length-1; i++)
        {
            int rnd = Random.Range(i, notelist.Length);
            int temp = notelist[rnd];
            notelist[rnd] = notelist[i];
            notelist[i] = temp;
        }
        return notelist;
    }
}
