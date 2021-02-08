using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour
{
    [SerializeField] GameObject parent;

    bool canHit = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (canHit)
        {
            if (other.tag == "Enemy" || other.tag == "Player")
            {
                if (parent.GetComponent<PlayerController>() == true)
                {
                    parent.GetComponent<PlayerController>().hit = true;
                }
                else if (parent.GetComponent<EnemyController>() == true)
                {
                    parent.GetComponent<EnemyController>().hit = true;
                }
                Debug.Log("hit!");
                canHit = false;
                StartCoroutine(CanHit());
            }
        }
    }

    IEnumerator CanHit()
    {
        yield return new WaitForSeconds(1.5f);
        canHit = true;
    }
}
