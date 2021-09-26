using TMPro;
using UnityEngine;

public class UIUpgradeSystem : MonoBehaviour
{
    public GameObject upgradeSystemPanel;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TMP_Text selectedTurretStats;
    void Start()
    {
        Turret.OpenUpgradeSystem += ActivateUpgradeSystemPanel;
        Turret.SelectedTurret += ShowTurretStats;
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

    private void ShowTurretStats(Turret selectedTurret)
    {
        selectedTurretStats.text = "Attacks per second: " + selectedTurret.attacksPerSecond 
            + "\n" + "Power: " + selectedTurret.power 
            + "\n" + "Range: " + selectedTurret.range;
    }

    private void OnDisable()
    {
        Turret.OpenUpgradeSystem -= ActivateUpgradeSystemPanel;
        Turret.SelectedTurret -= ShowTurretStats;
    }
}
