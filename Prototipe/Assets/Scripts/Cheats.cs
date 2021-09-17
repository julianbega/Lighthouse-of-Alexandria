using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cheats : MonoBehaviour
{
    private GameManager gm;
    private UIManager UIm;
    public int MoneyToAdd;
    public int LivesToAdd;
    public int speed;

    static public event Action increaseEnemySpeed;
    static public event Action killEnemy;
    void Start()
    {
        speed = 1;
        gm = GetComponent<GameManager>();
        UIm = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gm.money += MoneyToAdd;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gm.money = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gm.lives += LivesToAdd;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gm.lives -= 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            killEnemy?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed ++;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            UIm.npcsOn = !UIm.npcsOn;
        }
    }
}
