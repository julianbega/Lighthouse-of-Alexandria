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
    public TextMeshProUGUI wave;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI level;
    public Image Cheats;
    public Image CheatsButtonImage;    
    public TextMeshProUGUI CheatsText;
    public Button closeCheatsButton;
    public bool canOpenShop;
    public bool canOpenLibrary;
    public bool canOpenUpgradeSystem;
    public GameObject NPC;
    public TextMeshProUGUI NPCDialoge;
    public Image NPCImage;
    public Image DialogeBackground;
    public GameObject startWave;
    public GameObject PauseGO;
    public GameObject EndGameGO;
    public TextMeshProUGUI endGameText;

    public static event Action ChangeAllNodesToStartColor;
       
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
        canOpenShop = false;
        canOpenLibrary = false;
        canOpenUpgradeSystem = false;
        EndGameGO.SetActive(false);
    }
    private void OnDisable()
    {
        Levels.ShowNPCs -= NPCTalk;
        GameManager.ShowEndGame -= ShowEndGameSign;
        GameManager.StopUIInteractions -= StopInteractions;

    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + gm.GetLives();
        
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
        CanOpenShopFalse();
        CanOpenLibraryFalse();
    }
    public void HideCheats()
    {
        Cheats.enabled = false;
        CheatsText.enabled = false;
        closeCheatsButton.enabled = false;
        CheatsButtonImage.enabled = false;
        CanOpenShopTrue();
        CanOpenLibraryTrue();
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

    public void CanOpenShopTrue()
    {
        canOpenShop = true;
    }

    public void CanOpenLibraryTrue()
    {
        canOpenLibrary = true;
    }

    public void CanOpenShopFalse()
    {
        canOpenShop = false;
    }

    public void CanOpenLibraryFalse()
    {
        canOpenLibrary = false;
    }

    public void CanOpenUpgradeSystemTrue()
    {
        canOpenUpgradeSystem = true;
    }

    public void CanOpenUpgradeSystemFalse()
    {
        canOpenUpgradeSystem = false;
    }

    private void NPCTalk(NPC_SO npc, string Dialoge)
    {
        if (npcsOn)
        {
            if (npc.NPC_name != "none")
            {
                NPC.SetActive(true);
                if(canOpenShop && canOpenLibrary)
                {
                    CanOpenShopFalse();
                    CanOpenLibraryFalse();
                }
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
        CanOpenShopTrue();
        CanOpenLibraryTrue();
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            startWave.SetActive(false);
            PauseGO.SetActive(true);
            Time.timeScale = 0;
            CanOpenShopFalse();
            CanOpenLibraryFalse();
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
            CanOpenShopTrue();
            CanOpenLibraryTrue();
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
            endGameText.text = "Victory";
        }
        else 
        {
            endGameText.text = "Defeat";
        }
    }

    private void StopInteractions()
    {
        CanOpenLibraryFalse();
        CanOpenShopFalse();
        CanOpenUpgradeSystemFalse();
        HidePauseBtn();
        cheatsButton.SetActive(false);
        Time.timeScale = 0;
    }
}
