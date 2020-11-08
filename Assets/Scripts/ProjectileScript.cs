using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 50f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public float range;
    private Transform target;
    private string enemyTag = "Enemy";

    public AudioClip bigBong;

    private Vector3 direct;
    
  
    void Update()
    {
        if(this.transform.position.x > 1000.0)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 direction = direct;
        float distanceThisFrame = speed * Time.deltaTime;


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

        if (target != null)
        {
            //print(target.transform.position);
            //print(this.transform.position);
            //print("");
            if (target.transform.position.magnitude <= distanceThisFrame)
            {
                //HitTarget();
                //return;
            }
        }
        Vector3 trans = direction.normalized * distanceThisFrame;
        trans.y = 0;
        transform.Translate(trans, Space.World);
        transform.LookAt(direct);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        //Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    public void Seek(Vector3 _target)
    {
        direct = _target;
    }

}
