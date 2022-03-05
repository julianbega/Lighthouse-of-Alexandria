using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;


[System.Serializable]
public class ListWrapper
{
    public List<Investigation_SO> myUpgradesInTowerLevel;
}
public class UIUpgradeSystem : MonoBehaviour
{
    public List<Button> upgradesButton = new List<Button>();
    public GameObject upgradeStore;
    private Camera cam;
    
    public List<ListWrapper> upgradeInvestigationPerLvl;
   
    private UIManager uiManager;
    private const int indexToActivate = 2;
    void Start()
    {
        //Turret.OpenUpgradeShop += OpenUpShop;
        UIManager.InteractionWithUI += OpenUpShop;
        cam = Camera.main;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
    }

    public void OpenUpShop(int index)
    {
        if (index == indexToActivate)
        {
            for (int i = 0; i < upgradesButton.Count; i++)
            {
                upgradesButton[i].gameObject.SetActive(false);
            }

            Debug.Log("abre tienda de upgrades");
            //CursorController.instanceCursorController.ActivateNormalCursor();
            //CursorController.instanceCursorController.ActivateUpgradeCursor();
            StartCoroutine(Wait());
            Turret thisTurret = ConstructionManager.instance.selectedTurret;
            upgradeStore.gameObject.SetActive(true);

            uiShopUpdate(ConstructionManager.instance.selectedTurret.turretLvl);
        }
        else
            CloseUpShop();
    }
    public void CloseUpShop()
    {
        upgradeStore.gameObject.SetActive(false);
        //CursorController.instanceCursorController.ActivateNormalCursor();
        uiManager.ShowStartWave();
        uiManager.ShowPauseBtn();
    }
    public void UpgradeTurret(int index)
    {
        switch (ConstructionManager.instance.selectedTurret.turretLvl)
        {
            case 1:
                switch (index)
                {
                    case 0:
                        //LookOut
                        ConstructionManager.instance.selectedTurret.alarm = true;
                        break;
                    case 1:
                        //AttackSpeed

                        ConstructionManager.instance.selectedTurret.attacksPerSecond++;
                        break;
                    case 2:
                        //DamageUp
                        ConstructionManager.instance.selectedTurret.power++;
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (index)
                {
                    case 0:
                        //Fire
                        ConstructionManager.instance.selectedTurret.fireProyectiles = true;
                        AkSoundEngine.PostEvent("ui_button_buttonupgrade_fire", this.gameObject);
                        break;
                    case 1:
                        //Pen
                        ConstructionManager.instance.selectedTurret.penetrationProyectiles = true;
                        break;
                    case 2:
                        //Slow
                        ConstructionManager.instance.selectedTurret.slowProyectiles = true;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        ConstructionManager.instance.selectedTurret.turretLvl++;
        AkSoundEngine.PostEvent("ui_button_buttonupgrade", this.gameObject);
        CloseUpShop();
    }


    public void uiShopUpdate(int turretLvl)
    {
        int index = turretLvl - 1;
        for (int i = 0; i < upgradeInvestigationPerLvl[index].myUpgradesInTowerLevel.Count; i++)
        {
            if (upgradeInvestigationPerLvl[index].myUpgradesInTowerLevel[i].allreadyInvestigated)
            {
                upgradesButton[i].gameObject.SetActive(true);
                upgradesButton[i].image.sprite = upgradeInvestigationPerLvl[index].myUpgradesInTowerLevel[i].image;
            }
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        upgradeStore.transform.position = cam.WorldToScreenPoint(ConstructionManager.instance.selectedTurret.gameObject.transform.position);
    }

    private void OnDisable()
    {
        //Turret.OpenUpgradeShop -= OpenUpShop;
        UIManager.InteractionWithUI -= OpenUpShop;
    }
}
