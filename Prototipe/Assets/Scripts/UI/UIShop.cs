using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIShop : MonoBehaviour
{
    public GameObject ShopPanel;
    public Vector3 offset;
    private GameManager gm;
    public Library library;
    public List<GameObject> turrets = new List<GameObject>();
    public List<GameObject> buyTurretButtons = new List<GameObject>();
    public List<TMP_Text> statsTurrets = new List<TMP_Text>();
    public UIManager uiManager;
    public List<Turret> turretComponent = new List<Turret>();

    public static Action changeActualNode;

    public object EventSystemManager { get; private set; }

    void Start()
    {
        Node.OpenShop += ActivateShopPanel;
        gm = FindObjectOfType<GameManager>();
        ShowTurretStats(0);
    }

    public void CloseShop()
    {
        ShopPanel.gameObject.SetActive(false);
        uiManager.CanOpenShopTrue();
        uiManager.CanOpenLibraryTrue();
        uiManager.CanOpenUpgradeSystemTrue();
        uiManager.ShowStartWave();
        uiManager.ShowPauseBtn();
        changeActualNode?.Invoke();
    }

    public void BuyTurret1()
    {
       // if (!EventSystem.current.IsPointerOverGameObject())
        //{
            GameObject turretToBuild = BuildManager.instance.turretPrefabs[0];
            if (gm.GetMoney() >= 10)
            {
                BuildManager.instance.actualNode.turret = Instantiate(turretToBuild, BuildManager.instance.actualNode.transform.position + offset, transform.rotation);
                gm.moneySubtract(10);
            }
        //}   
    }

    public void BuyTurret2()
    {
        GameObject turretToBuild = BuildManager.instance.turretPrefabs[1];
        if (gm.GetMoney() >= 10)
        {
            BuildManager.instance.actualNode.turret = Instantiate(turretToBuild, BuildManager.instance.actualNode.transform.position + offset, transform.rotation);
            gm.moneySubtract(10);
        }
    }

    public void BuyTurret3()
    {
        GameObject turretToBuild = BuildManager.instance.turretPrefabs[2];
        if (gm.GetMoney() >= 10)
        {
            BuildManager.instance.actualNode.turret = Instantiate(turretToBuild, BuildManager.instance.actualNode.transform.position + offset, transform.rotation);
            gm.moneySubtract(10);
        }
    }

    public void BuyTurret4()
    {
        GameObject turretToBuild = BuildManager.instance.turretPrefabs[3];
        if (gm.GetMoney() >= 10)
        {
            BuildManager.instance.actualNode.turret = Instantiate(turretToBuild, BuildManager.instance.actualNode.transform.position + offset, transform.rotation);
            gm.moneySubtract(10);
        }
    }

    public void ShowTurret()
    {
        for(int i = 0; i < turrets.Count; i++)
        {
            if (library.turretUnlocked[i] && !turrets[i].gameObject.activeSelf)
            {
                turrets[i].gameObject.SetActive(true);
                buyTurretButtons[i].gameObject.SetActive(true);
                statsTurrets[i].gameObject.SetActive(true);
                ShowTurretStats(i);
            }
        }   
    }

    private void ShowTurretStats(int index)
    {
        statsTurrets[index].text = "Attack per second: " + turretComponent[index].attacksPerSecond + "\n"
            + "Power: " + turretComponent[index].power + "\n"
            + "Range: " + turretComponent[index].range;
    }

    private void ActivateShopPanel()
    {
        ShowTurret();
        if(uiManager.canOpenShop)
            ShopPanel.gameObject.SetActive(true);
        //uiManager.CanOpenShopFalse();
        uiManager.CanOpenLibraryFalse();
        uiManager.CanOpenUpgradeSystemFalse();
        uiManager.HideCheats();
        uiManager.HidePauseBtn();
        uiManager.HideStartWave();
    }

    private void OnDisable()
    {
        Node.OpenShop -= ActivateShopPanel;
    }
}
