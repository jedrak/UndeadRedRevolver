using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public Timer timer;
    public RoomGenerator room;
    public bool _playerIsDead {get; private set;}
    public int monsterKillcount {get; set;}
    public int score { get; set;}


    private void Start()
    {
        Screen.fullScreen = false;
        _playerIsDead = false;
        monsterKillcount = 0;
        score = 0;
    }

    void FixedUpdate()
    {
        if(timer.timeToEnd < 0)
        {
            _playerIsDead = !_playerIsDead;
            if (_playerIsDead)
            {
                foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
                {
                    sp.color = new Color(.7f, .5f, .5f, 1.0f);
                }
                timer.timeToEnd = 60;
                score = 0;
            
            }
            else
            {
                foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
                {
                    sp.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                foreach (Transform t in room.GetComponentInChildren<Transform>())
                {
                    if(t.gameObject.tag == "Enemy") Destroy(t.gameObject);
                }
                timer.timeToEnd = 10 + 2 * monsterKillcount;
                monsterKillcount = 0;
                
            }
            foreach(Transform t in room.GetComponentInChildren<Transform>())
            {
                Debug.Log(t.gameObject, this);
                if(t.gameObject.tag == "Spawner")
                {
                    t.gameObject.SetActive(_playerIsDead);
                }
            }
        }
    }
}
