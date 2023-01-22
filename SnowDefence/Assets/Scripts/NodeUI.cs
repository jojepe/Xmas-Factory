using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PathCreation.Examples
{
public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject range1;
    public GameObject range2;
    public GameObject range3;
    public GameObject range4;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        
        ui.SetActive(true);
    }
    
    public void ShowTarget(Node _target, int i)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (i == 50)
        {
            range1.SetActive(true);
        }
        if (i == 70)
        {
            range2.SetActive(true);
        }
        if (i == 100)
        {
            range3.SetActive(true);
        }
        if (i == 300)
        {
            range4.SetActive(true);
        }

    }

    public void Remove()
    {
        target.RemoveTurret();
        BuildManager.instance.DeselectNode();
    }    
    
    public void Repair()
    {
        target.RepairTurret();
        BuildManager.instance.DeselectNode();
    } 
    
    public void Hide()
    {
        ui.SetActive(false);
    }
    
    public void HideRange()
    {
        range1.SetActive(false);
        range2.SetActive(false);
        range3.SetActive(false);
        range4.SetActive(false);
    }
}
}
