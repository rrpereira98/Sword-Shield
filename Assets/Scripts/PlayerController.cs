using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject enemy;
    DamageDealer damageDealer;
    EnemyController enemyController;
    GameManager gameManager;

    public bool hit = false;
    public bool itsTurn = true;
    public bool wasHit = false;
    public bool blocking = false;
    public bool unblockable = false;
    public bool isDead = false;
    public bool kicked = false;

    //Number of attacks
    public int numAttack1 = 0; //sempre
    public bool Attacked1 = false;

    public int numAttack2 = 0; //ronda sim ronda nao
    public bool Attacked2 = false;

    public int numAttack3 = 0; // 2 em 2 rondas
    public bool Attacked3 = false;

    public int numAttack4 = 0; // 5 em 5 rondas
    public bool Attacked4 = false;

    private void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        enemyController = enemy.GetComponent<EnemyController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HitAnimHandler();
        // if (itsTurn)
        //     Attack();
        CheckHit();
        Dead();
    }

    private void Dead()
    {
        if (isDead)
        {
            animator.SetBool("IsDead", true);
            itsTurn = false;
            enemyController.itsTurn = false;
            if (gameManager)
            {
                gameManager.gameOver = true;
                gameManager = null;
            }
            isDead = false;
        }
    }

    private void HitAnimHandler()
    {
        if (wasHit && !blocking)
            StartCoroutine(WasHit());
        else if (wasHit && blocking)
        {
            StartCoroutine(Blocked());
            blocking = false;
        }
    }

    public void AttackUses()
    {
        if (numAttack1 == 0 && Attacked1)
        {
            itsTurn = false;
        }

        if (numAttack2 == 0 && Attacked2)
        {
            numAttack2 = 1;
            itsTurn = false;
        }
        else if (numAttack2 != 0)
        {
            numAttack2 -= 1;
        }

        if (numAttack3 == 0 && Attacked3)
        {
            numAttack3 = 2;
            itsTurn = false;
            enemyController.kicked = true;
        }
        else if (numAttack3 != 0)
        {
            numAttack3 -= 1;
        }

        if (numAttack4 == 0 && Attacked4)
        {
            numAttack4 = 5;
            itsTurn = false;
        }
        else if (numAttack4 != 0)
        {
            numAttack4 -= 1;
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

    IEnumerator WasHit()
    {
        wasHit = false;
        animator.SetBool("WasHit", true);
        yield return new WaitForSeconds(0.64f);
        animator.SetBool("WasHit", false);

        //hit by kick
        if (kicked)
        {
            kicked = false;
            itsTurn = false;
            enemyController.itsTurn = true;
        }
    }

    IEnumerator Blocked()
    {
        wasHit = false;
        animator.SetBool("Blocked", true);
        yield return new WaitForSeconds(0.64f);
        animator.SetBool("Blocked", false);
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
