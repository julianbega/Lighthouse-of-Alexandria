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
    public Levels levels;
    public TextMeshProUGUI money;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI level;
    public Image Cheats;
    public Image CheatsButtonImage;    
    public TextMeshProUGUI CheatsText;
    public Button closeCheatsButton;
    public GameObject NPC;
    public TextMeshProUGUI NPCDialoge;
    public Image NPCImage;
    public Image DialogeBackground;
    public GameObject startWave;
    public GameObject PauseGO;
    public GameObject EndGameGO;
    public TextMeshProUGUI endGameText;

    public static event Action ChangeAllNodesToStartColor;
    public static event Action<int> InteractionWithUI;
       
    public string gameFirstDialoge;
    public NPC_SO gameFirstDialogeNPC;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject cheatsButton;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        levels = FindObjectOfType<Levels>();
        Levels.ShowNPCs += NPCTalk;
        NPCTalk(gameFirstDialogeNPC, gameFirstDialoge);
        GameManager.ShowEndGame += ShowEndGameSign;
        GameManager.StopUIInteractions += StopInteractions;
        EndGameGO.SetActive(false);
        Node.OpenShop += SendInteractionWithUIEvent;
        Turret.OpenUpgradeSystem -= SendInteractionWithUIEvent;
        Library.OpenLibrary += SendInteractionWithUIEvent;
    }
    private void OnDisable()
    {
        Levels.ShowNPCs -= NPCTalk;
        GameManager.ShowEndGame -= ShowEndGameSign;
        GameManager.StopUIInteractions -= StopInteractions;
        Node.OpenShop -= SendInteractionWithUIEvent;
        Turret.OpenUpgradeSystem -= SendInteractionWithUIEvent;
        Library.OpenLibrary -= SendInteractionWithUIEvent;
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
        Cheats.enabled = true;
        CheatsText.enabled = true;
        closeCheatsButton.enabled = true;
        CheatsButtonImage.enabled = true;
    }
    public void HideCheats()
    {
        Cheats.enabled = false;
        CheatsText.enabled = false;
        closeCheatsButton.enabled = false;
        CheatsButtonImage.enabled = false;
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
            if (npc.NPC_name != "none")
            {
                NPC.SetActive(true);
                HideStartWave();
                HidePauseBtn();
            }
            NPCImage.sprite = npc.image;
            DialogeBackground.sprite = npc.background;
            NPCDialoge.text = Dialoge;
        }
    }

    public void CloseNPCTalk()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            NPC.SetActive(false);
        ShowPauseBtn();
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            startWave.SetActive(false);
            PauseGO.SetActive(true);
            Time.timeScale = 0;
            AkSoundEngine.SetState("pausemenu ", "pause");
        }
        else
        {
            if (!gm.day.isActiveAndEnabled)
            {
            }
            Debug.Log("despausa");
            startWave.SetActive(true);
            PauseGO.SetActive(false);
            Time.timeScale = 1;
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
        EndGameGO.SetActive(true);
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
        InteractionWithUI?.Invoke(index);
    }

    private void StopInteractions()
    {
        HidePauseBtn();
        cheatsButton.SetActive(false);
        Time.timeScale = 0;
    }
}
