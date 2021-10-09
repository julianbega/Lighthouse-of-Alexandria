using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;
   
    public int gainPerKill;

    public Light Light;
    public Light day;
    public bool finishDay { get; set; }
    public bool finishNight { get; set; }
    public bool isDayTime;
    public int lastLvl;
    private Levels lvl;

    public bool victory;
    static public event Action ShowEndGame;

    [SerializeField] private Animator dayCycle;

    static public GameManager instance;

    static public GameManager GetInstance { get { return instance; } }

    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    void Start()
    {
        victory = false;
        lvl = FindObjectOfType<Levels>();
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney; 
        //Levels.SetNightOn += SetNight;
        //Levels.SetDayOn += SetDay;
        // Node.GetMoney += getMoney;
        WaveSpawnerProto3.SetStateDayAnim += DayCycle;
        Levels.SetDayOn += DayCycle;
        Levels.SetNightOn += DayCycle;
        isDayTime = true;
    }

    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        //Levels.SetNightOn -= SetNight;
        //Levels.SetDayOn -= SetDay;
        WaveSpawnerProto3.SetStateDayAnim -= DayCycle;
        Levels.SetDayOn -= DayCycle;
        Levels.SetNightOn -= DayCycle;
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

    private void DayCycle(string state)
    {
        if (state == "Day")
        {
            dayCycle.SetBool("isDay", true);
            StartCoroutine(WaitForDayAnim(state));
        }
        else
        {
            dayCycle.SetBool("isDay", false);
            StartCoroutine(WaitForDayAnim(state));
        }
    }

    public IEnumerator WaitForDayAnim(string state)
    {
        yield return new WaitForSeconds(2);
        if (state == "Day")
        {
            finishDay = true;
            finishNight = false;
        }
        else
        {
            finishNight = true;
            finishDay = false;
        }
    }

    public bool GetFinishDay()
    {
        return finishDay;
    }

    public bool GetFinishNight()
    {
        return finishNight;
    }
}
