using UnityEngine;
using System;

public class ObjectToggler : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    private bool isObject1Visible = true;

    public void ToggleObjects()
    {
        if (isObject1Visible)
        {
            object1.SetActive(false);
            object2.SetActive(true);
            isObject1Visible = false;
        }
        else
        {
            object1.SetActive(true);
            object2.SetActive(false);
            isObject1Visible = true;
        }
    }
}