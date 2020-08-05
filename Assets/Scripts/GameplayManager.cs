using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int initPowerPackNum;

    private UIScripts uiScripts;
    private Oscillator oscillator;
    private int currEnemyLevel;

    // Start is called before the first frame update
    void Start()
    {
        uiScripts = FindObjectOfType<UIScripts>();
        oscillator = FindObjectOfType<Oscillator>();

        oscillator.IncPowerValue(initPowerPackNum);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(int enemyLevel)
    {

        uiScripts.LeaveMenuScene();
        oscillator.GeneAudioData();
        oscillator.ResetDataIndex();

        currEnemyLevel = enemyLevel;

        int hintDigits = 0;
        switch (enemyLevel)
        {
            case 3:
                hintDigits = 3;
                break;
            case 2:
                hintDigits = 4; // Random.Range(2, 4) // 2 or 3
                break;
            case 1:
                hintDigits = 5; // Random.Range(4, 6) // 4 or 5
                break;
            default:
                Debug.Log("Unknown enemyLevel");
                break;
        }
        uiScripts.UpdateNoteListString(hintDigits);
    }

    public void EnableNextLevel()
    {
        // Enable next level enemy
        int currEnemyIndex = currEnemyLevel - 1;
        if (currEnemyIndex+1 < enemies.Length)
        {
            enemies[currEnemyIndex+1].SetActive(true);
        }
        else
        {
            Debug.Log("Win all levels");
        }
    }
}
