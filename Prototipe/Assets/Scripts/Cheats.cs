using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cheats : MonoBehaviour
{
    private GameManager gm;

    public int MoneyToAdd;
    public int LivesToAdd;

    static public event Action increaseEnemySpeed;
    void Start()
    {
        gm = GetComponent<GameManager>();
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            increaseEnemySpeed?.Invoke();
        }
    }
}
