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
    private UIManager uiManager;
    private Transform node;
    private Camera cam;
    public static Action changeActualNode;
    public object EventSystemManager { get; private set; }
    private const int indexToActivate = 1;

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
        if (shopPanel.gameObject.activeSelf)
        {
            shopPanel.gameObject.SetActive(false);
            //CursorController.instanceCursorController.ActivateNormalCursor();
            uiManager.ShowStartWave();
            uiManager.ShowPauseBtn();
            changeActualNode?.Invoke();
        }
    }

    public void BuyTurret(int index)
    {
        if (ConstructionManager.instance.buildAvailable == true)
        {
            float turretPrice = ConstructionManager.instance.turretPrefabs[index].GetComponent<Turret>().price;
            GameObject turretToBuild = ConstructionManager.instance.turretPrefabs[index];
            if (gm.GetMoney() >= turretPrice)
            {
                ConstructionManager.instance.actualNode.turret = Instantiate(turretToBuild, ConstructionManager.instance.actualNode.transform.position + offset, transform.rotation);
                gm.SubtractMoney((int)turretPrice);
                AkSoundEngine.PostEvent("level_towerbuilding", this.gameObject);
            }
            else
            {
                AkSoundEngine.PostEvent("ui_button_nomoney", this.gameObject);
            }
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

    private void ActivateShopPanel(int index)
    {
        if (uiManager != null)
        {
            if (index == indexToActivate && !uiManager.npc.activeSelf)
            {
                shopPanel.gameObject.SetActive(true);
                //CursorController.instanceCursorController.ActivateNormalCursor();
                //CursorController.instanceCursorController.ActivateConstructionCursor();
                ShowTurret();
                Time.timeScale = 1;
                StartCoroutine(Wait());
            }
            else
                CloseShop();
            //uiManager.HideCheats();
            //uiManager.HidePauseBtn();
            //uiManager.HideStartWave();
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
