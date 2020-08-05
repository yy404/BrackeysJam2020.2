using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject Title;
    public InputField inputField;
    private UIScripts uiScripts;
    private Oscillator oscillator;

    // Start is called before the first frame update
    void Start()
    {
        uiScripts = FindObjectOfType<UIScripts>();
        oscillator = FindObjectOfType<Oscillator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        panel.SetActive(true);
        Title.SetActive(false);
        oscillator.GeneAudioData();
        oscillator.ResetDataIndex();
        uiScripts.UpdateNoteListString(Random.Range(0, 7));
    }

    public void EndGame()
    {
        panel.SetActive(false);
        Title.SetActive(true);
        inputField.text = "";
    }
}
