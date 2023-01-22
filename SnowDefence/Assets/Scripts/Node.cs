using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PathCreation.Examples
{
public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;
    
    
    public GameObject turret;
    public Turret usedTurret;
    
    [HideInInspector] 
    public TurretBlueprint turretBlueprint;
    

    private Color startColor;
    private Renderer rend;

    BuildManager buildmanager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    private void Update()
    {
        if (turret == null)
        {
            return;
        }
        
        usedTurret = turret.GetComponent<Turret>();

        //specs of normal turret based on node
        if (usedTurret.turretType == "Normal")
        {
            if (this.CompareTag("Distance1"))
            {
                usedTurret.initialDuration = 15;
            }
            if (this.CompareTag("Distance2"))
            {
                usedTurret.initialDuration = 8;
            }
            if (this.CompareTag("Distance3"))
            {
                usedTurret.initialDuration = 5;
            }
            if (this.CompareTag("Distance4"))
            {
                usedTurret.initialDuration = 4;
            }
        }
        if (usedTurret.turretType == "Sniper")
        {
            if (this.CompareTag("Distance1"))
            {
                usedTurret.initialDuration = 12;
            }
            if (this.CompareTag("Distance2"))
            {
                usedTurret.initialDuration = 6;
            }
            if (this.CompareTag("Distance3"))
            {
                usedTurret.initialDuration = 3;
            }
            if (this.CompareTag("Distance4"))
            {
                usedTurret.initialDuration = 2;
            }
        }
        if (usedTurret.turretType == "Auto")
        {
            if (this.CompareTag("Distance1"))
            {
                usedTurret.initialDuration = 10;
            }
            if (this.CompareTag("Distance2"))
            {
                usedTurret.initialDuration = 5;
            }
            if (this.CompareTag("Distance3"))
            {
                usedTurret.initialDuration = 2;
            }
            if (this.CompareTag("Distance4"))
            {
                usedTurret.initialDuration = 1;
            }
        }
        if (usedTurret.turretType == "Fire")
        {
            usedTurret.initialDuration = 1;
        }
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildmanager.SelectNode(this);
            return;
        }
        
        if (!buildmanager.CanBuild)
        {
            return;
        }

        BuildTurret(buildmanager.GetTurretToBuild());
        buildmanager.cleanTurretToBuild();
        buildmanager.DeselectNodeRange();
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        rend.material.color = hoverColor;
        
        if (!buildmanager.CanBuild)
        {
            return;
        }
        
        
        int range = buildmanager.GetTurretToBuild().cost;
        if(range > 0)
        {
            if (turret == null)
            {
                buildmanager.SelectNodeRange(this, range);
            }
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
        if (turret == null)
        {
            buildmanager.DeselectNodeRange();
        }
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (blueprint.prefab == null)
        {
            return;
        }
        if (CharcoalMine.Coal < blueprint.cost)
        {
            print("Not enough money");
            return;
        }

        CharcoalMine.Coal -= blueprint.cost;
        
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        
        print("Turret Built! Money left: " + CharcoalMine.Coal);

    }
    
    public void RemoveTurret()
    {
        if (turret == null)
        {
            print("turret null");
            return;
        }

        Destroy(turret);
    }
    
    public void RepairTurret()
    {
        usedTurret = turret.GetComponent<Turret>();
        
        if (CharcoalMine.Coal < usedTurret.costToRepair)
        {
            print("Not enough money");
            return;
        }

        print("Chega no repair");
        
        CharcoalMine.Coal -= usedTurret.costToRepair;
        
        usedTurret.smoke.SetActive(false);

        usedTurret.duration = usedTurret.initialDuration;
        
    }
    }
    

    /*
    public void RepairTurret()
    {
        if (turret == null)
        {
            print("turret null");
            return;
        }
        if (CharcoalMine.Coal < turretBlueprint.costToRepair)
        {
            print("Not enough money to Repair");
            return;
        }
        CharcoalMine.Coal -= turretBlueprint.costToRepair;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.repairPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        print("Turret Repaired");
    }
    */
}
