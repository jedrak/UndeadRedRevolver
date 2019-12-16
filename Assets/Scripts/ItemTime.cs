using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTime : Item
{
    private const int time = 60; // seconds
    private Timer timer;
    public ItemTime(GameObject player)
    {
        this.timer = player.GetComponentInParent<TimerManager>().timer;
        name = "Time";
    }

    public override bool use()
    {
        // TODO particles effect or sth??

        if (GameObject.FindObjectOfType<TimerManager>()._playerIsDead == false)
        {
            Debug.Log("Time befor: " + timer.timeToEnd);
            timer.timeToEnd += time;
            Debug.Log("Time after: " + timer.timeToEnd);
            return true;
        }
        else
        {
            return false;
        }
    }
}
