using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Health healthLevel;

    public int health;
    public int lvl;

    private void Start()
    {
        health = healthLevel.health;
        lvl = healthLevel.lvl;
    }
}
