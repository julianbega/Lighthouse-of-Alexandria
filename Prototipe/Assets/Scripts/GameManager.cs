using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    
    void Start()
    {
       // Node.GetMoney += getMoney;
    }

    // Update is called once per frame
    void Update()
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
}
