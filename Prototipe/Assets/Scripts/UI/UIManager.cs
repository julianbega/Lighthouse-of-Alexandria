using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public bool npcsOn;
    private NPCsImages npcs;
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
    public string gameFirstDialoge;
    public int gameFirstDialogeNPC;
    public GameObject PauseGO;
    public GameObject EndGameGO;
    public TextMeshProUGUI endGameText;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject cheatsButton;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        levels = FindObjectOfType<Levels>();
        npcs = FindObjectOfType<NPCsImages>();
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
        money.text = "Money: " + gm.GetMoney();
        //wave.text = "Wave: " + lvl.GetActualWave();
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

    private void NPCTalk(int npcIndex, string Dialoge)
    {
        if (npcsOn)
        {
            if (npcIndex != 0)
            {
                NPC.SetActive(true);
                Debug.Log("open shop" + canOpenShop);
                Debug.Log("open library" + canOpenLibrary);
                if(canOpenShop && canOpenLibrary)
                {
                    CanOpenShopFalse();
                    CanOpenLibraryFalse();
                }
                HideStartWave();
                HidePauseBtn();
            }
            NPCImage.sprite = npcs.SelectNPC(npcIndex);
            DialogeBackground.sprite = npcs.SelectTextBackground(npcIndex);
            NPCDialoge.text = Dialoge;
        }
    }

    public void CloseNPCTalk()
    {
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
            gm.Light.enabled = false;
            Time.timeScale = 0;
            CanOpenShopFalse();
            CanOpenLibraryFalse();
        }
        else
        {
            if (!gm.day.isActiveAndEnabled)
            {
                gm.Light.enabled = true;
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
