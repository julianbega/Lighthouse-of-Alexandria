using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;
   
    public int gainPerKill;

    public Light Light;
    public Light day;
    public bool isDayTime;
    public int lastLvl;
    private Levels lvl;

    public bool victory;
    static public event Action ShowEndGame;

    void Start()
    {
        victory = false;
        lvl = FindObjectOfType<Levels>();
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney; 
        Levels.SetNightOn += SetNight;
        Levels.SetDayOn += SetDay;
        // Node.GetMoney += getMoney;
        isDayTime = true;
    }

    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        Levels.SetNightOn -= SetNight;
        Levels.SetDayOn -= SetDay;
    }

    public int GetMoney()
    {
        return money;
    }
    public void moneySubtract(int price)
    {
        money = money - price;
    }
    public void AddMoney()
    {
        money += gainPerKill;
    }
    public int GetLives()
    {
        return lives;
    }
    public void SubtractLives()
    {
        lives--;
        if (lives<= 0)
        {
            Defeat();
        }
        return;
    }
    public void SetNight()
    {
        if (lvl.GetActualLVL() > 0)
        {
            day.enabled = false;
            Light.enabled = true;
            isDayTime = false;
        }
    }
    public void SetDay()
    {
        day.enabled = true;
        Light.enabled = false;
        isDayTime = true;
        if (lvl.actualLvl >= lastLvl)
        {
            victory = true;
            ShowEndGame?.Invoke();
        }
    }
    public void Defeat()
    {
        ShowEndGame?.Invoke();
    }
}
