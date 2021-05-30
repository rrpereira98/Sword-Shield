using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Level", menuName = "Health")]
public class Health : ScriptableObject
{
    public int health;
    public int lvl;
    public int attack;
    public int accuracy;
}
