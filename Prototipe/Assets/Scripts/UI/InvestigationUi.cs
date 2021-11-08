using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InvestigationUi : MonoBehaviour
{
    public Investigation_SO selectedInvestigation;
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
        Levels.aDayEnds += aDayOfInvestigation;
    }

    private void OnDisable()
    {
        Levels.aDayEnds -= aDayOfInvestigation;
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
        if (timeToEndInvestigation <= 0)
        {
            investigationInProgress.AllreadyInvestigated = true;
        }
    }

    public void setSelectedInvestigation(Investigation_SO selected)
    {
        selectedInvestigation = selected;
    }

    public void aDayOfInvestigation()
    {
        timeToEndInvestigation--;
    }
    public void startInvestigation()
    {
        investigationInProgress = selectedInvestigation;
        timeToEndInvestigation = investigationInProgress.timeInDays;
    }
}
