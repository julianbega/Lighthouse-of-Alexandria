using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int money;
    public int lives;  

    public new GameObject light;
    public GameObject waterBarrierForShader; //se debe cambiar por un mesh renderer
    public Light day;
    public bool finishDay { get; set; }
    public bool finishNight { get; set; }
    public bool isDayTime;
    public int lastLvl;
    private LevelManager lvl;

    public bool victory;
    static public event Action<string, bool> ShowEndGame;
    static public event Action StopUIInteractions;

    [SerializeField] private Animator dayCycle;
    [SerializeField] [Range(0.0f, 1.0f)] float lerpTime;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject defeatPanel;
    private uint gameManagerMusicID;

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
        lvl = FindObjectOfType<LevelManager>();
        Enemy.SubtractLives += SubtractLives;
        Enemy.GainMoney += AddMoney;
        //Levels.SetNightOn += SetNight;
        //Levels.SetDayOn += SetDay;
        //Node.GetMoney += getMoney;
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
        //waterBarrierForShader.material.color = startColor;
    }

    private void OnDisable()
    {
        Enemy.SubtractLives -= SubtractLives;
        Enemy.GainMoney -= AddMoney;
        //Levels.SetNightOn -= SetNight;
        //Levels.SetDayOn -= SetDay;
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
            waterBarrierForShader.SetActive(true); // llamar a la corrutina que lo pasa de transparente a negro
            //StartCoroutine(WaterChangeColor(startColor, endColor));
        }
        if (light.activeInHierarchy && isDayTime)
        {
            light.SetActive(false);
            waterBarrierForShader.SetActive(false);// llamar a la crutina que lo pasa de negro a transparente
            //StartCoroutine(WaterChangeColor(endColor, startColor));
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
        ShowEndGame?.Invoke("defeat", victory);
        //ScenesManager.instanceScenesManager.ChangeScene("Credits");
        //if(defeatPanel != null)
        //    defeatPanel.SetActive(true);
        //gameManagerMusicID = AkSoundEngine.PostEvent("play_music_defeat", this.gameObject);
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
        ShowEndGame?.Invoke("victory", victory);
        Debug.Log("Cambia de escena a creditos, termino el game");
        //if (victoryPanel != null)
        //    victoryPanel.SetActive(true);
        //gameManagerMusicID = AkSoundEngine.PostEvent("play_music_victory", this.gameObject);
        //ScenesManager.instanceScenesManager.ChangeScene("Credits");
        StopUIInteractions?.Invoke();
    }

    //public IEnumerator WaterChangeColor(Color startColor, Color endColor)
    //{
    //    yield return new WaitForSeconds(0.02f);
    //    waterBarrierForShader.material.color = Color.Lerp(startColor, endColor, lerpTime);
    //    yield return null;
    //}
}
