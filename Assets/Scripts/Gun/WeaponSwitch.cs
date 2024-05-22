using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject bow;
    public GameObject sword;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void SwitchWeapon()
    {
        if (bow.activeInHierarchy == true)
        {
            player.GetComponent<PlayerCombat>().enabled = true;
            bow.SetActive(false);
            sword.SetActive(true);
        }
        else if (sword.activeInHierarchy == true)
        {
            player.GetComponent<PlayerCombat>().enabled = false;
            sword.SetActive(false);
            bow.SetActive(true);
        }
    }

}