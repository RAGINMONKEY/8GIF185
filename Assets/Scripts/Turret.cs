using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]

    public Transform partToRotate;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public bool isRanged;

    [Header("Turret Numbers")]
    public float range;
    public float turnSpeed;
    public float fireRate;
    public int cost;


    [Header("Unity Setup Fields")]

    private float fireCountDown = 0f;
    private string enemyTag = "Enemy";
    private Transform target;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        
        Vector3 direction = Input.mousePosition - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDisance = range;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDisance)
            {
                shortestDisance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDisance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        ProjectileScript projectile = bulletGO.GetComponent<ProjectileScript>();

        if (projectile != null)
        {
            //projectile.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.isRanged == false)
        {
            Debug.Log("Collision Script On");
            collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            return;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //this.GetComponent<NavMeshAgent>().speed = baseSpeed;
    }
} 
