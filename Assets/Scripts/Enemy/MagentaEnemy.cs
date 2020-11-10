using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaEnemy : MonoBehaviour
{
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = new Enemy("red blue");
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.magenta);
    }

    void onCollisionEnter(Collision collision)
    {
        if (enemy.isHit(collision.gameObject.tag))
        {
            Destroy(this);
        }
    }
}
