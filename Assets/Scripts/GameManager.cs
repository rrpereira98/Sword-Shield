using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;

    public int playerHealth;
    public int playerExp;
    public int money;

    public bool gameOver = false;

    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        EndGame();
    }

    private void EndGame()
    {
        if (gameOver)
        {
            gameOver = false;
            FindObjectOfType<Canvas>().transform.Find("EndScreen").gameObject.SetActive(true);
        }
    }
}
