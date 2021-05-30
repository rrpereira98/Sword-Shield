using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;

    //Player Gear
    public bool shield;
    public bool sword = true;
    public bool longSword;

    // Player Stats
    public int playerHealth;
    public int playerExp;
    public int money;
    public int attack;
    public int accuracy = 50;

    public bool gameOver = false;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        EndGame();
        CheckGearChanges();
    }

    private void EndGame()
    {
        if (gameOver)
        {
            gameOver = false;
            FindObjectOfType<Canvas>().transform.Find("EndScreen").gameObject.SetActive(true);
        }
    }

    private void CheckGearChanges()
    {
        if (FindObjectOfType<PlayerArmor>())
        {
            if (shield && FindObjectOfType<PlayerArmor>().shield.activeSelf == false)
            {
                FindObjectOfType<PlayerArmor>().shield.SetActive(true);
            }
            if (sword && FindObjectOfType<PlayerArmor>().sword.activeSelf == false)
            {
                FindObjectOfType<PlayerArmor>().sword.SetActive(true);
            }
            if (longSword && FindObjectOfType<PlayerArmor>().longSword.activeSelf == false)
            {
                shield = false;
                FindObjectOfType<PlayerArmor>().shield.SetActive(false);
                sword = false;
                FindObjectOfType<PlayerArmor>().sword.SetActive(false);

                FindObjectOfType<PlayerArmor>().longSword.SetActive(true);
            }
        }
    }
}
