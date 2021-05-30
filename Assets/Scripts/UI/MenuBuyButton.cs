using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuBuyButton : MonoBehaviour
{
    GameManager gameManager;

    // UI elements
    [SerializeField] TMP_Text money;
    [SerializeField] TMP_Text accuracy;
    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text attack;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        money.text = gameManager.money.ToString();
        health.text = gameManager.playerHealth.ToString();
        accuracy.text = gameManager.accuracy.ToString();
        attack.text = gameManager.attack.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressButton()
    {
        Debug.Log(this.gameObject.name);
        if (this.gameObject.name == "StoreItemSlot 1" && gameManager.money >= 100)
        {
            // take the money and add buffs
            gameManager.money -= 100;
            gameManager.playerHealth += 10;
            gameManager.accuracy += 10;

            // update ui
            money.text = gameManager.money.ToString();
            health.text = gameManager.playerHealth.ToString();
            accuracy.text = gameManager.accuracy.ToString();

            // give items
            gameManager.sword = true;
        }
        else if (this.gameObject.name == "StoreItemSlot 2" && gameManager.money >= 100)
        {
            // take the money and add buffs
            gameManager.money -= 100;
            gameManager.playerHealth += 10;

            // update ui
            money.text = gameManager.money.ToString();
            health.text = gameManager.playerHealth.ToString();

            // give items
            gameManager.shield = true;
        }
        else if (this.gameObject.name == "StoreItemSlot 3" && gameManager.money >= 100)
        {
            // take the money and add buffs
            gameManager.money -= 100;
            gameManager.playerHealth += 10;

            // update ui
            money.text = gameManager.money.ToString();
            health.text = gameManager.playerHealth.ToString();

            // give items
            gameManager.sword = false;
            gameManager.shield = false;
            gameManager.longSword = true;
        }
        else if (this.gameObject.name == "StoreItemSlot 4" && gameManager.money >= 100)
        {
            // take the money and add buffs
            gameManager.money -= 100;
            gameManager.playerHealth += 10;

            // update ui
            money.text = gameManager.money.ToString();
            health.text = gameManager.playerHealth.ToString();

            // give items
            gameManager.sword = false;
            gameManager.shield = false;
            gameManager.longSword = true;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
