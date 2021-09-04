using UnityEngine;

public class UIShop : MonoBehaviour
{
    public GameObject ShopPanel;
    void Start()
    {
        Node.OpenShop += ActivateShopPanel;
    }

    void Update()
    {
        
    }

    public void CloseShop()
    {
        ShopPanel.gameObject.SetActive(false);
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
