using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;
   
    public int gainPerKill;

    public GameObject Light;
    public GameObject waterBarrierForShader; //se debe cambiar por un mesh renderer
    public Light day;
    public bool finishDay { get; set; }
    public bool finishNight { get; set; }
    public bool isDayTime;
    public int lastLvl;
    private Levels lvl;

    public bool victory;
    static public event Action ShowEndGame;
    static public event Action StopUIInteractions;

    [SerializeField] private Animator dayCycle;
    [SerializeField] [Range(0.0f, 1.0f)] float lerpTime;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    static public GameManager instance;

    static public GameManager GetInstance { get { return instance; } }

    private uint gameMusicID;
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
        WaveSpawner.SetStateDayAnim += DayCycle;
        Levels.SetDayOn += DayCycle;
        Levels.SetNightOn += DayCycle;
        isDayTime = true;
        dayCycle.SetBool("startDay", true);
        dayCycle.SetBool("isDay", false);

        gameMusicID = AkSoundEngine.PostEvent("play_gamestart", this.gameObject);
        //waterBarrierForShader.material.color = startColor;
    }

    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        //Levels.SetNightOn -= SetNight;
        //Levels.SetDayOn -= SetDay;
        WaveSpawner.SetStateDayAnim -= DayCycle;
        Levels.SetDayOn -= DayCycle;
        Levels.SetNightOn -= DayCycle;
    }

    private void Update()
    {
        if(!Light.activeInHierarchy && !isDayTime )
        {
            Light.SetActive(true);
            waterBarrierForShader.SetActive(true); // llamar a la corrutina que lo pasa de transparente a negro
            //StartCoroutine(WaterChangeColor(startColor, endColor));
        }
        if (Light.activeInHierarchy && isDayTime)
        {
            Light.SetActive(false);
            waterBarrierForShader.SetActive(false);// llamar a la corrutina que lo pasa de negro a transparente
            //StartCoroutine(WaterChangeColor(endColor, startColor));
        }
        if (lvl.actualLvl >= lastLvl)
        {
            victory = true;
            Debug.Log("Cambia de escena a creditos, termino el game");
            ScenesManager.instanceScenesManager.ChangeScene("Credits");
            StopUIInteractions?.Invoke();
        }

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
            isDayTime = false;
        }
    }
    public void SetDay()
    {
        day.enabled = true;
        isDayTime = true;
        
    }
    public void Defeat()
    {
        //ShowEndGame?.Invoke();
        ScenesManager.instanceScenesManager.ChangeScene("Credits");
        StopUIInteractions?.Invoke();
    }

    private void DayCycle(string state)
    {
        if (state == "Day")
        {
            isDayTime = true;
            dayCycle.SetBool("isDay", true);
            StartCoroutine(WaitForDayAnim(state));
        }
        else
        {
            isDayTime = false;
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
            AkSoundEngine.SetState("daytime", "day");
        }
        else
        {
            finishNight = true;
            finishDay = false;
            AkSoundEngine.SetState("daytime", "night");
        }
    }

    //public IEnumerator WaterChangeColor(Color startColor, Color endColor)
    //{
    //    yield return new WaitForSeconds(0.02f);
    //    waterBarrierForShader.material.color = Color.Lerp(startColor, endColor, lerpTime);
    //    yield return null;
    //}
}
