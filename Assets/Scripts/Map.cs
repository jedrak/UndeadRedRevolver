using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _Room 
{
    public int[] contents = new int[15];

    public void generate()
    {
        contents = new int[15];
        for (int i = 0; i < 15; i++)
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
            contents[i] = whichPrefab;
            Debug.Log(contents[i]);
        }
    }
}

public class Map : MonoBehaviour
{
    public GameObject[] doors;
    public int columns;
    public int rows;
    private RoomGenerator _generator;
    private _Room[,] map;
    public uint _playerX { get; set; }
    public uint _playerY { get; set; }
    public bool _playerRoomChanged { private get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _generator = GetComponent<RoomGenerator>();
        map = new _Room[rows, columns];
        //Debug.Log(map[0, 0]);
        _playerX = 0;
        _playerY = 0;
        _playerRoomChanged = true;
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                map[i, j] = new _Room();
                map[i, j].generate();
            }
        }

    }
    private void _doorHandle()
    {
        //N
        if (_playerY == columns - 1 ) doors[0].SetActive(false);
        else doors[0].SetActive(true);
        //S
        if (_playerY == 0) doors[1].SetActive(false);
        else doors[1].SetActive(true);
        //W
        if (_playerX == 0) doors[2].SetActive(false);
        else doors[2].SetActive(true);
        //E
        if (_playerX == rows - 1) doors[3].SetActive(false);
        else doors[3].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerRoomChanged)
        {
            _generator.instantiateRoom(map[_playerX, _playerY].contents);
            _playerRoomChanged = false;
            _doorHandle();
        }
    }
}
