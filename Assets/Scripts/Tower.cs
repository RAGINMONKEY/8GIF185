using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Audio;

public class Tower : MonoBehaviour
{
    SwitchCharacters player;
    public GameObject players;
    Vector3 fireDirection;
    private bool player1;
    private bool player2;
    bool active;

    bool hasCollided = false;
    string labelText = "";

    [Header("Attributes")]

    public Transform partToRotate1;
    public Transform partToRotate2;
    public GameObject redProjectilePrefab;
    public GameObject blueProjectilePrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject camera1;
    public GameObject camera2;
    public AudioClip ShootingAudioClip;

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
        GameObject camera;
        if(player.getCurrCar() == 1)
        {
            camera = camera1;
        }else if(player.getCurrCar() == 2)
        {
            camera = camera2;
        }
        else
        {
            camera = null;
        }

        if (((player.getCurrCar() == 1 && player1) || (player.getCurrCar() == 2 && player2)))
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
                movement = camera.transform.forward;
                fireDirection = movement;

               /* Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);*/
                }
               // print(cont[2].ToString());

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                //print("dddddddddd");
            }
            

        }
    }
   
    public void setPlayer(SwitchCharacters player)
    {
        this.player = player;
    }

    private void Shoot()
    {
        AudioSource.PlayClipAtPoint(ShootingAudioClip, transform.position);
        
        
        if(player.getCurrCar() == 1)
        {
           // GameObject bulletGO = (GameObject)Instantiate(blueProjectilePrefab, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), Quaternion.identity);
            GameObject bulletGO = (GameObject)Instantiate(blueProjectilePrefab, new Vector3(firePoint1.position.x, firePoint1.position.y, firePoint1.position.z), firePoint1.rotation);
            ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();
            projectile.tag = "Blue";
           

        }
        else if(player.getCurrCar() == 2)
        {
            GameObject bulletGO = (GameObject)Instantiate(redProjectilePrefab, new Vector3(firePoint2.position.x, firePoint2.position.y, firePoint2.position.z), firePoint2.rotation);
            ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();
            projectile.tag = "Red";
          
        }

    }

    public void setActive(int active)
    {
        this.active = true;
    }

    public void setCurrent (int curr)
    {
        if (curr == 1)
        {
            player1 = true;
        }else if(curr == 2)
        {
            player2 = true;
        }
        else if (curr == -1)
        {
            player1 = false;
        }
        else if (curr == -2)
        {
            player2 = false;
        }
    }

    public void rotatePart(float radian)
    {
        Transform partToRotate;
        if (player.getCurrCar() == 1)
        {
            partToRotate = partToRotate1;
        }
        else if (player.getCurrCar() == 2)
        {
            partToRotate = partToRotate2;
        }
        else
        {
            partToRotate = null;
        }
        partToRotate.RotateAround(this.transform.position, Vector3.up, radian);
    }
}