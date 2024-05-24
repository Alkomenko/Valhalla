using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgrade : MonoBehaviour
{
    public static bool PauseGame;
    private PlayerCombat _playerCombat;
    public GameObject MarketMenu;
    public GameObject BackpackMenu;
    private Movement _playerMovement;
    // private GemPlayer _gemPlayer;
    public static int attackDamage = 20;
    public static float speed = 5;

    public void Resume()
    {
        MarketMenu.SetActive(false);
        BackpackMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            MarketMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;   
        }
        else if (Time.timeScale == 0f){
            MarketMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseGame = true; 
        }

    }
    
    // Прокачка дальности атаки
    /*public void AttackRangeUp()
    {
        if (_playerCombat.attackRate < 1f && GemPlayer.gem >= 1)
        {
            GemPlayer.gem -= 1;
            _playerCombat.attackRate += 0.1f;
        }
        else
        {
            // Логика отображения сообщения о максимальной прокачки.
        }
        GameObject.FindGameObjectWithTag ("Player").GetComponent<GemPlayer> ().TextGem.text = GemPlayer.gem.ToString();

    }*/
    // Прокачка урона
    public void AttackDamageUp()
    {

        if (attackDamage < 100 && GemPlayer.gem >= 10)
        {
            GemPlayer.gem -= 10;
            attackDamage += 5;
            
            GameObject.FindGameObjectWithTag ("Player").GetComponent<GemPlayer> ().TextGem.text = GemPlayer.gem.ToString();
        }
        else
        {
            // Логика отображения сообщения о максимальной прокачки.
        }
    }
    
    // Прокачка скорости атаки
    public void AttackRateUp()
    {
        
    }
    public void NextAttackTimeUp()
    {
        
    }
    
    // Прокачка скорости передвижения персонажа
    public void SpeedUp()
    {
        if (speed < 10 && GemPlayer.gem >= 50)
        {
                GemPlayer.gem -= 50;
                speed += 1;   
        }
        else
        {
            // Логика отображения сообщения о максимальной прокачки.
        }
        GameObject.FindGameObjectWithTag ("Player").GetComponent<GemPlayer> ().TextGem.text = GemPlayer.gem.ToString();
    }
}
