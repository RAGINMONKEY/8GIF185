using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject ElfTurretPrefab;
    public GameObject GolemTurretPrefab;
    public GameObject AnubisTurretPrefab;

    private TurretBlueprint TurretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager in scene!");
            return;
        }
        instance = this;
    }

     public bool CanBuild { get { return TurretToBuild != null; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
    }

    public void BuildTurretOn(NodeScript node)
    {
        if (PlayerStats.Life < TurretToBuild.cost)
        {
            Debug.Log("Not enuf life");
            return;
        }

        GameObject turret = (GameObject)Instantiate(TurretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        PlayerStats.Life -= TurretToBuild.cost;
    }

    public TurretBlueprint ReturnTurretToBuild()
    {
        return TurretToBuild;
    }
}
