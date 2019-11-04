using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public Timer timer;

    public bool _playerIsDead {get; private set;}


    private void Start()
    {
        _playerIsDead = false;
    }
    void FixedUpdate()
    {
        if(timer.timeToEnd < 0){
            _playerIsDead = !_playerIsDead;
            if (_playerIsDead)
            {
                foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
                {
                    sp.color = new Color(.7f, .5f, .5f, 1.0f);
                }
                timer.timeToEnd = 60;
            }
            else
            {
                foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
                {
                    sp.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                timer.timeToEnd = 60;
            }
        }
    }
}
