using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobSpawner : MonoBehaviour
{
    public int spawningSpeed;
    public GameObject mobPrefab;
    public GameObject player;

    private float _currentMinute;

    private void FixedUpdate()
    {
        _currentMinute += Time.fixedDeltaTime;
        if(_currentMinute > (60.0f / spawningSpeed))
        {
            GameObject mob = Instantiate(mobPrefab, transform);
            mob.GetComponent<AIDestinationSetter>().target = player.transform;
            _currentMinute = 0;
        }
    }
}
