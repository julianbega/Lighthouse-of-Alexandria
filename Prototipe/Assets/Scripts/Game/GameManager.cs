using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;  
    public int lastLvl;
    public bool isDayTime;
    public bool victory;

    public new GameObject light;
    public GameObject waterBarrierForShader; //se debe cambiar por un mesh renderer
    public Light day;


    static public event Action<string, bool> ShowEndGame;
    static public event Action StopUIInteractions;

    [SerializeField] private Animator dayCycle;
    private uint gameManagerMusicID;
    private LevelManager lvl;

    static public GameManager instance;
    static public GameManager GetInstance { get { return instance; } }
    public bool finishDay { get; set; }
    public bool finishNight { get; set; }
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
        lvl = FindObjectOfType<LevelManager>();
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney;
        WaveSpawner.SetStateDayAnim += DayCycle;
        LevelManager.SetDayOn += DayCycle;
        LevelManager.SetNightOn += DayCycle;
        LevelManager.FinishLastLevel += Victory;
        UIManager.SendPauseGame += PauseGame;
        isDayTime = true;
        dayCycle.SetBool("startDay", true);
        dayCycle.SetBool("isDay", false);
        PauseGame("unpause");
        gameManagerMusicID = AkSoundEngine.PostEvent("play_gamestart", this.gameObject);
    }

    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        WaveSpawner.SetStateDayAnim -= DayCycle;
        LevelManager.SetDayOn -= DayCycle;
        LevelManager.SetNightOn -= DayCycle;
        LevelManager.FinishLastLevel -= Victory;
        UIManager.SendPauseGame -= PauseGame;
        StopMusic();
    }

    public void ActivateDayLight()
    {
        if (!light.activeInHierarchy && !isDayTime)
        {
            light.SetActive(true);
            waterBarrierForShader.SetActive(true);
        }
        if (light.activeInHierarchy && isDayTime)
        {
            light.SetActive(false);
            waterBarrierForShader.SetActive(false);
        }
    }

    public int GetMoney()
    {
        return money;
    }
    public void SubtractMoney(int price)
    {
        money = money - price;
    }
    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }
    public int GetLives()
    {
        return lives;
    }
    public void SubtractLives()
    {
        lives--;
        gameManagerMusicID = AkSoundEngine.PostEvent("level_player_lifedecrease", this.gameObject);
        if (lives <= 0)
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
        victory = false;
        ShowEndGame?.Invoke("defeat", victory);       
        StopUIInteractions?.Invoke();
    }

    private void DayCycle(string state)
    {
        if (state == "Day")
        {
            isDayTime = true;
            dayCycle.SetBool("isDay", true);
            StartCoroutine(WaitForDayAnim(state));
            ActivateDayLight();
        }
        else
        {
            isDayTime = false;
            dayCycle.SetBool("isDay", false);
            StartCoroutine(WaitForDayAnim(state));
            ActivateDayLight();
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

    public void StopMusic()
    {
        AkSoundEngine.StopPlayingID(gameManagerMusicID);
    }

    public void PauseGame(string state)
    {
        if (state == "pause")
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Victory()
    {
        victory = true;
        ShowEndGame?.Invoke("victory", victory);
        Debug.Log("Cambia de escena a creditos, termino el game");
        StopUIInteractions?.Invoke();
    }

}
