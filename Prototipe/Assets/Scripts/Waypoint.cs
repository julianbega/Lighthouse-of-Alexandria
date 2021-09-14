using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Waypoint> Targets;
    public List<bool> openPath;

    private void Start()
    {
        for (int i = 0; i <= Targets.Count; i++)
        {
            openPath.Add(false);
        }
    }
}
