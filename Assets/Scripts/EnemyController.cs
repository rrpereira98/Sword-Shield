using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    PlayerController playerController;

    public bool hit = false;
    public bool wasHit = false;
    [SerializeField] bool blocking = false; //serialized for debug
    [SerializeField] public bool itsTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wasHit && !blocking)
            StartCoroutine(WasHit());
        else if (wasHit && blocking)
            StartCoroutine(Blocked());

        if (itsTurn)
        {
            StartCoroutine(Attack());
            itsTurn = false;
        }

        CheckHit();
    }

    IEnumerator Attack()
    {
        int attackNum;
        yield return new WaitForSeconds(1);
        attackNum = Random.Range(1, 1); // last number is number of attacks
        animator.SetInteger("AttackNum", attackNum);
    }

    private void CheckHit()
    {
        if (hit == true)
        {
            animator.SetInteger("AttackNum", 0);
            hit = false;
            StartCoroutine(MakePlayerTurn());
            // damageDealer.hit = false;

            // enemyController.wasHit = true;
        }
    }

    IEnumerator WasHit()
    {
        wasHit = false;
        animator.SetBool("WasHit", true);
        yield return new WaitForSeconds(0.64f);
        animator.SetBool("WasHit", false);
        itsTurn = true;
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
