using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class RedEnemy : MonoBehaviour
{
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = new Enemy("Red");
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.red);
    }

    void onCollisionEnter(Collision collision)
    {
        if (enemy.isHit(collision.gameObject.tag))
        {
            Destroy(this);
        }
    }
}
