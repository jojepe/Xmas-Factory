using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int coal;
    public bool isWorking;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GameEvent.current.onWaveChanged += mineCoal;
        if (CompareTag("Mine1"))
        {
            coal = 15;
        }
        if (CompareTag("Mine2"))
        {
            coal = 20;
        }
        if (CompareTag("Mine3"))
        {
            coal = 30;
        }
        if (CompareTag("Mine4"))
        {
            coal = 35;
        }
    }

    private void Update()
    {
        if (!isWorking)
        {
            animator.enabled = false;
        }
        if (isWorking)
        {
            animator.enabled = true;
        }
    }

    private void mineCoal()
    {
        if (!isWorking)
        {
            return;
        }
        CharcoalMine.Coal += coal;
        print(tag + coal +"coals mined");
    }

    public void minePopUp(GameObject mine)
    {
        mine.SetActive(true);
        Destroy(mine, 8f);
    }
}
