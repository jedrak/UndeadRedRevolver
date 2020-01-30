using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public TimerManager manager;
    public Timer timer;
    private GameObject Shield;

    private void Start()
    {
        Shield = GameObject.FindGameObjectWithTag("Shield");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Shield.activeSelf)
        {
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            if (manager._playerIsDead)
            {
                manager._playerIsDead = false;
                manager._playerStateChanged = true;
            }
            else
            {
                timer.timeToEnd -= 10;
            }

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Shield.activeSelf)
        {
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            if (manager._playerIsDead)
            {
                manager._playerIsDead = false;
                manager._playerStateChanged = true;
            }
            else
            {
                timer.timeToEnd -= 10;
            }

            Destroy(collision.gameObject);
        }
    }
}
