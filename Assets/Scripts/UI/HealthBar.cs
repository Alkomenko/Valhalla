using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{ 
    public GameObject HealthBarCanvas;
    public BossHealth boss;
    public Slider slider;

    void Start()
    {
        slider.maxValue = boss.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = boss.health;
        if (boss.health == 0)
        {
            Destroy(gameObject);
            HealthBarCanvas.SetActive(false);
        }
    }
}