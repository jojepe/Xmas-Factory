using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    
    Material material;
    public int activationRound;
    private int round;
    
    void Start()
    {
        GameEvent.current.onWaveChanged += sumRound;
        material = GetComponent<Renderer>().materials[3];
        print(material);
    }

    private void Update()
    {
        if (round == activationRound)
        {
            material.EnableKeyword("_EMISSION");
        }
    }

    void sumRound()
    {
        round++;
    }
}
