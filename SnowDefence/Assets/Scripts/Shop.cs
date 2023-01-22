using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
public class Shop : MonoBehaviour
{
    public TurretBlueprint turret;
    public TurretBlueprint sniperTurret;
    public TurretBlueprint autoTurret;
    public TurretBlueprint fireTurret;


    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret()
    {
        buildManager.SelectTurretToBuild(turret);
    }
    
    public void SelectSniperTurret()
    {
        buildManager.SelectTurretToBuild(sniperTurret);
    }
    
    public void SelectAutoTurret()
    {
        buildManager.SelectTurretToBuild(autoTurret);
    }
    
    public void SelectFireTurret()
    {
        buildManager.SelectTurretToBuild(fireTurret);
    }
}
}