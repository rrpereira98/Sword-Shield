using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    public bool hit = false;

    private void Update()
    {
        DamageEnemy();
    }

    private void DamageEnemy()
    {
        if (hit == true)
        {
            enemy.GetComponent<HealthManager>().health -= 10;
            hit = false;
        }
    }
}
