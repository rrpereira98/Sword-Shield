using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;
    Animator animator;
    PlayerController playerController;
    EnemyController enemyController;
    GameManager gameManager;

    bool moveCard;
    bool moveCardBack;
    GameObject card;
    Vector2 startPosition;
    Vector3 startRotation;
    int speed = 1500;
    [SerializeField] int baseAccuracy;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        baseAccuracy = gameManager.accuracy;

        player = GameObject.Find("Player");

        playerController = player.GetComponent<PlayerController>();
        enemyController = playerController.enemy.GetComponent<EnemyController>();
        animator = playerController.animator;
    }

    private void Update()
    {
        if (moveCard)
        {
            card.transform.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, speed * Time.deltaTime);
            if (card.transform.position.x == target.transform.position.x && card.transform.position.y == target.transform.position.y)
            {
                moveCard = false;
            }

            card.transform.eulerAngles = new Vector3(card.transform.eulerAngles.x, card.transform.eulerAngles.y, 0);
        }

        if (moveCardBack)
        {
            card.transform.position = Vector2.MoveTowards(transform.parent.position, startPosition, speed * Time.deltaTime);
            if (card.transform.position.x == startPosition.x && card.transform.position.y == startPosition.y)
            {
                moveCardBack = false;
            }

            card.transform.eulerAngles = startRotation;
        }
    }

    public void Attack1()
    {
        if (playerController.itsTurn && playerController.numAttack1 == 0)
        {
            animator.SetInteger("attackNum", 1);

            playerController.Attacked1 = true;
            playerController.AttackUses();
            playerController.Attacked1 = false;

            int hitProb = Random.Range(0, 100);
            Debug.Log(hitProb);
            if (hitProb <= baseAccuracy || playerController.unblockable == true)
            {
                player.GetComponent<DamageDealer>().attackNum = 1;
                playerController.unblockable = false;
            }
            else
            {
                enemyController.blocking = true;
            }

            StartCoroutine(BringCardToFront());

        }
    }
    public void Attack2()
    {
        if (playerController.itsTurn && playerController.numAttack2 == 0)
        {
            animator.SetInteger("attackNum", 2);

            playerController.Attacked2 = true;
            playerController.AttackUses();
            playerController.Attacked2 = false;

            int hitProb = Random.Range(0, 100);
            if (hitProb <= baseAccuracy || playerController.unblockable == true)
            {
                player.GetComponent<DamageDealer>().attackNum = 2;
                playerController.unblockable = false;
            }
            else
            {

            }

            StartCoroutine(BringCardToFront());
        }
    }
    public void Attack3()
    {
        if (playerController.itsTurn && playerController.numAttack3 == 0)
        {
            animator.SetInteger("attackNum", 3);



            int hitProb = Random.Range(0, 100);
            Debug.Log(hitProb);
            if (hitProb <= baseAccuracy)
            {
                playerController.Attacked3 = true;
                playerController.AttackUses();
                playerController.Attacked3 = false;

                player.GetComponent<DamageDealer>().attackNum = 3;
                playerController.unblockable = true;
            }
            else
            {
                playerController.AttackUses();
                playerController.numAttack3 = 2;
                playerController.itsTurn = false;
                enemyController.blocking = true;
            }

            StartCoroutine(BringCardToFront());
        }
    }
    public void Attack4()
    {
        if (playerController.itsTurn && playerController.numAttack4 == 0)
        {
            animator.SetInteger("attackNum", 4);

            playerController.Attacked4 = true;
            playerController.AttackUses();
            playerController.Attacked4 = false;

            int hitProb = Random.Range(0, 100);
            if (hitProb <= baseAccuracy || playerController.unblockable == true)
            {
                player.GetComponent<DamageDealer>().attackNum = 4;
                playerController.unblockable = false;
            }
            else
            {

            }

            StartCoroutine(BringCardToFront());
        }
    }

    IEnumerator BringCardToFront()
    {
        int siblingIndex;
        card = transform.parent.gameObject;

        siblingIndex = transform.parent.GetSiblingIndex();
        startPosition = transform.parent.position;
        startRotation = transform.parent.eulerAngles;
        transform.parent.SetAsLastSibling();
        moveCard = true;
        yield return new WaitForSeconds(1);
        transform.parent.SetSiblingIndex(siblingIndex);
        moveCardBack = true;
    }
}
