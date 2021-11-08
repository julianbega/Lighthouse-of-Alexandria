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
    public TextMeshProUGUI actualInvestigation;
    public Image icon;
    private GameManager gm;
    public Library library;
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
            actualInvestigation.text = "No hay ninguna investigacion en curso";
        }
        if(investigationInProgress != NOInvestigation)
        {
            actualInvestigation.text = "Investigando " + investigationInProgress.name + " " + timeToEndInvestigation +" dias para finalizar";
        }
        else 
        {
            actualInvestigation.text = "No hay ninguna investigacion en curso";
        }
        if (timeToEndInvestigation <= 0 && investigationInProgress != NOInvestigation)
        {
            if(investigationInProgress.name == "Archer tower")
            {
                UnlockTurret(1);
            }
            else if (investigationInProgress.name == "Canon tower")
            {
                UnlockTurret(3);
            }
            else if (investigationInProgress.name == "Harpoon tower")
            {
                UnlockTurret(2);
            }
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
    private void UnlockTurret(int index)
    {
        library.turretUnlocked[index] = true;
    }

}
