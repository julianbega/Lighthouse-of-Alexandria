using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "ScriptableObjects/NPCScriptableObject", order = 1)]
public class NPC_SO : ScriptableObject
{
    public string NPC_name;
    public Sprite image;
    public Sprite background;
}
