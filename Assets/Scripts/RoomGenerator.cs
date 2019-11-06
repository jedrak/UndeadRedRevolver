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

    public void generateRoom()
    {
        int doorOn = 12;
        for(int i = 0; i< 15; i++)
        {
            int rand = Random.Range(0, 100), whichPrefab = 0;
            if (rand < 64) whichPrefab = 0;
            else if (rand > 64 && rand < 68) whichPrefab = 1;
            else if (rand > 68 && rand < 72) whichPrefab = 2;
            else if (rand > 72 && rand < 76) whichPrefab = 3;
            else if (rand > 76 && rand < 80) whichPrefab = 4;
            else if (rand > 80 && rand < 84) whichPrefab = 5;
            else if (rand > 84 && rand < 88) whichPrefab = 6;
            else if (rand > 88 && rand < 92) whichPrefab = 7;
            else if (rand > 92 && rand < 96) whichPrefab = 8;
            else if (rand > 96 && rand < 100) whichPrefab = 9;
            if(i == doorOn)
            {
                GameObject gameObject = Instantiate(listOfTiles[10], new Vector3((i % 5) * 7.5f, (i / 5) * 7.5f), Quaternion.Euler(0, 0, 0));
                gameObject.transform.parent = transform;
            }
            else
            {
                GameObject gameObject = Instantiate(listOfTiles[whichPrefab], new Vector3((i % 5) * 7.5f, (i / 5) * 7.5f), Quaternion.Euler(0, 0, 0));
                gameObject.transform.parent = transform;
            }
            
            
            //update pathfinding grid
            AstarPath.active.Scan();
        }
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
        generateRoom();
    }

    
    void Update()
    {
        
    }
}
