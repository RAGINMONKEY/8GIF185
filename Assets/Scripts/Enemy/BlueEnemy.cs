using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = new Enemy("Blue");
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.blue);
    }

    void onCollisionEnter(Collision collision)
    {
        if (enemy.isHit(collision.gameObject.tag))
        {
            Destroy(this);
        }
    }
}
