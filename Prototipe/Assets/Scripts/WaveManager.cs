using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    static public event Action StartWaveEvent;
    static public event Action NextWave;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartWave()
    {
        StartWaveEvent?.Invoke();
    }
}
