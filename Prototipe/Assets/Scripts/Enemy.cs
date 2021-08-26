using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public int wavePointIndex;
    public bool enlightened;
    public int life;

    public Bullet bullet;
    public static Action SubtractLives;
    public static Action GainMoney;
    static public event Action EnemyDie;
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
            SubtractLives?.Invoke();
            EnemyDie?.Invoke();
            return;
        }
        if (wavePointIndex < Waypoints.enemyMovmentPoints.Length)
        {
            wavePointIndex++;
        }
        target = Waypoints.enemyMovmentPoints[wavePointIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            enlightened = true;
            return;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            life -= bullet.damage;
            GainMoney?.Invoke();
            EnemyDie?.Invoke();
            if(life <= 0)
                Destroy(this.gameObject);
            return;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            enlightened = false;
            return;
        }
    }
}
