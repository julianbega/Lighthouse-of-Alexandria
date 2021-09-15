using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public Levels lvl;
    private NPCsImages npcs;
    public WaveSpawnerProto3 ws;
    public TextMeshProUGUI money;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI lives;
    public Image Cheats;
    public Image CheatsButtonImage;    
    public TextMeshProUGUI CheatsText;
    public Button CheatsButton;
    public bool canOpenShop;
    public GameObject NPC;
    public TextMeshProUGUI NPCDialoge;
    public Image NPCImage;
    public Image DialogeBackground;
    public GameObject startWave;
    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        ws = FindObjectOfType<WaveSpawnerProto3>();
        lvl = FindObjectOfType<Levels>();
        npcs = FindObjectOfType<NPCsImages>();
        Levels.ShowNPCs += NPCTalk;
    }
    private void OnDisable()
    {
        Levels.ShowNPCs -= NPCTalk;
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

    private void NPCTalk(int npcIndex, string Dialoge)
    {
        Debug.Log("Llega a la parte de UI");
        if (npcIndex != 0)
        {
            NPC.SetActive(true);
            HideStartWave();
            CanOpenShopFlase();
        }
        NPCImage.sprite = npcs.SelectNPC(npcIndex);
        DialogeBackground.sprite = npcs.SelectTextBackground(npcIndex);
        NPCDialoge.text = Dialoge;
    }

    public void CloseNPCTalk()
    {
        NPC.SetActive(false);
    }

    public void HideStartWave()
    {
        startWave.SetActive(false);
    }
    public void ShowStartWave()
    {
        startWave.SetActive(true);
    }
}
