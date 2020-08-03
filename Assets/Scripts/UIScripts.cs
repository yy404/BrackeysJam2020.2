using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Slider slider;
    public InputField inputField;
    public int hintDigits;

    private Oscillator oscillator;
    public string noteListString;

    // Start is called before the first frame update
    void Start()
    {
        oscillator = FindObjectOfType<Oscillator>();
        noteListString = oscillator.GetNoteString();
        inputField.text = noteListString.Substring(0, hintDigits);
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
