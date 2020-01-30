using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobSpawner : MonoBehaviour
{
    public int spawningSpeed;
    public GameObject mobPrefab;
    public GameObject bossPrefab;
    public GameObject player;
    public TimerManager timerManager;
    public RoomGenerator room;

    private float _currentMinute;
    private int mobCounter = 1;
    private void FixedUpdate()
    {
        _currentMinute += Time.fixedDeltaTime;
        if (_currentMinute > (60.0f / spawningSpeed))
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 50.0f)
            {
                GameObject mob;
                if (mobCounter % 20 == 0)
                {
                    mob = Instantiate(bossPrefab, transform.position, transform.rotation);
                }
                else
                {
                    mob = Instantiate(mobPrefab, transform.position, transform.rotation);

                }
                mob.transform.parent = room.transform;
                mob.GetComponent<AIDestinationSetter>().target = player.transform;
                mob.GetComponent<EnemyHealth>().timerManager = timerManager;
                _currentMinute = 0;
                mobCounter++;
            }
        }
    }
}
