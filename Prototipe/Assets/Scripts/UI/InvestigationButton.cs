using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestigationButton : MonoBehaviour
{
   public Investigation_SO so;
   public Image color;
    public Color OpenToInvestigate;
    public Color Ready;
    public Color Locked;
    void Update()
    {
        if (so.previousInvestigation != null)
        {
            if (so.previousInvestigation.AllreadyInvestigated)
            {
                if(so.AllreadyInvestigated)
                {
                    color.color = Ready;
                }
                else 
                {
                    color.color = OpenToInvestigate;
                }
            }
            else
            {
                color.color = Locked;
            }
        }
    }
}
