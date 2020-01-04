using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorChecker : MonoBehaviour
{
    public RoomGenerator generator;
    public Map map;
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
        if(collision.gameObject.tag == "DoorN" && !manager._playerIsDead && !_enemiesInRoom)
        {

            foreach(Transform t in generator.GetComponentInChildren<Transform>())
            {
                if(!(t.gameObject.tag == "Spawner" || t.gameObject.tag == "Chest")) Destroy(t.gameObject);     
            }
            transform.Translate(0, -30, 0, generator.transform);
            map._playerY++;
            map._playerRoomChanged = true;
            //manager.score++;
        }
        if (collision.gameObject.tag == "DoorS" && !manager._playerIsDead && !_enemiesInRoom)
        {

            foreach (Transform t in generator.GetComponentInChildren<Transform>())
            {
                if (!(t.gameObject.tag == "Spawner" || t.gameObject.tag == "Chest")) Destroy(t.gameObject);
            }
            transform.Translate(0, 30, 0, generator.transform);
            map._playerY--;
            map._playerRoomChanged = true;
            //manager.score++;
        }
        if (collision.gameObject.tag == "DoorW" && !manager._playerIsDead && !_enemiesInRoom)
        {

            foreach (Transform t in generator.GetComponentInChildren<Transform>())
            {
                if (!(t.gameObject.tag == "Spawner" || t.gameObject.tag == "Chest")) Destroy(t.gameObject);
            }
            transform.Translate(45, 0, 0, generator.transform);
            map._playerX--;
            map._playerRoomChanged = true;
            //manager.score++;
        }
        if (collision.gameObject.tag == "DoorE" && !manager._playerIsDead && !_enemiesInRoom)
        {

            foreach (Transform t in generator.GetComponentInChildren<Transform>())
            {
                if (!(t.gameObject.tag == "Spawner" || t.gameObject.tag == "Chest")) Destroy(t.gameObject);
            }
            transform.Translate(-45, 0, 0, generator.transform);
            map._playerX++;
            map._playerRoomChanged = true;
            //manager.score++;
        }
    }
}
