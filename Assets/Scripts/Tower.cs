using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    SwitchCharacters player;
    public GameObject players;
    Vector3 fireDirection;
    public int current;

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
        player = players.GetComponent<SwitchCharacters>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (current == player.getCurrCar())
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
                print(cont[2].ToString());
            if (Input.GetKeyDown(cont[2].ToString()))
            {
                Shoot();
            }
            }

        }
    }

    public void setPlayer(SwitchCharacters player)
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