using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenus : MonoBehaviour
{
    //Menus and menu animation speed
    int speed = 1500;
    [SerializeField] GameObject menu1;
    [SerializeField] GameObject menu1Spot;
    [SerializeField] GameObject weaponsMenu;
    [SerializeField] GameObject weaponsMenuSpot;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Menu1Buttons()
    {
        if (this.gameObject.name == "Armor Button")
        {
            menu1Spot.transform.position = new Vector3(-200, 400, 0);
        }

        if (this.gameObject.name == "Weapons Button")
        {
            menu1Spot.transform.position = new Vector3(680, 400, 0);
            weaponsMenuSpot.transform.position = new Vector3(240, 400, 0);
        }
    }
}
