using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform Boss;
    public float offset;
    
    void Update()
    {
        // Проверить, существует ли объект Boss
        if (Boss != null)
        {
            // Позиционировать холст позади цели с заданным смещением
            transform.position = Boss.position + Vector3.up * offset;
        }
    }
}
