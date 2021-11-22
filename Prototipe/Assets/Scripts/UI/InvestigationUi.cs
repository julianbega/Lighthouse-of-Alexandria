using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InvestigationUi : MonoBehaviour
{
    public Investigation_SO selectedInvestigation;
    public Investigation_SO noInvestigation;
    public Investigation_SO investigationInProgress;
    public List<Investigation_SO> investigations;
    public int timeToEndInvestigation;
    public TextMeshProUGUI selectedName;
    public TextMeshProUGUI selectedDescription;
    public TextMeshProUGUI selectedPriceAndTime;
    public TextMeshProUGUI actualInvestigation;
    public TextMeshProUGUI errorMessage;
    public Image icon;
    private GameManager gm;
    public Library library;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        for (int i = 0; i < investigations.Count; i++)
        {
            investigations[i].allreadyInvestigated = false;
        }
        LevelManager.DayEnds += ADayOfInvestigation;
    }

    private void OnDisable()
    {
        LevelManager.DayEnds -= ADayOfInvestigation;
    }
    // Update is called once per frame
    void Update()
    {
        if(selectedInvestigation != null)
        {
            selectedName.text = selectedInvestigation.name;
            selectedDescription.text = selectedInvestigation.description;
            selectedPriceAndTime.text = "Precio " + selectedInvestigation.price + "  Tiempo" + selectedInvestigation.timeInDays;
            icon.sprite = selectedInvestigation.image;
        }
        else 
        {
            selectedName.text = "";
            selectedDescription.text = "";
            selectedPriceAndTime.text = "";
            actualInvestigation.text = "No hay ninguna investigacion en curso";
        }
        if(investigationInProgress != noInvestigation)
        {
            actualInvestigation.text = "Investigando " + investigationInProgress.name + " " + timeToEndInvestigation +" dias para finalizar";
        }
        else 
        {
            actualInvestigation.text = "No hay ninguna investigacion en curso";
        }
        if (timeToEndInvestigation <= 0 && investigationInProgress != noInvestigation)
        {
            if(investigationInProgress.name == "Torre de arqueros")
            {
                UnlockTurret(1);
            }
            else if (investigationInProgress.name == "Torre de cañon")
            {
                UnlockTurret(3);
            }
            else if (investigationInProgress.name == "Torre Escorpion")
            {
                UnlockTurret(2);
            }
            investigationInProgress.allreadyInvestigated = true;
            investigationInProgress = noInvestigation;
        }
    }

    public void SetSelectedInvestigation(Investigation_SO selected)
    {
        selectedInvestigation = selected;
        errorMessage.text = " ";
    }

    public void ADayOfInvestigation()
    {
        timeToEndInvestigation--;
    }
    public void StartInvestigation()
    {
        if (investigationInProgress == noInvestigation)
        {     
            if (selectedInvestigation.previousInvestigation.allreadyInvestigated)
            {
                if (!selectedInvestigation.allreadyInvestigated)
                {
                    if (gm.money >= selectedInvestigation.price)
                    {
                        investigationInProgress = selectedInvestigation;
                        timeToEndInvestigation = investigationInProgress.timeInDays;
                        gm.money -= selectedInvestigation.price;
                    }
                    else
                    {
                        errorMessage.text = "No hay dinero suficiente";
                    }
                }
                else
                {
                    errorMessage.text = "Esta investigación ya fue realizada";
                }
            }
            else
            {
                errorMessage.text = "Es necesaria la investigación previa";
            }    
        }
        else
        {
            errorMessage.text = "Ya hay una investigacion en curso";
        }
    }
    private void UnlockTurret(int index)
    {
        library.turretUnlocked[index] = true;
    }

}
