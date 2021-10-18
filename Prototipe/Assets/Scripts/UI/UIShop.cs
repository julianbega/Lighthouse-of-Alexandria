using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UIShop : MonoBehaviour
{
    public RectTransform ShopPanel;
    public Vector3 offset;
    private GameManager gm;
    public Library library;
    public List<Button> turrets = new List<Button>();
    public List<GameObject> buyTurretButtons = new List<GameObject>();
    public List<TMP_Text> statsTurrets = new List<TMP_Text>();
    public UIManager uiManager;
    public List<Turret> turretComponent = new List<Turret>();
    private Transform node;
    private Camera cam;
    public static Action changeActualNode;

    public object EventSystemManager { get; private set; }

    void Start()
    {
        cam = Camera.main;
        Node.OpenShop += ActivateShopPanel;
        gm = FindObjectOfType<GameManager>();
        ShowTurretStats(0);
    }
    private void Update()
    {
        if (BuildManager.instance.actualNode != null && BuildManager.instance.actualNode != node)
        { 
        node = BuildManager.instance.actualNode.transform;
        }
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
        GameObject turretToBuild = BuildManager.instance.turretPrefabs[0];
        if (gm.GetMoney() >= 10)
        {
            BuildManager.instance.actualNode.turret = Instantiate(turretToBuild, BuildManager.instance.actualNode.transform.position + offset, transform.rotation);
            gm.moneySubtract(10);
        }   
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
        if(uiManager.canOpenShop && !uiManager.NPC.activeSelf)
        {
            ShopPanel.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }
        //uiManager.CanOpenShopFalse();
        uiManager.CanOpenLibraryFalse();
        uiManager.CanOpenUpgradeSystemFalse();
        uiManager.HideCheats();
        uiManager.HidePauseBtn();
        uiManager.HideStartWave();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        ShopPanel.transform.position = cam.WorldToScreenPoint(node.position);
    }
    private void OnDisable()
    {
        Node.OpenShop -= ActivateShopPanel;
    }
}
