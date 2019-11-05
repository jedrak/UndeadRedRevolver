using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobSpawner : MonoBehaviour
{
    public int spawningSpeed;
    public GameObject mobPrefab;
    public GameObject player;
    public TimerManager timerManager;
    public RoomGenerator room;

    private float _currentMinute;
    private void FixedUpdate()
    {
        _currentMinute += Time.fixedDeltaTime;
        if(_currentMinute > (60.0f / spawningSpeed))
        {
            GameObject mob = Instantiate(mobPrefab, transform.position, transform.rotation);
            mob.transform.parent = room.transform;
            mob.GetComponent<AIDestinationSetter>().target = player.transform;
            mob.GetComponent<EnemyHealth>().timerManager = timerManager;
            _currentMinute = 0;
        }
    }
}
