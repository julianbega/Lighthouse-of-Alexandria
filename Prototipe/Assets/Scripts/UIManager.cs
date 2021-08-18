using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public WaveSpawner ws;
    public TextMeshProUGUI money;
    public TextMeshProUGUI wave;
    public Image Store;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ws = FindObjectOfType<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + gm.GetMoney();
        wave.text = "Wave: " + ws.GetWaveCount();

    }
}
