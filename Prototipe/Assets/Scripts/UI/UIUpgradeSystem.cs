using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class UIUpgradeSystem : MonoBehaviour
{
    public List<Button> upgradesButton = new List<Button>();
    public GameObject upgradeStore;
    private Camera cam;
    public List<Investigation_SO> lvl1UpgradeInvestigations;
    public List<Investigation_SO> lvl2UpgradeInvestigations;
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
            StartCoroutine(Wait());
            Turret thisTurret = ConstructionManager.instance.selectedTurret;
            upgradeStore.gameObject.SetActive(true);
            switch (ConstructionManager.instance.selectedTurret.turretLvl)
            {
                case 1:
                    for (int i = 0; i < lvl1UpgradeInvestigations.Count; i++)
                    {
                        if (lvl1UpgradeInvestigations[i].allreadyInvestigated)
                        {
                            upgradesButton[i].gameObject.SetActive(true);
                            upgradesButton[i].image.sprite = lvl1UpgradeInvestigations[i].image;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < lvl2UpgradeInvestigations.Count; i++)
                    {
                        if (lvl1UpgradeInvestigations[i].allreadyInvestigated)
                        {
                            upgradesButton[i].gameObject.SetActive(true);
                            upgradesButton[i].image.sprite = lvl2UpgradeInvestigations[i].image;
                        }
                    }

                    break;
                default:
                    break;
            }
        }
        else
            CloseUpShop();
    }
    public void CloseUpShop()
    {
        upgradeStore.gameObject.SetActive(false);
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
                        ConstructionManager.instance.selectedTurret.power ++;
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
