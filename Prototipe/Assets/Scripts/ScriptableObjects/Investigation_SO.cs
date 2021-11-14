using UnityEngine;

[CreateAssetMenu(fileName = "Investigation", menuName = "ScriptableObjects/InvestigationScriptableObject", order = 1)]
public class Investigation_SO : ScriptableObject
{
    public string name;
    public Sprite image;
    public Sprite imageLedge;
    public string description;
    public int price;
    public int timeInDays;
    public bool AllreadyInvestigated;
    public Investigation_SO previousInvestigation;
    public int investigationLvl;
}
