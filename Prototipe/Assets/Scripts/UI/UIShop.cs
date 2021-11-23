using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class UIShop : MonoBehaviour
{
    public RectTransform shopPanel;
    public Vector3 offset;
    private GameManager gm;
    public Library library;
    public List<Button> turrets = new List<Button>();
    public List<GameObject> buyTurretButtons = new List<GameObject>();
    public List<TMP_Text> statsTurrets = new List<TMP_Text>();
    private UIManager uiManager;
    public List<Turret> turretComponent = new List<Turret>();
    private Transform node;
    private Camera cam;
    public static Action changeActualNode;

    public object EventSystemManager { get; private set; }

    void Start()
    {
        cam = Camera.main;
        gm = FindObjectOfType<GameManager>();
        //ShowTurretStats(0);
        uiManager = FindObjectOfType<UIManager>();
        UIManager.InteractionWithUI += ActivateShopPanel;
    }
    private void Update()
    {
        if (ConstructionManager.instance.actualNode != null && ConstructionManager.instance.actualNode != node)
        { 
            node = ConstructionManager.instance.actualNode.transform;
        }
    }

    public void CloseShop()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            shopPanel.gameObject.SetActive(false);
            uiManager.ShowStartWave();
            uiManager.ShowPauseBtn();
            changeActualNode?.Invoke();
        }
    }

    public void BuyTurret(int index)
    {
        float turretPrice = ConstructionManager.instance.turretPrefabs[index].GetComponent<Turret>().price;
        GameObject turretToBuild = ConstructionManager.instance.turretPrefabs[index];
        if (gm.GetMoney() >= turretPrice)
        {
            ConstructionManager.instance.actualNode.turret = Instantiate(turretToBuild, ConstructionManager.instance.actualNode.transform.position + offset, transform.rotation);
            gm.SubtractMoney((int)turretPrice);
            AkSoundEngine.PostEvent("level_towerbuilding", this.gameObject);
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

    private void ActivateShopPanel(int index)
    {
        if (uiManager != null)
        {
            if (index == 0 && !uiManager.npc.activeSelf)
            {
                shopPanel.gameObject.SetActive(true);
                ShowTurret();
                Time.timeScale = 1;
                StartCoroutine(Wait());
            }
            else
                CloseShop();
            uiManager.HideCheats();
            uiManager.HidePauseBtn();
            uiManager.HideStartWave();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        shopPanel.transform.position = cam.WorldToScreenPoint(ConstructionManager.instance.actualNode.gameObject.transform.position);
    }
    private void OnDisable()
    {
        UIManager.InteractionWithUI += ActivateShopPanel;
    }
}
