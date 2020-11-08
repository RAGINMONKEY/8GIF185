using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
     Player player;
    Vector3 fireDirection;

   [Header("Attributes")]

    public Transform partToRotate;
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Turret Numbers")]
    public float range;
    public float turnSpeed;
    public float fireRate;
    public int cost;
    public float HauteurDeTir;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();   
    }

    // Update is called once per frame
    void Update()
    {
        
            ArrayList cont = player.getControl();

            if(cont[0] == ("clavier"))
            {
              Vector3 mouse = Input.mousePosition;
              Ray castPoint = Camera.main.ScreenPointToRay(mouse);
              RaycastHit hit;
              if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
              {
                Vector3 direction = hit.point - transform.position;
                direction.y = HauteurDeTir;
                fireDirection = direction;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                }
            if (Input.GetKeyDown("space"))
            {
                Shoot();
            }


        }
    }

    public void setPlayer(Player player)
    {
        this.player = player;
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, new Vector3(firePoint.position.x, HauteurDeTir, firePoint.position.z), firePoint.rotation);
        ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();

        if (projectile != null)
            projectile.Seek(fireDirection);
    }
}