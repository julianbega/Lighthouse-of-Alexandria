using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InvestigationUi : MonoBehaviour
{
    public Investigation_SO selectedInvestigation;
    public List<Investigation_SO> investigations;
    public int timeSinceStartInvestigation;
    public TextMeshProUGUI selectedName;
    public TextMeshProUGUI selectedDescription;
    public TextMeshProUGUI selectedPriceAndTime;
    public Image icon;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void setSelectedInvestigation(Investigation_SO selected)
    {
        selectedInvestigation = selected;
    }
}
