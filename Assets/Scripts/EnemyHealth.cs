using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }

    public void FixedUpdate()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

