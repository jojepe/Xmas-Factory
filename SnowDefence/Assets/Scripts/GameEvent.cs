using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action onWaveChanged;

    public void WaveChanged()
    {
        if (onWaveChanged != null)
        {
            onWaveChanged();
        }
    }
}
