﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oscillator : MonoBehaviour
{
    public int dataIndex;
    public float currPowerValue;

    private double sampling_frequency;
    private int noteLength;
    private float[] frequencies;
    private AudioSource audioSource;

    private bool isPause = true;
    private bool isRewinding = false;
    private int[] noteList;
    private float[][] audioData;

    void Start()
    {
        sampling_frequency = AudioSettings.outputSampleRate; //48000.0
        noteLength = (int) sampling_frequency / 4;

        audioSource = GetComponent<AudioSource>();

        currPowerValue = 0;

        InitFrequencies();
        GeneAudioData();
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
                        if (currPowerValue > 0 && dataIndex > 0)
                        {
                            dataIndex -= 2;
                            currPowerValue -= 2;
                        }
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
                        if (currPowerValue > 0 && dataIndex > 0)
                        {
                            dataIndex -= 2;
                            currPowerValue -= 2;
                        }
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

    public void Sing()
    {
        isPause = false;
    }

    public float GetProgressRatio()
    {
        return (float) dataIndex / (noteLength * noteList.Length);
    }

    public float GetCurrPowerValue()
    {
        return (float) currPowerValue / (noteLength * noteList.Length);
    }

    public string GetNoteString()
    {
        string res = "";
        foreach (int i in noteList)
        {
            res += i.ToString();
        }
        return res;
    }

    void InitFrequencies()
    {
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

    public void IncPowerValue(int delta)
    {
        currPowerValue += (float) delta * noteLength * noteList.Length;

        if (currPowerValue < 0)
        {
            currPowerValue = 0;
        }
    }

    public void GeneAudioData()
    {
        noteList = GeneNoteList();

        audioData = new float[noteList.Length][];

        for (int i = 0; i < noteList.Length; i++)
        {
            float thisFreq = frequencies[noteList[i]];
            audioData[i] = CreateNoteData(thisFreq);
        }
    }

    public void ResetDataIndex()
    {
        isPause = true;
        dataIndex = 0;
    }

    public void SingNotes(int[] thisNoteList)
    {
        // initialise the samples to be created
        int samplesLength = noteLength * thisNoteList.Length;
        float[] samples = new float[samplesLength];

        // fill the samples with data
        for (int i = 0; i < thisNoteList.Length; i++)
        {
            // create data for this note
            float[] thisNoteData = CreateNoteData(frequencies[thisNoteList[i]]);

            // calculate starting index for this part of samples
            int startIndex = i * noteLength;

            //assign this note data to samples
            for (int j = 0; j < noteLength; j++)
            {
                samples[startIndex + j] = thisNoteData[j];
            }
        }

        // play the created samples
        AudioClip ac = AudioClip.Create("SingAnswer", samplesLength, 1, (int) sampling_frequency, false);
        ac.SetData(samples, 0);
        audioSource.PlayOneShot(ac, 1.0f);
    }
}
