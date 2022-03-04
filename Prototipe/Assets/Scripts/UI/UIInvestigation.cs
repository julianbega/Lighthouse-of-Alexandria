using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIInvestigation : MonoBehaviour
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
    public Image buttonImage;
    public Sprite noInvestigationImage;
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
            if (investigationInProgress.investigationLvl == 0)
            {
                UnlockTurret(investigationInProgress.investigationIndex);
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
        if (timeToEndInvestigation == 0)
        {
            AkSoundEngine.PostEvent("ui_button_researchend", this.gameObject);
            buttonImage.sprite = noInvestigationImage; 
        }
    }
    public void StartInvestigation()
    {
      /*  if (investigationInProgress == noInvestigation)
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
                        AkSoundEngine.PostEvent("ui_button_researchstart", this.gameObject);
                        buttonImage.sprite = selectedInvestigation.image;
                    }
                    else
                    {
                        errorMessage.text = "No hay dinero suficiente";
                        AkSoundEngine.PostEvent("ui_button_nomoney", this.gameObject);

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
        }*/


        if (investigationInProgress != noInvestigation)
        {
            errorMessage.text = "Ya hay una investigacion en curso";
            return;
        }
        if (!selectedInvestigation.previousInvestigation.allreadyInvestigated)
        {
            errorMessage.text = "Es necesaria la investigación previa";
            return;
        }
        if (selectedInvestigation.allreadyInvestigated)
        {
            errorMessage.text = "Esta investigación ya fue realizada";
            return;
        }
        if (gm.money < selectedInvestigation.price)
        {
            errorMessage.text = "No hay dinero suficiente";
            AkSoundEngine.PostEvent("ui_button_nomoney", this.gameObject);
            return;
        }
        investigationInProgress = selectedInvestigation;
        timeToEndInvestigation = investigationInProgress.timeInDays;
        gm.money -= selectedInvestigation.price;
        AkSoundEngine.PostEvent("ui_button_researchstart", this.gameObject);
        buttonImage.sprite = selectedInvestigation.image;
    }




    private void UnlockTurret(int index)
    {
        library.turretUnlocked[index] = true;
    }

}
