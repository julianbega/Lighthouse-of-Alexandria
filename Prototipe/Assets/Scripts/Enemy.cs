﻿using System.Collections;
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
    static public event Action DestroyCannonBall;

    [Header("LivesColor")]
    private MeshRenderer renderer;
    public Material hp1;
    public Material hp2;
    public Material hp3;
    public Material hp4;
    private void Start()
    {
        switch (life)
        {
            case 4:
                renderer.material = hp4;
                break;
            case 3:
                renderer.material = hp3;
                break;
            case 2:
                renderer.material = hp2;
                break;
            case 1:
                renderer.material = hp1;
                break;
            default:
                break;
        }

        renderer = this.gameObject.GetComponent<MeshRenderer>();
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
            DestroyCannonBall?.Invoke();
            life -= bullet.damage;           
            
            switch (life)
            {
                case 3:
                    renderer.material = hp3;
                    speed += 5;
                    break;
                case 2:
                    renderer.material = hp2;
                    speed += 5;
                    break;
                case 1:
                    renderer.material = hp1;
                    speed += 5;
                    break;
                default:
                    break;
            }
            if(life <= 0)
            { 
                Destroy(this.gameObject);
                GainMoney?.Invoke();
                EnemyDie?.Invoke();
            }
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
