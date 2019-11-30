using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp;
    public TimerManager timerManager;
    public GameObject effect;
    private int maxHealth;

    private void Start()
    {
        maxHealth = hp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject eff = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(eff, 0.5f);
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

