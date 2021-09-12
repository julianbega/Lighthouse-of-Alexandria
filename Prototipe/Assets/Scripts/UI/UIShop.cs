using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public GameObject ShopPanel;
    public Vector3 offset;
    private GameManager gm;
    public Library library;
    public List<GameObject> turrets = new List<GameObject>();
    public List<GameObject> buyTurretButtons = new List<GameObject>();
    public UIManager uiManager;
    void Start()
    {
        Node.OpenShop += ActivateShopPanel;
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    public void CloseShop()
    {
        ShopPanel.gameObject.SetActive(false);
        uiManager.CanOpenShopTrue();
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
            }
        }   
    }

    private void ActivateShopPanel()
    {
        ShowTurret();
        if(uiManager.canOpenShop)
            ShopPanel.gameObject.SetActive(true);
        uiManager.CanOpenShopFlase();
    }

    private void OnDisable()
    {
        Node.OpenShop -= ActivateShopPanel;
    }
}
