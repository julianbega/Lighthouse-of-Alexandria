using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public Levels lvl;
    public WaveSpawnerProto3 ws;
    public TextMeshProUGUI money;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI lives;
    public Light Light;
    public Light day;
    public Image Cheats;
    public Image CheatsButtonImage;    
    public TextMeshProUGUI CheatsText;
    public Button CheatsButton;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ws = FindObjectOfType<WaveSpawnerProto3>();
        lvl = FindObjectOfType<Levels>();
    }


    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + gm.GetMoney();
        wave.text = "Wave: " + ws.GetWaveCount();
        lives.text = "Lives: " + gm.GetLives();

    }

    public void LightOn()
    {
        Light.enabled = true;
    }

    public void Lightoff()
    {
        Light.enabled = false;
    }

    public void StartDay()
    {
        day.enabled = true;
    }

    public void finishDay()
    {
        day.enabled = false;
    }
    public void ShowCheats()
    {
        Cheats.enabled = true;
        CheatsText.enabled = true;
        CheatsButton.enabled = true;
        CheatsButtonImage.enabled = true;
    }
    public void HideCheats()
    {
        Cheats.enabled = false;
        CheatsText.enabled = false;
        CheatsButton.enabled = false;
        CheatsButtonImage.enabled = false;
    }
}
