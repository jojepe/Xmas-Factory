using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        print("GameManagerAwaked");
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }
}

