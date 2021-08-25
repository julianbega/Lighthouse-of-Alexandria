﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;
    
    public int gainPerKill;
    void Start()
    {
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney;
        // Node.GetMoney += getMoney;
    }
    private void Update()
    {
        if (lives <= 0)
            SceneManager.LoadScene("SampleScene");
    }
    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
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
}
