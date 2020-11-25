using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public GameObject objecttoInstantiate;
    public Vector3 locationToInstantiate;
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Instantiate(objecttoInstantiate, locationToInstantiate,Quaternion.identity);
        }
    }
}
