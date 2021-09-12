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
    public Image Cheats;
    public Image CheatsButtonImage;    
    public TextMeshProUGUI CheatsText;
    public Button CheatsButton;
    public bool canOpenShop;
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
        wave.text = "Wave: " + lvl.GetActualWave();
        lives.text = "Lives: " + gm.GetLives();

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

    public void CanOpenShopTrue()
    {
        canOpenShop = true;
    }

    public void CanOpenShopFlase()
    {
        canOpenShop = false;
    }
}
