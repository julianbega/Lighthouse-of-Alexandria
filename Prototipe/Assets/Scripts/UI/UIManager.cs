using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public bool npcsOn;
    public LevelManager levels;
    public TextMeshProUGUI money;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI level;
    public Image cheats;
    public Image cheatsButtonImage;    
    public TextMeshProUGUI cheatsText;
    public Button closeCheatsButton;
    public GameObject npc;
    public TextMeshProUGUI npcDialoge;
    public Image npcImage;
    public Image dialogeBackground;
    public GameObject startWave;
    public GameObject pauseGO;
    public GameObject endGameGO;
    public TextMeshProUGUI endGameText;

    public static event Action ChangeAllNodesToStartColor;
    public static event Action<int> InteractionWithUI;
    public static event Action<string> SendPauseGame;
       
    public string gameFirstDialoge;
    public NPC_SO gameFirstDialogeNPC;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject cheatsButton;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        levels = FindObjectOfType<LevelManager>();
        LevelManager.ShowNPCs += NPCTalk;
        NPCTalk(gameFirstDialogeNPC, gameFirstDialoge);
        GameManager.ShowEndGame += ShowEndGameSign;
        GameManager.StopUIInteractions += StopInteractions;
        endGameGO.SetActive(false);
        Node.OpenShop += SendInteractionWithUIEvent;
        Turret.OpenUpgradeSystem -= SendInteractionWithUIEvent;
        Library.OpenLibrary += SendInteractionWithUIEvent;
        Turret.OpenUpgradeSystem += SendInteractionWithUIEvent;
    }
    private void OnDisable()
    {
        LevelManager.ShowNPCs -= NPCTalk;
        GameManager.ShowEndGame -= ShowEndGameSign;
        GameManager.StopUIInteractions -= StopInteractions;
        Node.OpenShop -= SendInteractionWithUIEvent;
        Turret.OpenUpgradeSystem -= SendInteractionWithUIEvent;
        Library.OpenLibrary -= SendInteractionWithUIEvent;
        Turret.OpenUpgradeSystem -= SendInteractionWithUIEvent;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Dinero: " + gm.GetMoney();
        lives.text = "Vidas: " + gm.GetLives();
        
        if (levels.actualLvl > 0)
        { 
            if(gm.isDayTime )
            {
                level.text = "Dia " + (levels.actualLvl+1);
            }
            else { level.text = "Noche " + (levels.actualLvl); }
        }
        else
        {
            if (gm.isDayTime)
            {
                level.text = "Dia 1 ";
            }
            else { level.text = "Noche 1 "; }
        }
    }
    
    public void ShowCheats()
    {
        cheats.enabled = true;
        cheatsText.enabled = true;
        closeCheatsButton.enabled = true;
        cheatsButtonImage.enabled = true;
    }
    public void HideCheats()
    {
        cheats.enabled = false;
        cheatsText.enabled = false;
        closeCheatsButton.enabled = false;
        cheatsButtonImage.enabled = false;
    }
    public void SetAllNodesDefaultColor()
    {
        ChangeAllNodesToStartColor?.Invoke();
    }
    public void ShowPauseBtn()
    {
        pauseButton.SetActive(true);
    }

    public void HidePauseBtn()
    {
        pauseButton.SetActive(false);
    }

    private void NPCTalk(NPC_SO npc, string Dialoge)
    {
        if (npcsOn)
        {
            if (npc.npc_name != "none")
            {
                this.npc.SetActive(true);
                HideStartWave();
                HidePauseBtn();
            }
            npcImage.sprite = npc.image;
            dialogeBackground.sprite = npc.background;
            npcDialoge.text = Dialoge;
        }
    }

    public void CloseNPCTalk()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            npc.SetActive(false);
        ShowPauseBtn();
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            startWave.SetActive(false);
            pauseGO.SetActive(true);
            SendPauseGame?.Invoke("pause");
            AkSoundEngine.SetState("pausemenu ", "pause");
        }
        else
        {
            if (!gm.day.isActiveAndEnabled)
            {
            }
            Debug.Log("despausa");
            startWave.SetActive(true);
            pauseGO.SetActive(false);
            SendPauseGame?.Invoke("unpause");
            AkSoundEngine.SetState("pausemenu ", "nopause");
        }
    }
    public void HideStartWave()
    {
        startWave.SetActive(false);
    }
    public void ShowStartWave()
    {
        startWave.SetActive(true);
    }

    public void ShowEndGameSign()
    {
        Time.timeScale = 0;
        endGameGO.SetActive(true);
        if (gm.victory)
        {
            endGameText.text = "Victoria";
        }
        else 
        {
            endGameText.text = "Derota";
        }
    }

    public void SendInteractionWithUIEvent(int index)
    {
        if (Time.timeScale == 1)
            InteractionWithUI?.Invoke(index);
        else
            Debug.Log("No se puede interactuar, pausa!!");
    }

    private void StopInteractions()
    {
        HidePauseBtn();
        cheatsButton.SetActive(false);
        Time.timeScale = 0;
    }
}
