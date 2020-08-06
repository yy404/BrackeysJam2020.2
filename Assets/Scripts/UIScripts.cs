﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Slider monsterSlider;
    public Slider heroSlider;
    public InputField inputField;
    public Toggle toggle;
    public Text powerPoints;
    public GameObject title;
    public GameObject panel;
    public GameObject endPanel;
    public Text endPanelText;
    public int noteListLen;

    private Oscillator oscillator;
    private GameplayManager gameplayManager;
    public string noteListString;
    private int hintDigitsNum;

    // Start is called before the first frame update
    void Start()
    {
        oscillator = FindObjectOfType<Oscillator>();
        gameplayManager = FindObjectOfType<GameplayManager>();
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
            int incPowerNum = 5;
            endPanelText.text = "Your Answer: " + inputField.text;
            endPanelText.text += "\n" + "Correct!";
            oscillator.IncPowerValue(incPowerNum);
            bool hasNextLevel = gameplayManager.EnableNextLevel();
            if (hasNextLevel)
            {
                endPanelText.text += "\n" + "Win Power Pack " + "x" + incPowerNum.ToString();
            }
            else
            {
                endPanelText.text += "\n" + "Win All Levels!!!";
            }
        }
        else
        {
            endPanelText.text = "Your Answer: " + inputField.text;
            endPanelText.text += "\n" + "Wrong!";
            endPanelText.text += "\n" + "Correct Answer: " + noteListString;
            // endPanelText.text += "\n" + "Lose 1 Power Pack!";
            // oscillator.IncPowerValue(-1);
        }
        endPanel.SetActive(true);
    }

    public void ReturnMenuScene()
    {
        panel.SetActive(false);
        endPanel.SetActive(false);
        title.SetActive(true);
        inputField.text = "";
        if (toggle != null)
        {
            toggle.isOn = false;
        }
    }

    public void LeaveMenuScene()
    {
        panel.SetActive(true);
        title.SetActive(false);
    }

    public void UpdateNoteListString(int hintDigits)
    {
        noteListString = oscillator.GetNoteString();

        hintDigitsNum = hintDigits;

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

    public void FillHints()
    {
        inputField.text = noteListString.Substring(0, hintDigitsNum);
    }

    public void SingAnswer()
    {
        if (inputField.text.Length > 0)
        {
            char[] charArray = inputField.text.ToCharArray();
            int[] intArray = new int[charArray.Length];

            // convert the answer to int array
            for (int i = 0; i < charArray.Length; i++)
            {
                int bar;
                if (int.TryParse(charArray[i].ToString(), out bar))
                {
                    intArray[i] = bar;
                }
            }

            oscillator.SingNotes(intArray);
        }
    }
}
