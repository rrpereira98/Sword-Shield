using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoreScript : MonoBehaviour
{
    //Menus and menu animation speed
    int speed = 1500;
    [SerializeField] GameObject menu1;
    [SerializeField] GameObject menu1Spot;
    [SerializeField] GameObject weaponsMenu;
    [SerializeField] GameObject weaponsMenuSpot;

    private void Update()
    {
        GoToMiddleOfScreen();
    }

    public void GoToMiddleOfScreen()
    {
        menu1.transform.position = Vector3.MoveTowards(menu1.transform.position, menu1Spot.transform.position, speed * Time.deltaTime);
        weaponsMenu.transform.position = Vector3.MoveTowards(weaponsMenu.transform.position, weaponsMenuSpot.transform.position, speed * Time.deltaTime);
    }
}
