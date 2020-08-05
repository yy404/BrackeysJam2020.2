using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScripts : MonoBehaviour
{
    public int enemyLevel;
    private GameplayManager gameplayManager;

    // Start is called before the first frame update
    void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Debug.Log("Clicked on the UI");
        }
        else
        {
            gameplayManager.StartGame(enemyLevel);
        }
    }
}
