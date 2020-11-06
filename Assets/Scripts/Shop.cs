using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint ElfTurret;
    public TurretBlueprint GolemTurret;
    public TurretBlueprint AnubisTurret;

    public Turret elfTurret;
    public Turret golemTurret;
    public Turret anubisTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectElfTurret()
    {
        buildManager.SelectTurretToBuild(ElfTurret);
    }



    public void SelectGolemTurret()
    {
        buildManager.SelectTurretToBuild(GolemTurret);
    }

    public void SelectAnubisTurret()
    {
        buildManager.SelectTurretToBuild(AnubisTurret);
    }
}
