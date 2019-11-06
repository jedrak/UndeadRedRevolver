using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorChecker : MonoBehaviour
{
    public RoomGenerator generator;
    public TimerManager manager;
    private bool _enemiesInRoom;


    private void FixedUpdate()
    {
        foreach(Transform t in generator.GetComponent<Transform>())
        {
            if(t.gameObject.tag == "Enemy")
            {
                _enemiesInRoom = true;
            }
            else
            {
                _enemiesInRoom = false;
            }
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door" && !manager._playerIsDead && !_enemiesInRoom)
        {
            foreach(Transform t in generator.GetComponentInChildren<Transform>())
            {
                if(t.gameObject.tag != "Spawner") Destroy(t.gameObject);     
            }
            transform.Translate(0, -18, 0, generator.transform);
            generator.generateRoom();
            
        }
    }
}
