using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgrade : MonoBehaviour
{
    public static bool PauseGame;
    private PlayerCombat _playerCombat;
    public GameObject pauseMenu;
    private Movement _playerMovement;
    private GemPlayer _gemPlayer;

    public void Start()
    {
        _playerCombat = new PlayerCombat();
        _gemPlayer = new GemPlayer();
        _playerMovement = new Movement();
    }

    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;   
        }
        else if (Time.timeScale == 0f){
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseGame = true; 
        }

    }
    
    // Прокачка дальности атаки
    public void AttackRangeUp()
    {
        if (_playerCombat.attackRate < 1f /*&& _gemPlayer.gem > 1*/)
        {
            // _gemPlayer.gem--;
            _playerCombat.attackRate += 0.1f;
        }
        else
        {
            // Логика отображения сообщения о максимальной прокачки.
        }

    }
    // Прокачка урона
    public void AttackDamageUp()
    {

        if (_playerCombat.attackDamage < 100 /*&& _gemPlayer.gem > 1*/)
        {
            //_gemPlayer.gem--;
            _playerCombat.attackDamage += 10;
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
        if (_playerMovement.Speed < 10 /*&& _gemPlayer.gem > 1*/)
        {
                // _gemPlayer.gem--;
                _playerMovement.Speed += 1;   
        }
        else
        {
            // Логика отображения сообщения о максимальной прокачки.
        }
    }
}
