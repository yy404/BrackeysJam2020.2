using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClearButtonScripts : MonoBehaviour, IPointerClickHandler
{
    private InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = FindObjectOfType<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Debug.Log("Left click");
            int textLen = inputField.text.Length;
            if (textLen > 0)
            {
                inputField.text = inputField.text.Remove(textLen-1);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            // Debug.Log("Middle click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Debug.Log("Right click");
            inputField.text = "";
        }
    }
}
