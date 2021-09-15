using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    static public event Action StartWaveEvent;

    public void StartWave()
    {
        StartWaveEvent?.Invoke();
    }
}
