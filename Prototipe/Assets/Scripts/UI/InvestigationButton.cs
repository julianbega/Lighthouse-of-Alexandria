using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestigationButton : MonoBehaviour
{
   public Investigation_SO so;
   public Image color;
    public Color openToInvestigate;
    public Color ready;
    public Color locked;
    void Update()
    {
        if (so.previousInvestigation != null)
        {
            if (so.previousInvestigation.allreadyInvestigated)
            {
                if(so.allreadyInvestigated)
                {
                    color.color = ready;
                }
                else 
                {
                    color.color = openToInvestigate;
                }
            }
            else
            {
                color.color = locked;
            }
        }
    }
}
