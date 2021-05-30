using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    public int attackNum = 0;

    public bool hit = false;

    private void Update()
    {
        DamageEnemy();
    }

    private void DamageEnemy()
    {
        if (hit == true)
        {
            if (attackNum == 1)
            {
                if (enemy.GetComponent<HealthManager>() != null)
                    enemy.GetComponent<HealthManager>().health -= 10;
                else
                    enemy.GetComponent<PlayerHealth>().health -= 10;
            }
            else if (attackNum == 2)
            {
                if (enemy.GetComponent<HealthManager>() != null)
                    enemy.GetComponent<HealthManager>().health -= 15;
                else
                    enemy.GetComponent<PlayerHealth>().health -= 15;
            }
            else if (attackNum == 3)
            {
                if (enemy.GetComponent<HealthManager>() != null)
                    enemy.GetComponent<HealthManager>().health -= 0;
                else
                    enemy.GetComponent<PlayerHealth>().health -= 0;
            }
            else if (attackNum == 4)
            {
                if (enemy.GetComponent<HealthManager>() != null)
                    enemy.GetComponent<HealthManager>().health -= 25;
                else
                    enemy.GetComponent<PlayerHealth>().health -= 25;
            }
            hit = false;
            attackNum = 0;
        }
    }
}
