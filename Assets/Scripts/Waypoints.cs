using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypointList;

    private void Awake()
    {
        waypointList = new Transform[transform.childCount];
        
        for(int i=0; i< waypointList.Length; i++)
        {
            waypointList[i] = transform.GetChild(i);
        }
    }
}
