using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class PlayerProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    [SerializeField] GameObject user;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = user.GetComponent<PlayerHealth>();
        maximum = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        current = playerHealth.health;

        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
}
