using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class UIUpgradeSystem : MonoBehaviour
{
    public List<Button> UpgradesButton = new List<Button>();
    public GameObject UpgradeStore;
    private Camera cam;
    public List<Investigation_SO> lvl1UpgradeInvestigations;
    public List<Investigation_SO> lvl2UpgradeInvestigations;
    void Start()
    {
        Turret.OpenUpgradeShop += OpenUpShop;
        cam = Camera.main;
    }

    private void Update()
    {
    }

    public void OpenUpShop()
    {
        for (int i = 0; i < UpgradesButton.Count; i++)
        {
            UpgradesButton[i].gameObject.SetActive(false);
        }
        
        Debug.Log("abre tienda de upgrades");
        StartCoroutine(Wait());
        Turret thisTurret = ConstructionManager.instance.selectedTurret;
        UpgradeStore.gameObject.SetActive(true);
        switch (ConstructionManager.instance.selectedTurret.turretLvl)
        {
            case 1:
                for (int i = 0; i < lvl1UpgradeInvestigations.Count; i++)
                {
                    if (lvl1UpgradeInvestigations[i].AllreadyInvestigated)
                    {
                        UpgradesButton[i].gameObject.SetActive(true);
                        UpgradesButton[i].image.sprite = lvl1UpgradeInvestigations[i].image;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < lvl2UpgradeInvestigations.Count; i++)
                {
                    if (lvl1UpgradeInvestigations[i].AllreadyInvestigated)
                    {
                        UpgradesButton[i].gameObject.SetActive(true);
                        UpgradesButton[i].image.sprite = lvl2UpgradeInvestigations[i].image;
                    }
                }

                break;
            default:
                break;
        }
    }
    public void CloseUpShop()
    {
        UpgradeStore.gameObject.SetActive(false);
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
        CloseUpShop();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        UpgradeStore.transform.position = cam.WorldToScreenPoint(ConstructionManager.instance.selectedTurret.gameObject.transform.position);
    }

    private void OnDisable()
    {
        Turret.OpenUpgradeShop -= OpenUpShop;
    }




}
