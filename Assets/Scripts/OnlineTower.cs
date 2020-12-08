using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OnlineTower : MonoBehaviour
{
    OnlinePlayers player;
    public GameObject players;
    Vector3 fireDirection;
    private bool player1;
    private bool player2;
    bool active;
    private int ammo;
    public TMP_Text ammoTxt;
    public TMP_Text warningTxt;

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

    // Start is called before the first frame update
    void Start()
    {
        player = players.GetComponent<OnlinePlayers>();
        active = false;
        ammo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera;
        camera = camera1;
        if (ammo > 0)
        {
            ammoTxt.GetComponent<TMP_Text>().text = ammo.ToString();
        }
        else
        {
            ammoTxt.GetComponent<TMP_Text>().text = "0";
        }
        if (player.PlayerList[1].GetComponent<Player>().onTower)
        {

              ammoTxt.GetComponent<TMP_Text>().enabled = true;
              if (ammo < 1)
            {
                warningTxt.GetComponent<TMP_Text>().enabled = true;
            }
            else
            {
                warningTxt.GetComponent<TMP_Text>().enabled = false;
            }

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

            if (Input.GetMouseButtonDown(0) && (ammo > 0))
            {
                Shoot();
                //print("dddddddddd");
            }


        }
        else
        {
            ammoTxt.GetComponent<TMP_Text>().enabled = false;
            warningTxt.GetComponent<TMP_Text>().enabled = false;
        }
    }
   
   

    private void Shoot()
    {
        AudioSource.PlayClipAtPoint(ShootingAudioClip, transform.position);
        loseAmmo();
        
        
        if(player.PlayerList[1].GetComponent<Player>().onTower)
        {
           // GameObject bulletGO = (GameObject)Instantiate(blueProjectilePrefab, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), Quaternion.identity);
            GameObject bulletGO = (GameObject)Instantiate(blueProjectilePrefab, new Vector3(firePoint1.position.x, firePoint1.position.y, firePoint1.position.z), firePoint1.rotation);
            ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();
            projectile.tag = "Blue";
           // projectile.setTour(this);
           

        }
        else if(player.PlayerList[2].GetComponent<Player>().onTower)
        {
            GameObject bulletGO = (GameObject)Instantiate(redProjectilePrefab, new Vector3(firePoint2.position.x, firePoint2.position.y, firePoint2.position.z), firePoint2.rotation);
            ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();
            projectile.tag = "Red";
           // projectile.setTour(this);

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
        if (player.PlayerList[1].GetComponent<Player>().onTower)
        {
            partToRotate = partToRotate1;
        }
        else if (player.PlayerList[2].GetComponent<Player>().onTower)
        {
            partToRotate = partToRotate2;
        }
        else
        {
            partToRotate = null;
        }
        partToRotate.RotateAround(this.transform.position, Vector3.up, radian);
    }

    public void fillAmmo()
    {
        ammo = 10;
    }

    public void loseAmmo()
    {
        ammo -= 1;
    }
}