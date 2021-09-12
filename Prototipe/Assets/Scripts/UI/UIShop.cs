using UnityEngine;

public class UIShop : MonoBehaviour
{
    public GameObject ShopPanel;
    public Vector3 offset;
    private GameManager gm;
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

    private void ActivateShopPanel()
    {
        ShopPanel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        Node.OpenShop -= ActivateShopPanel;
    }
}
