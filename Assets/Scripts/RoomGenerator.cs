using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class RoomGenerator : MonoBehaviour
{
    public List<GameObject> listOfTiles;
    public List<GameObject> listOfMobs;
    public Transform player;
    private TimerManager _timerManager;

    public void instantiateRoom(int [] content)
    {
        for(int i =0; i<15; i++)
        { 

            GameObject gameObject = Instantiate(listOfTiles[content[i]], new Vector3((i % 5) * 7.5f, (i / 5) * 7.5f), Quaternion.Euler(0, 0, 0));
            gameObject.transform.parent = transform;

        }
        
        AstarPath.active.Scan();
        int numberOfEnemies = Random.Range(0, 5);
        for(int j = 0; j < numberOfEnemies; j++)
        {
            int whichEnemy = Random.Range(0, listOfMobs.Count);
            GameObject mob = Instantiate(listOfMobs[whichEnemy],
                                            new Vector3(Random.Range(0, 30), Random.Range(-2, 17)),
                                            Quaternion.Euler(0, 0, 0),
                                            transform) as GameObject;
            mob.GetComponent<AIDestinationSetter>().target = player;
            mob.GetComponent<EnemyHealth>().timerManager = _timerManager;
        }
    }
    
    void Start()
    {
        _timerManager = GetComponentInParent<TimerManager>();
        //generateRoom();
    }

    
    void Update()
    {
        
    }
}
