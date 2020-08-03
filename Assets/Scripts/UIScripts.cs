using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScripts : MonoBehaviour
{
    private Oscillator oscillator;
    // Start is called before the first frame update
    void Start()
    {
        oscillator = FindObjectOfType<Oscillator>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //
    // }

    public void Rewind()
    {
        oscillator.Rewind();
    }

    public void Pause()
    {
        oscillator.Pause();
    }
}
