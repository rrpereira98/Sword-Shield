using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            Instantiate(gameManager, new Vector3(0, 0, 0), transform.rotation);
        }
    }
}
