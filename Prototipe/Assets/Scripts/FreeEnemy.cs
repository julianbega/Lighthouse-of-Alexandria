using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FreeEnemy : MonoBehaviour
{
    public float speed;
    public bool enlightened;

    public static Action SubtractLives;
    public static Action GainMoney;
    static public event Action EnemyDie;
    private void Start()
    {
    }

    private void Update()
    {
       
    }

   void MoveShip()
    {

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
            GainMoney?.Invoke();
            EnemyDie?.Invoke();
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
