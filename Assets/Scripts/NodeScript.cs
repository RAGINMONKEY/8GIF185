using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public Color hoverColorForRanged;
    public Vector3 positionOffset;
    public bool nodeForRanged;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;
    private Renderer rend;
    private Color startColor;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;
     
        if (buildManager.ReturnTurretToBuild().isRanged == true && nodeForRanged == true)
            rend.material.color = hoverColorForRanged;
        if (buildManager.ReturnTurretToBuild().isRanged == false && nodeForRanged == false)
            rend.material.color = Color.white; 
       
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("ADD MENU SCRIPT");
        }

        if (buildManager.ReturnTurretToBuild().isRanged == true && nodeForRanged == true)
            buildManager.BuildTurretOn(this);
        if (buildManager.ReturnTurretToBuild().isRanged == false && nodeForRanged == false)
            buildManager.BuildTurretOn(this);
       
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
