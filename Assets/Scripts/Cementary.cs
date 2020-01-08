using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cementary : MonoBehaviour
{
    public Map map;
    public int roomX;
    public int roomY;
    //public PlayerController player;

    public float  distanceToPlayer()
    {
        float buff = ((map._playerX - roomX) * (map._playerX - roomX) + (map._playerY - roomY) * (map._playerY - roomY));
        return buff;
    }
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponentInParent<Map>();
        //room = new System.Tuple<int, int>(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
            sp.enabled = (map._playerX == roomX && map._playerY == roomY);
       // Debug.Log(distanceToPlayer());
    }
}
