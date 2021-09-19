using UnityEngine;

public class UIUpgradeSystem : MonoBehaviour
{
    public GameObject upgradeSystemPanel;
    [SerializeField] private UIManager uiManager;
    void Start()
    {
        Turret.OpenUpgradeSystem += ActivateUpgradeSystemPanel;
    }

    void Update()
    {
        
    }

    private void ActivateUpgradeSystemPanel()
    {
        upgradeSystemPanel.SetActive(true);
        uiManager.CanOpenShopFalse();
        uiManager.CanOpenLibraryFalse();
    }

    public void DisableUpgradeSystemPanel()
    {
        upgradeSystemPanel.SetActive(false);
        uiManager.CanOpenShopTrue();
        uiManager.CanOpenLibraryTrue();
    }

    private void OnDisable()
    {
        Turret.OpenUpgradeSystem -= ActivateUpgradeSystemPanel;
    }
}
