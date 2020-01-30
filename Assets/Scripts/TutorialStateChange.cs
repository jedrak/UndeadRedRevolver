using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStateChange : MonoBehaviour
{
    public TimerManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager._playerIsDead)
        {
            manager._playerIsDead = false;
            manager.timer.timeToEnd = 500;
        }
        else
        {
            manager._playerIsDead = true;
            manager.timer.timeToEnd = 0;
        }
        Debug.Log(collision.gameObject.tag);
    }
}
