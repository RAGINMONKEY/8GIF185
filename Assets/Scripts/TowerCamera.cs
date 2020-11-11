using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCamera : MonoBehaviour
{
    public float speedH = 1f;
    public float speedV = 1;

    protected float fDistance = 1;
    protected float fSpeed = 1;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

                float step = fSpeed * Time.deltaTime;
                float fOrbitCircumfrance = 2F * fDistance * Mathf.PI;
                float fDistanceDegrees = (fSpeed / fOrbitCircumfrance) * 360;
                float fDistanceRadians = (fSpeed / fOrbitCircumfrance) * 2 * Mathf.PI;



                float x = Input.GetAxis("Horizontal");

                if (x < 0)
                {
                    transform.RotateAround(this.transform.parent.transform.position, Vector3.up, -fDistanceRadians);
                    yaw -= fDistanceRadians;
                    transform.parent.GetComponent<Tower>().rotatePart(-fDistanceRadians);
                }


                if (x > 0)
                {
                    transform.RotateAround(this.transform.parent.transform.position, Vector3.up, fDistanceRadians);
                    yaw += fDistanceRadians;
                    transform.parent.GetComponent<Tower>().rotatePart(fDistanceRadians);
                }
         
        
    }
}
