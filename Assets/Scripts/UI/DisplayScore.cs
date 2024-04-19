using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private Statistics statistics;
    private TMP_Text tmpText;
    public GameObject WinPanel;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
        statistics = FindObjectOfType<Statistics>();
    }
    private void Update()
    {
        if (statistics.score >= 15)
        {
            WinPanel.SetActive(true);
        }

        tmpText.text = "Score: " +statistics.score + "";
    }
}