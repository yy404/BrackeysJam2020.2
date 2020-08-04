using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Slider slider;
    public InputField inputField;
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
        if (slider != null)
        {
            slider.value = oscillator.GetProgressRatio();
        }
    }

    public void CheckInput()
    {
        if (inputField.text == noteListString)
        {
            Debug.Log("Win");
        }
    }
}
