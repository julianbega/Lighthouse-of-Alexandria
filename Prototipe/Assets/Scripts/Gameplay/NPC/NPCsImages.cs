using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCsImages : MonoBehaviour
{
    public Sprite TransparentImage;
    public Sprite NPC1;
    public Sprite NPC2;
    public Sprite NPC3;

    public Sprite NPC1Background;
    public Sprite NPC2Background;
    public Sprite NPC3Background;

    public Sprite SelectNPC(int index)
    {
        switch (index)
        {
            case 0:
                return TransparentImage;
            case 1:
                return NPC1;
            case 2:
                return NPC2;
            case 3:
                return NPC3;
            default:
                return TransparentImage;
        }
    }
    public Sprite SelectTextBackground(int index)
    {
        switch (index)
        {
            case 0:
                return TransparentImage;
            case 1:
                return NPC1Background;
            case 2:
                return NPC2Background;
            case 3:
                return NPC3Background;
            default:
                return TransparentImage;
        }
    }
}
