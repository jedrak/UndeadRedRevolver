using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public List<GameObject> listOfPrefabs;

    public void generateRoom()
    {
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
            GameObject gameObject = Instantiate(listOfPrefabs[whichPrefab], new Vector3((i % 5) * 7.5f, (i / 5) * 7.5f), Quaternion.Euler(0, 0, 0));
            gameObject.transform.parent = transform;
        }
    }
    
    void Start()
    {
        generateRoom();
    }

    
    void Update()
    {
        
    }
}
