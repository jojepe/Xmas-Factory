using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation.Examples
{
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        
    }

    public GameObject TurretPreafab;
    public GameObject SniperTurretPreafab;
    public GameObject AutoTurretPreafab;

    public TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
    public bool CanBuild
    {
        get { return turretToBuild != null;  }
    }
    
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;
        
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void cleanTurretToBuild()
    {
        turretToBuild = null;
    }
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);

    }
    
    public void SelectNodeRange(Node node, int i)
    {
        if (selectedNode == node)
        {
            DeselectNodeRange();
            return;
        }
        selectedNode = node;
        
        //turretToBuild = null;

        nodeUI.ShowTarget(node, i);

    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    

    
    public void DeselectNodeRange()
    {
        selectedNode = null;
        nodeUI.HideRange();
    }
    
}
}