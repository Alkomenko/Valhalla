using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject bow;
    public GameObject sword;

    public void SwitchWeapon()
    {
        if (bow.activeInHierarchy == true)
        {
            bow.SetActive(false);
            sword.SetActive(true);
        }
        else if (sword.activeInHierarchy == true)
        {
            sword.SetActive(false);
            bow.SetActive(true);
        }
    }

}
