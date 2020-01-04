using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _Room 
{
    public int[] contents = new int[15];
    public bool empty = false;

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
        }
    }
}

public class Map : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] blocks;
    public int columns;
    public int rows;
    private RoomGenerator _generator;
    private _Room[,] map;
    public int nrOfEmptyRooms;

    public uint _playerX { get; set; }
    public uint _playerY { get; set; }
    public bool _playerRoomChanged { private get; set; }
    [SerializeField]
    public GameObject chestPrefab;
    [SerializeField]
    public GameObject Chests;

    // Start is called before the first frame update
    void Start()
    {
        _generator = GetComponent<RoomGenerator>();
        map = new _Room[rows, columns];
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
        for(int i = 0; i < nrOfEmptyRooms; i++)
        {
            int roomX = Random.Range(1, columns);
            int roomY = Random.Range(1, rows);
            //Debug.Log("X: "+roomX + " Y: "+roomY);
            map[roomX, roomY].empty = true;
        }
        _chestHandle();

    }

    private void _chestHandle()
    {
        int nrOfchests = (rows * columns - nrOfEmptyRooms) / 3;
        for(int i = 0; i<nrOfchests; i++)
        {
            GameObject buff = Instantiate(chestPrefab, new Vector3(Random.Range(0, 30), Random.Range(0, 15), 0), Quaternion.identity);
            buff.transform.parent = Chests.transform;
            buff.GetComponent<Chest>().roomIndexX = (uint)Random.Range(0, rows);
            buff.GetComponent<Chest>().roomIndexY = (uint)Random.Range(0, columns);
            Debug.Log(buff.GetComponent<Chest>().roomIndexX + " " + buff.GetComponent<Chest>().roomIndexY, this);
        }
    }


    private void _doorHandle()
    {
        //N
        if (_playerY == columns - 1 || map[_playerX, _playerY+1].empty)
        {
            doors[0].SetActive(false);
            blocks[0].SetActive(true);
        }
        else
        {
            doors[0].SetActive(true);
            blocks[0].SetActive(false);
        }
        //S
        if (_playerY == 0 || map[_playerX, _playerY - 1].empty)
        {
            doors[1].SetActive(false);
            blocks[1].SetActive(true);
        }
        else
        {
            doors[1].SetActive(true);
            blocks[1].SetActive(false);
        }
        //W
        if (_playerX == 0 || map[_playerX - 1, _playerY].empty)
        {
            doors[2].SetActive(false);
            blocks[2].SetActive(true);
        }
        else
        {
            doors[2].SetActive(true);
            blocks[2].SetActive(false);
        }
        //E
        if (_playerX == rows - 1 || map[_playerX + 1, _playerY].empty)
        {
            doors[3].SetActive(false);
            blocks[3].SetActive(true);
        }
        else
        {
            doors[3].SetActive(true);
            blocks[3].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerRoomChanged)
        {
            _generator.instantiateRoom(map[_playerX, _playerY].contents);
            _playerRoomChanged = false;
            Debug.Log(_playerX + " " + _playerY);
            _doorHandle();
        }
    }
}
