using TMPro;
using UnityEngine;
using System;
public class UIUpgradeSystem : MonoBehaviour
{
    public GameObject upgradeSystemPanel;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TMP_Text selectedTurretStats;
    [SerializeField] private int attacksPerSecondsUpgradeValue;
    [SerializeField] private float rangeUpgradeValue;
    [SerializeField] private int powerUpgradeValue;
    //private Turret actualTurretToUpgrade;

    public static Action changeActualNode;
    void Start()
    {
        Turret.OpenUpgradeSystem += ActivateUpgradeSystemPanel;
        //Turret.SelectedTurret += ShowTurretStats;
        //Turret.SelectedTurret += SetSelectedTurret;
    }

    private void Update()
    {
        ShowTurretStats();
    }

    public void UpgradeTurret(string attribute)
    {
        if (attribute == "attacks")
            BuildManager.instance.selectedTurret.attacksPerSecond += attacksPerSecondsUpgradeValue;
        else if (attribute == "power")
            BuildManager.instance.selectedTurret.power += powerUpgradeValue;
        else if (attribute == "range")
            BuildManager.instance.selectedTurret.range += rangeUpgradeValue;
    }

    private void ActivateUpgradeSystemPanel()
    {
        upgradeSystemPanel.SetActive(true);
        uiManager.CanOpenShopFalse();
        uiManager.CanOpenLibraryFalse();
        ShowTurretStats();
    }

    public void DisableUpgradeSystemPanel()
    {
        upgradeSystemPanel.SetActive(false);
        uiManager.CanOpenShopTrue();
        uiManager.CanOpenLibraryTrue();
        changeActualNode?.Invoke();
    }

    public void ShowTurretStats()
    {
        if(BuildManager.instance.selectedTurret != null)
            selectedTurretStats.text = "Attacks per second: " + BuildManager.instance.selectedTurret.attacksPerSecond 
                + "\n" + "Power: " + BuildManager.instance.selectedTurret.power 
                + "\n" + "Range: " + BuildManager.instance.selectedTurret.range;
    }

    private void OnDisable()
    {
        Turret.OpenUpgradeSystem -= ActivateUpgradeSystemPanel;
        //Turret.SelectedTurret -= ShowTurretStats;
        //Turret.SelectedTurret -= SetSelectedTurret;
    }
}
