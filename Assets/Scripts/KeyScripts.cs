using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScripts : MonoBehaviour
{
    public int keyValue;
    private Button button;
    private KeyOscillator keyOscillator;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        keyOscillator = FindObjectOfType<KeyOscillator>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //
    // }

    public void PlayKey()
    {
        keyOscillator.PlayKey(keyValue);
    }

    public void StopKey()
    {
        keyOscillator.Stop();
    }
}
