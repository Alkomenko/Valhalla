using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private Statistics statistics;
    private TMP_Text tmpText;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
        statistics = FindObjectOfType<Statistics>();
    }


    private void Update()
    {
        tmpText.text = "Убито: " +statistics.score + "";
    }
}
