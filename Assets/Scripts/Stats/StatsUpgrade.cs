using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgrade : MonoBehaviour
{
    public static bool PauseGame;
    private PlayerCombat _playerCombat;
    public GameObject MarketMenu;
    private Movement _playerMovement;
    // private GemPlayer _gemPlayer;
    public static int attackDamage = 100;
    public static float speed = 5;

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

        if (attackDamage < 100 && GemPlayer.gem >= 5)
        {
            GemPlayer.gem -= 5;
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
        if (speed < 10 && GemPlayer.gem >= 20)
        {
                GemPlayer.gem -= 20;
                speed += 1;   
        }
        else
        {
            // Логика отображения сообщения о максимальной прокачки.
        }
        GameObject.FindGameObjectWithTag ("Player").GetComponent<GemPlayer> ().TextGem.text = GemPlayer.gem.ToString();
    }
}
