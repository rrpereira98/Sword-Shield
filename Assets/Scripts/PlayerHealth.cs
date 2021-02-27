using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 75;

    private void Update()
    {
        if (health <= 0)
        {
            GetComponent<PlayerController>().isDead = true;
        }
    }
}
