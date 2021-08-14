using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] enemyMovmentPoints;

    private void Awake()
    {
        enemyMovmentPoints = new Transform[transform.childCount];
        for (int i = 0; i < enemyMovmentPoints.Length; i++)
        {
            enemyMovmentPoints[i] = transform.GetChild(i);
        }
    }
}
