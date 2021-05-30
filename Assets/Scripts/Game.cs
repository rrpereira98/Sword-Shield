using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    private void Awake()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            Instantiate(gameManager, new Vector3(0, 0, 0), transform.rotation);
        }

        // player.transform.position = new Vector3(-30.09457f, 0.06305432f, 8.392f);
        // // player.transform.Rotate(0, 15.368f, 0, Space.World);

        // enemy.transform.position = new Vector3(-29.513f, 0.067f, 10.212f);
        // // enemy.transform.Rotate(0, 201.586f, 0, Space.World);
    }
}
