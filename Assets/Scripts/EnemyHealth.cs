﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp;
    public TimerManager timerManager;

    private int maxHealth;

    private void Start()
    {
        maxHealth = hp;
    }
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
            FindObjectOfType<AudioManager>().Play("death");
            if (timerManager._playerIsDead) timerManager.monsterKillcount += maxHealth;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}

