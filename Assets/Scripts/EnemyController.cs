using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] HealthManager healthManager;
    PlayerController playerController;
    DamageDealer damageDealer;
    GameManager gameManager;

    public bool hit = false;
    public bool wasHit = false;
    int attackNum;
    public bool blocking = false;
    bool unblockable = false;
    [SerializeField] public bool itsTurn = false;
    public bool isDead = false;
    public bool kicked = false;
    public int baseAccuracy;

    //Number of attacks
    int numAttack1 = 0; //sempre
    bool Attacked1 = false;

    int numAttack2 = 0; //ronda sim ronda nao
    bool Attacked2 = false;

    int numAttack3 = 0; // 2 em 2 rondas
    bool Attacked3 = false;

    int numAttack4 = 0; // 5 em 5 rondas
    bool Attacked4 = false;

    int kickProb = -1;
    int hitProb = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        damageDealer = GetComponent<DamageDealer>();
        gameManager = FindObjectOfType<GameManager>();
        baseAccuracy = healthManager.accuracy;
    }

    // Update is called once per frame
    void Update()
    {
        if (wasHit && !blocking)
            StartCoroutine(WasHit());
        else if (wasHit && blocking)
        {
            StartCoroutine(Blocked());
            blocking = false;
        }
        if (itsTurn)
        {
            StartCoroutine(Attack());
            itsTurn = false;
        }

        CheckHit();

        Dead();
    }

    private void Dead()
    {
        if (isDead)
        {
            animator.SetBool("IsDead", true);
            itsTurn = false;
            playerController.itsTurn = false;
            if (gameManager)
            {
                gameManager.money += 100;
                gameManager.gameOver = true;
                gameManager = null;
            }
            isDead = false;
        }
    }

    IEnumerator Attack()
    {
        List<int> possibleAttacks = new List<int>(new int[] { 1 });
        yield return new WaitForSeconds(1);

        if (numAttack2 == 0)
        {
            possibleAttacks.Add(2);
        }
        if (numAttack3 == 0)
        {
            possibleAttacks.Add(3);
        }
        if (numAttack4 == 0)
        {
            possibleAttacks.Add(4);
        }

        attackNum = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        if (attackNum == 1)
        {
            Attacked1 = true;
        }
        else if (attackNum == 2)
        {
            Attacked2 = true;
        }
        else if (attackNum == 3)
        {
            kickProb = Random.Range(0, 100);
            if (kickProb <= baseAccuracy)
            {
                Attacked3 = true;
                playerController.kicked = true;
                unblockable = true;
            }
            else
            {
                numAttack3 = 2;
                Attacked3 = false;
            }
        }
        else if (attackNum == 4)
        {
            Attacked4 = true;
        }

        itsTurn = false;
        animator.SetInteger("AttackNum", attackNum);
        GetComponent<DamageDealer>().attackNum = attackNum;
        possibleAttacks = new List<int>(new int[] { 1 });
        CheckNumberOfAttacks();
    }

    private void CheckNumberOfAttacks()
    {
        if (numAttack1 == 0 && Attacked1)
        {
            numAttack1 = 0;
            Attacked1 = false;
        }

        if (numAttack2 == 0 && Attacked2)
        {
            numAttack2 = 1;
            Attacked2 = false;
        }
        else if (numAttack2 != 0)
        {
            numAttack2 -= 1;
        }

        if (numAttack3 == 0 && Attacked3)
        {
            numAttack3 = 2;
            Attacked3 = false;
        }
        else if (numAttack3 != 0)
        {
            numAttack3 -= 1;
        }

        if (numAttack4 == 0 && Attacked4)
        {
            numAttack4 = 5;
            Attacked4 = false;
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
            animator.SetInteger("AttackNum", 0);
            hit = false;

            if (kickProb == -1)
            {
                hitProb = Random.Range(0, 100);
                Debug.Log(hitProb);
            }
            else
            {
                hitProb = kickProb;
            }

            if (hitProb <= baseAccuracy || unblockable == true)
            {
                damageDealer.hit = true;
                unblockable = false;
            }
            else
            {
                playerController.blocking = true;
            }

            playerController.wasHit = true;
            if (playerController.kicked)
            {
                playerController.itsTurn = false;
            }
            else
            {
                StartCoroutine(MakePlayerTurn());
            }
        }
    }

    IEnumerator WasHit()
    {
        wasHit = false;
        animator.SetBool("WasHit", true);
        yield return new WaitForSeconds(0.64f);
        animator.SetBool("WasHit", false);
        if (kicked == true)
        {
            kicked = false;
            itsTurn = false;
            StartCoroutine(MakePlayerTurn());
        }
        else
        {
            itsTurn = true;
        }
    }

    IEnumerator Blocked()
    {
        wasHit = false;
        animator.SetBool("Blocked", true);
        yield return new WaitForSeconds(0.64f);
        animator.SetBool("Blocked", false);
        itsTurn = true;
    }

    IEnumerator MakePlayerTurn()
    {
        yield return new WaitForSeconds(1);
        playerController.itsTurn = true;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     hit = true;
    //     // damageDealer.hit = true;
    //     //Debug.Log("hit!");
    // }
}
