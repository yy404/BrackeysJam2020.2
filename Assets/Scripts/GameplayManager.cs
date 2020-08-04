using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject Title;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        panel.SetActive(true);
        Title.SetActive(false);
    }

    public void EndGame()
    {
        panel.SetActive(false);
        Title.SetActive(true);
    }
}
