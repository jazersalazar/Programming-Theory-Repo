using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ENCAPSULATION
public class Status : MonoBehaviour
{
    private int hp;
    private int stamina;
    public bool isSpecial = false;

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public bool IsSpecial
    {
        get { return isSpecial; }
        set { isSpecial = value; }
    }
}
