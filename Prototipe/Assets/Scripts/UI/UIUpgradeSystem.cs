using TMPro;
using UnityEngine;

public class UIUpgradeSystem : MonoBehaviour
{
    public GameObject upgradeSystemPanel;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TMP_Text selectedTurretStats;
    [SerializeField] private int attacksPerSecondsUpgradeValue;
    [SerializeField] private float rangeUpgradeValue;
    [SerializeField] private int powerUpgradeValue;
    private Turret actualTurretToUpgrade;
    void Start()
    {
        Turret.OpenUpgradeSystem += ActivateUpgradeSystemPanel;
        Turret.SelectedTurret += ShowTurretStats;
        Turret.SelectedTurret += SetSelectedTurret;
    }

    void Update()
    {
        ShowTurretStats(actualTurretToUpgrade);
    }

    private void SetSelectedTurret(Turret selectedTurret)
    {
        actualTurretToUpgrade = selectedTurret;
    }

    public void UpgradeTurret(string attribute)
    {
        if (attribute == "attacks")
            actualTurretToUpgrade.attacksPerSecond += attacksPerSecondsUpgradeValue;
        else if (attribute == "power")
            actualTurretToUpgrade.power += powerUpgradeValue;
        else if (attribute == "range")
            actualTurretToUpgrade.range += rangeUpgradeValue;
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
        Turret.SelectedTurret -= SetSelectedTurret;
    }
}
