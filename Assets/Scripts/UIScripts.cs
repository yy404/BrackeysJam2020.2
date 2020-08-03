using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Slider slider;
    public InputField inputField;
    private Oscillator oscillator;

    // Start is called before the first frame update
    void Start()
    {
        oscillator = FindObjectOfType<Oscillator>();
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
        if (inputField.text == oscillator.GetNoteString())
        {
            Debug.Log("Win");
        }
    }
}
