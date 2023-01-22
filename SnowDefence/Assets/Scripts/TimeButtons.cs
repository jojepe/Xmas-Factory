using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButtons : MonoBehaviour
{
    public void button1 (){
        Time.timeScale = 1;
    }

    public void button2 (){
        Time.timeScale = 2;
    }

    public void button4 (){
        Time.timeScale = 4;
    }
}
