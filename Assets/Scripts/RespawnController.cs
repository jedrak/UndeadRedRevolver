using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform player;
    private Map map;


    private void Start()
    {
        map = GetComponentInParent<Map>();
    }

    public void respawn()
    {
        Cementary buff = GetComponentsInChildren<Cementary>()[0];
        foreach (Cementary cementary in GetComponentsInChildren<Cementary>())
        {
            if (buff.distanceToPlayer() <= cementary.distanceToPlayer())
            {
                buff = cementary;
            }
        }
        map._playerX = (uint)buff.roomX;
        map._playerY = (uint)buff.roomY;
        map._playerRoomChanged = true;
        map._generator.spawnMobs = false;
        player.Translate(-player.transform.position.x, -player.transform.position.y, -player.transform.position.z);
        player.Translate(buff.transform.position.x, buff.transform.position.y, buff.transform.position.z);
    }
}
