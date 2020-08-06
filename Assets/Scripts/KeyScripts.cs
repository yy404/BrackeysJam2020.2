using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyScripts : MonoBehaviour, IPointerClickHandler
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

    // check which mouse button clicked
    // Enabling right-click input
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Debug.Log("Left click");
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            // Debug.Log("Middle click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Debug.Log("Right click");
            inputField.text += keyValue.ToString();
        }
    }
}
