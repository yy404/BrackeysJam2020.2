﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Slider monsterSlider;
    public Slider heroSlider;
    public InputField inputField;
    public Text powerPoints;
    public int noteListLen;
    public int hintDigits;

    private Oscillator oscillator;
    public string noteListString;

    // Start is called before the first frame update
    void Start()
    {
        oscillator = FindObjectOfType<Oscillator>();
        noteListString = oscillator.GetNoteString();

        if (hintDigits < noteListLen)
        {
            string temp = "";
            temp = noteListString.Substring(0, hintDigits);
            for (int i = hintDigits; i < noteListLen; i++)
            {
                temp += "?";
            }
            inputField.placeholder.GetComponent<Text>().text = temp;
        }
        else
        {
            inputField.placeholder.GetComponent<Text>().text = noteListString;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterSlider != null)
        {
            monsterSlider.value = oscillator.GetProgressRatio();
        }
        if (heroSlider != null)
        {
            float decimalPart = oscillator.GetCurrPowerValue() % 1;
            heroSlider.value = decimalPart;

            int intPart = (int) (oscillator.GetCurrPowerValue() - decimalPart);
            powerPoints.text = "x" + intPart.ToString();
        }
    }

    public void CheckInput()
    {
        if (inputField.text == noteListString)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
}
