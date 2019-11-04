using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorChecker : MonoBehaviour
{
    public RoomGenerator generator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            foreach(Transform t in generator.GetComponentInChildren<Transform>())
            {
                Destroy(t.gameObject);
            }
            transform.Translate(0, -15, 0, generator.transform);
            generator.generateRoom();
        }
    }
}
