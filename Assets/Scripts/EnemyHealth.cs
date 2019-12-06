using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyHealth : MonoBehaviour
{
    public int hp;
    public TimerManager timerManager;
    public GameObject effect;
    private int maxHealth;
    private Animator anim;
    private float deathtimer;
    Camera cam;
    private void Start()
    {
        maxHealth = hp;
        anim = GetComponent<Animator>();
        anim.SetBool("Front_Death", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject eff = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(eff, 0.5f);
            hp--;
        }
    }



    public void Update()
    {
        if (hp <= 0)
        {
            Debug.Log(hp);
            deathtimer = Time.time;
            FindObjectOfType<AudioManager>().Play("death");
            anim.SetTrigger("Front_Death");
            WaitForSeconds(1);    
            
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Front_Death"))
            {   

                if (timerManager._playerIsDead) timerManager.monsterKillcount += maxHealth;
                Destroy(gameObject);
            }
           
        }
    }

    private void WaitForSeconds(int v)
    {
        
    }

    private void OnDestroy()
    {

        

    }
}

   