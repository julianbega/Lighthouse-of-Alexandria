using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Cheats : MonoBehaviour
{
    private GameManager gm;
    private UIManager UIm;
    public int moneyToAdd;
    public int livesToAdd;
    static public event Action killEnemy;
    void Start()
    {
        gm = GetComponent<GameManager>();
        UIm = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gm.money += moneyToAdd;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gm.money = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gm.lives += livesToAdd;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gm.lives -= 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            killEnemy?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            UIm.npcsOn = !UIm.npcsOn;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype3");
        }
       /* if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }*/
    }
}
