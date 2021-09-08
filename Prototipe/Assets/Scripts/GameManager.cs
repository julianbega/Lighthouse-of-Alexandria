﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;

    public int gainPerKill;

    public Light Light;
    public Light day;
    private WaveSpawnerProto3 ws;
    private Levels lvl;
    public bool LightsOnDayOff;
    void Start()
    {
        LightsOnDayOff = false;
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney;
        FreeEnemy.SubtractLives += SubtractLives;
        FreeEnemy.GainMoney += AddMoney;
        ws = GetComponent<WaveSpawnerProto3>();
        lvl = GetComponent<Levels>();
        WaveSpawnerProto3.winGameEvent += Win;
        // Node.GetMoney += getMoney;
    }
    private void Update()
    {
        if (lives <= 0)
            SceneManager.LoadScene("Prototype3");
    }
    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        FreeEnemy.SubtractLives -= SubtractLives;
        FreeEnemy.GainMoney -= AddMoney;
        WaveSpawnerProto3.winGameEvent -= Win;
    }

    public void Win()
    {
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
    }

    public void LightOn()
    {
        Light.gameObject.SetActive(true);
    }

    public void Lightoff()
    {
        Light.gameObject.SetActive(false);
    }

    public void StartDay()
    {
        LightsOnDayOff = false;
        day.gameObject.SetActive(true);
    }

    public void finishDay()
    {
        LightsOnDayOff = true;
        day.gameObject.SetActive(false);
    }
}
