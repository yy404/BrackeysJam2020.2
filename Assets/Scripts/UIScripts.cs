using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Slider slider;
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
}
