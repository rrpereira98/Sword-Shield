using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    PlayerHealth playerHealth;

    [SerializeField] GameObject SholderArmorL;
    [SerializeField] GameObject SholderArmorR;

    [SerializeField] float armorLevel = 0;
    float currentArmorLevel = 0;

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = gameObject.GetComponent<PlayerHealth>();

        if (SholderArmorL.activeSelf == true)
        {
            playerHealth.health += 15;
        }

        if (SholderArmorR.activeSelf == true)
        {
            playerHealth.health += 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ArmorHealth();
    }

    void ArmorHealth()
    {
        if (armorLevel - currentArmorLevel == 1 || armorLevel - currentArmorLevel > 1)
        {
            currentArmorLevel = armorLevel;
            playerHealth.health += 15;
        }
    }

    void LevelUpArmor()
    {
        armorLevel += 0.20f;
    }
}
