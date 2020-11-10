using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Tower : MonoBehaviour
{
    SwitchCharacters player;
    public GameObject players;
    Vector3 fireDirection;
    private int current;
    bool active;

    bool hasCollided = false;
    string labelText = "";

    [Header("Attributes")]

    public Transform partToRotate;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject camera;

    [Header("Turret Numbers")]
    public float range;
    public float turnSpeed;
    public float fireRate;
    public int cost;
    public float HauteurDeTir;


    // Start is called before the first frame update
    void Start()
    {
        player = players.GetComponent<SwitchCharacters>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

        if ((current == player.getCurrCar()) && active)
        {


           
              Vector3 mouse = Input.mousePosition;
              Ray castPoint = Camera.main.ScreenPointToRay(mouse);
              RaycastHit hit;
              if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
              {
                Vector3 direction = hit.point - transform.position;
                fireDirection = direction;

                float xForce = Input.GetAxis("Horizontal") * 5;
                float zForce = Input.GetAxis("Vertical") * 5;
                Vector3 force = new Vector3(xForce, 0.0F, zForce);
                Vector3 movement = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
                movement = Vector3.Scale(movement, force);
                movement = this.camera.transform.forward;
                fireDirection = movement;

               /* Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);*/
                }
               // print(cont[2].ToString());

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                print("dddddddddd");
            }
            

        }
    }
   
    public void setPlayer(SwitchCharacters player)
    {
        this.player = player;
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), firePoint.rotation);
        ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();
        if(current == 1)
        {
            projectile.tag = "Blue";
        }else if(current == 2)
        {
            projectile.tag = "Red";
        }

        if (projectile != null)
            projectile.Seek(fireDirection);
    }

    public void setActive(bool active)
    {
        this.active = active;
    }

    public void setCurrent (int curr)
    {
        this.current = curr;
    }

    public void rotatePart(float radian)
    {
        partToRotate.RotateAround(this.transform.position, Vector3.up, radian);
    }
}