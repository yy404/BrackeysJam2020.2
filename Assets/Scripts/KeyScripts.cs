using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScripts : MonoBehaviour
{
    public int keyValue;
    private Button button;
    private KeyOscillator keyOscillator;
    private InputField inputField;
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        keyOscillator = FindObjectOfType<KeyOscillator>();
        inputField = FindObjectOfType<InputField>();
        toggle = FindObjectOfType<Toggle>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //
    // }

    public void PlayKey()
    {
        keyOscillator.PlayKey(keyValue);
        if (toggle.isOn)
        {
            inputField.text += keyValue.ToString();
        }
    }

    public void StopKey()
    {
        keyOscillator.Stop();
    }
}
