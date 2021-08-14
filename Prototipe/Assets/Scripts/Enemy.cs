using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public int wavePointIndex;
    private void Start()
    {
        wavePointIndex = 0;
        target = Waypoints.enemyMovmentPoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            SetNextTarget();
        }
    }

    void SetNextTarget()
    {
        if (wavePointIndex >= Waypoints.enemyMovmentPoints.Length -1)
        {
            Destroy(this.gameObject);
            return;
        }
        if (wavePointIndex < Waypoints.enemyMovmentPoints.Length)
        {
            wavePointIndex++;
        }
        target = Waypoints.enemyMovmentPoints[wavePointIndex];
    }
}
