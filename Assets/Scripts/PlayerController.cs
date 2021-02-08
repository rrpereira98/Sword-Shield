using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject enemy;
    DamageDealer damageDealer;
    EnemyController enemyController;

    public bool hit = false;
    public bool itsTurn = true;

    private void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        enemyController = enemy.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itsTurn)
            Attack1();

        CheckHit();
    }

    private void Attack1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetInteger("attackNum", 1);
            itsTurn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetInteger("attackNum", 2);
            itsTurn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetInteger("attackNum", 3);
            itsTurn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetInteger("attackNum", 4);
            itsTurn = false;
        }
    }

    private void CheckHit()
    {
        if (hit == true)
        {
            animator.SetInteger("attackNum", 0);
            hit = false;

            enemyController.wasHit = true;
            damageDealer.hit = true;
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "Enemy")
    //     {
    //         hit = true;
    //         Debug.Log("hit!");
    //     }
    // }
}
