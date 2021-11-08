using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InvestigationUi : MonoBehaviour
{
    public Investigation_SO selectedInvestigation;
    public Investigation_SO NOInvestigation;
    public Investigation_SO investigationInProgress;
    public List<Investigation_SO> investigations;
    public int timeToEndInvestigation;
    public TextMeshProUGUI selectedName;
    public TextMeshProUGUI selectedDescription;
    public TextMeshProUGUI selectedPriceAndTime;
    public Image icon;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        for (int i = 0; i < investigations.Count; i++)
        {
            investigations[i].AllreadyInvestigated = false;
        }
        Levels.aDayEnds += ADayOfInvestigation;
    }

    private void OnDisable()
    {
        Levels.aDayEnds -= ADayOfInvestigation;
    }
    // Update is called once per frame
    void Update()
    {
        if(selectedInvestigation != null)
        {
            selectedName.text = selectedInvestigation.name;
            selectedDescription.text = selectedInvestigation.description;
            selectedPriceAndTime.text = "Price " + selectedInvestigation.price + "  Time" + selectedInvestigation.timeInDays;
            icon.sprite = selectedInvestigation.image;
        }
        else 
        {
            selectedName.text = "";
            selectedDescription.text = "";
            selectedPriceAndTime.text = "";            
        }
        if (timeToEndInvestigation <= 0 && investigationInProgress != NOInvestigation)
        {
            investigationInProgress.AllreadyInvestigated = true;
            investigationInProgress = NOInvestigation;
        }
    }

    public void SetSelectedInvestigation(Investigation_SO selected)
    {
        selectedInvestigation = selected;
    }

    public void ADayOfInvestigation()
    {
        timeToEndInvestigation--;
    }
    public void StartInvestigation()
    {
        Debug.Log("llega a llamar a start investigation");
        if (investigationInProgress == NOInvestigation)
        {
            Debug.Log("Pasa la primera validacion de start investigation");
            if (selectedInvestigation.previousInvestigation.AllreadyInvestigated)
            {
                Debug.Log("Pasa la segunda validacion de start investigation");
                if (gm.money >= selectedInvestigation.price)
                {
                    Debug.Log("Pasa la tercer validacion de start investigation");
                    investigationInProgress = selectedInvestigation;
                    timeToEndInvestigation = investigationInProgress.timeInDays;
                    gm.money -= selectedInvestigation.price;
                }
            }
        }
    }


}
