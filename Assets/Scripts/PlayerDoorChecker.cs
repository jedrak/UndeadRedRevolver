using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorChecker : MonoBehaviour
{
    public RoomGenerator generator;
    public TimerManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door" && !manager._playerIsDead)
        {
            foreach(Transform t in generator.GetComponentInChildren<Transform>())
            {
                Destroy(t.gameObject);
            }
            transform.Translate(0, -18, 0, generator.transform);
            generator.generateRoom();
            
        }
    }
}
