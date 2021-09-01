using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;

    public int gainPerKill;

    private WaveSpawnerProto3 ws;
    void Start()
    {
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney;
        FreeEnemy.SubtractLives += SubtractLives;
        FreeEnemy.GainMoney += AddMoney;
        ws = GetComponent<WaveSpawnerProto3>();
        WaveSpawnerProto3.winEvent += Win;
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
        WaveSpawnerProto3.winEvent -= Win;
    }

    public void Win()
    {
        SceneManager.LoadScene("Prototype3");
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
