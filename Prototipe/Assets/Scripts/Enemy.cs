using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public int wavePointIndex;
    private GameManager gm;

    public static Action SubtractLives;
    private void Start()
    {
        gm = GetComponent<GameManager>();
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
            SubtractLives?.Invoke();
            return;
        }
        if (wavePointIndex < Waypoints.enemyMovmentPoints.Length)
        {
            wavePointIndex++;
        }
        target = Waypoints.enemyMovmentPoints[wavePointIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            Destroy(this.gameObject);
    }
}
