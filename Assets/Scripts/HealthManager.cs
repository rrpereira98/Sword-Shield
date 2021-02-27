using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Health healthLevel;

    public int health;
    public int lvl;

    private void Awake()
    {
        health = healthLevel.health;
        lvl = healthLevel.lvl;
    }

    private void Update()
    {
        if (health <= 0)
            GetComponent<EnemyController>().isDead = true;
    }
}
