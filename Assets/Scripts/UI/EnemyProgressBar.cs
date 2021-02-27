using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class EnemyProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    [SerializeField] GameObject user;
    HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = user.GetComponent<HealthManager>();
        maximum = healthManager.health;
    }

    // Update is called once per frame
    void Update()
    {
        current = healthManager.health;

        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
}
