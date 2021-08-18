using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;
    
    void Start()
    {
        Enemy.SubtractLives += SubtractLives;
       // Node.GetMoney += getMoney;
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
    public int GetLives()
    {
        return lives;
    }
    public void SubtractLives()
    {
        lives--;
    }
}
