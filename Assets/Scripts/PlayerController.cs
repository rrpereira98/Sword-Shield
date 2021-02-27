using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject enemy;
    DamageDealer damageDealer;
    EnemyController enemyController;
    GameManager gameManager;

    public bool hit = false;
    public bool itsTurn = true;
    public bool wasHit = false;
    public bool blocking = false;
    public bool isDead = false;

    //Number of attacks
    int numAttack1 = 0; //sempre
    bool Attacked1 = false;

    int numAttack2 = 0; //ronda sim ronda nao
    bool Attacked2 = false;

    int numAttack3 = 0; // 2 em 2 rondas
    bool Attacked3 = false;

    int numAttack4 = 0; // 5 em 5 rondas
    bool Attacked4 = false;


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
        if (itsTurn)
            Attack();
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
            StartCoroutine(Blocked());
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && numAttack1 == 0)
        {
            animator.SetInteger("attackNum", 1);

            Attacked1 = true;
            AttackUses();
            Attacked1 = false;

            GetComponent<DamageDealer>().attackNum = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && numAttack2 == 0)
        {
            animator.SetInteger("attackNum", 2);

            Attacked2 = true;
            AttackUses();
            Attacked2 = false;

            GetComponent<DamageDealer>().attackNum = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && numAttack3 == 0)
        {
            animator.SetInteger("attackNum", 3);

            Attacked3 = true;
            AttackUses();
            Attacked3 = false;

            GetComponent<DamageDealer>().attackNum = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && numAttack4 == 0)
        {
            animator.SetInteger("attackNum", 4);

            Attacked4 = true;
            AttackUses();
            Attacked4 = false;

            GetComponent<DamageDealer>().attackNum = 4;
        }
    }

    private void AttackUses()
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
