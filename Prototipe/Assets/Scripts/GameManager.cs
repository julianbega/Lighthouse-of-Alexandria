using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;

    public int gainPerKill;

    public Light Light;
    public Light day;
    private Levels lvl;

    void Start()
    {
        lvl = FindObjectOfType<Levels>();
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney; 
        Levels.SetNightOn += SetNight;
        Levels.SetDayOn += SetDay;
        FreeEnemy.SubtractLives += SubtractLives;
        FreeEnemy.GainMoney += AddMoney;
        // Node.GetMoney += getMoney;
    }

    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        FreeEnemy.SubtractLives -= SubtractLives;
        FreeEnemy.GainMoney -= AddMoney;
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
    }
    public void SetNight()
    {
        if (lvl.GetActualLVL() > 0)
        {
            day.enabled = false;
            Light.enabled = true;
        }
    }
    public void SetDay()
    {
        day.enabled = true;
        Light.enabled = false;
    }
}
