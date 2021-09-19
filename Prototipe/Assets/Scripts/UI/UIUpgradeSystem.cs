using UnityEngine;

public class UIUpgradeSystem : MonoBehaviour
{
    public GameObject upgradeSystemPanel;
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
    }

    public void DisableUpgradeSystemPanel()
    {
        upgradeSystemPanel.SetActive(false);
    }

    private void OnDisable()
    {
        Turret.OpenUpgradeSystem -= ActivateUpgradeSystemPanel;
    }
}
