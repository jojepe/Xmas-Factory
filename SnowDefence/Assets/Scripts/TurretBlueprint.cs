using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    
    public GameObject repairPrefab;
    public int costToRepair;

    public void setCostRoRepair(int cost)
    {
        this.costToRepair = cost;
    }
    
    public void setCost(int cost)
    {
        this.cost = cost;
    }
}
