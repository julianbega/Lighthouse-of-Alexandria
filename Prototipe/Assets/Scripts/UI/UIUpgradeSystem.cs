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
            ConstructionManager.instance.selectedTurret.attacksPerSecond += attacksPerSecondsUpgradeValue;
        else if (attribute == "power")
            ConstructionManager.instance.selectedTurret.power += powerUpgradeValue;
        else if (attribute == "range")
            ConstructionManager.instance.selectedTurret.range += rangeUpgradeValue;
    }

    private void ActivateUpgradeSystemPanel()
    {
        if(uiManager.canOpenUpgradeSystem)
            upgradeSystemPanel.SetActive(true);
        uiManager.CanOpenShopFalse();
        uiManager.CanOpenLibraryFalse();
        uiManager.HidePauseBtn();
        uiManager.HideStartWave();
        ShowTurretStats();
    }

    public void DisableUpgradeSystemPanel()
    {
        upgradeSystemPanel.SetActive(false);
        uiManager.CanOpenShopTrue();
        uiManager.CanOpenLibraryTrue();
        uiManager.CanOpenUpgradeSystemTrue();
        uiManager.ShowPauseBtn();
        uiManager.ShowStartWave();
        changeActualNode?.Invoke();
    }

    public void ShowTurretStats()
    {
        if(ConstructionManager.instance.selectedTurret != null)
            selectedTurretStats.text = "Attacks per second: " + ConstructionManager.instance.selectedTurret.attacksPerSecond 
                + "\n" + "Power: " + ConstructionManager.instance.selectedTurret.power 
                + "\n" + "Range: " + ConstructionManager.instance.selectedTurret.range;
    }

    private void OnDisable()
    {
        Turret.OpenUpgradeSystem -= ActivateUpgradeSystemPanel;
        //Turret.SelectedTurret -= ShowTurretStats;
        //Turret.SelectedTurret -= SetSelectedTurret;
    }
}
