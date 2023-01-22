using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharcoalMine : MonoBehaviour
{
    public static int Life;
    public static int Coal;
    public int startLife = 100;
    public int startCoal = 125;
    public TextMeshProUGUI coalText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI roundRemainingText;

    [Header("Mines")] 
    public GameObject particle;
    public GameObject mine2;
    public GameObject mine3;
    public GameObject mine4;
    
    [Header("PopUpMines")]
    public GameObject popMine2;
    public GameObject popMine3;
    public GameObject popMine4;
    
    [Header("UI-LOSS")] public GameObject uiLoss;


    private int round = 0;
    private int roundRemaining = 20;
    
    private int a = 0;
    private int b = 0;
    private int c = 0;


    void Start()
    {
        Life = startLife;
        Coal = startCoal;
        GameEvent.current.onWaveChanged += NewRound;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            WaveSpawner.resetWaveSpawner();
            Life = 0;
            uiLoss.SetActive(true);
        }
        
        lifeText.text = Life.ToString();
        coalText.text = Coal.ToString();
        
        if (round == 5)
        {
            if(a == 0){
                Instantiate(particle, mine2.transform.position, Quaternion.identity);
                a++;
                mine2.GetComponent<Mine>().isWorking = true;
                if (popMine2 != null)
                {
                    mine2.GetComponent<Mine>().minePopUp(popMine2);
                }
            }
        }
        if (round == 10)
        {
            if (b == 0)
            {
                Instantiate(particle, mine3.transform.position, Quaternion.identity);
                b++;
                mine3.GetComponent<Mine>().isWorking = true;
                if (popMine3 != null)
                {
                    mine3.GetComponent<Mine>().minePopUp(popMine3);
                }
            }
        }
        if (round == 15)
        {
            if (c == 0)
            {
                Instantiate(particle, mine4.transform.position, Quaternion.identity);
                c++;
                mine4.GetComponent<Mine>().isWorking = true;
                if (popMine4 != null)
                {
                    mine4.GetComponent<Mine>().minePopUp(popMine4);
                }
            }
        }
    }

    private void NewRound()
    {
        round++;
        roundRemaining--;
        roundText.text = round.ToString();
        roundRemainingText.text = roundRemaining.ToString();
    }

}
