using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 1f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public float range;

    private Transform target;
    private Vector3 shootDirection;

    public AudioClip bigBong;


    //private float timer = 0.0f;

    private void Start()
    {
        
    }

    void Update()
    {
        
        if(this.transform.position.x > 100.0 || this.transform.position.z > 100.0 || this.transform.position.y > 100)
        {
            Destroy(gameObject);
            return;
        }


        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitTarget(); 
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
       // direct = _target;
    }

}
