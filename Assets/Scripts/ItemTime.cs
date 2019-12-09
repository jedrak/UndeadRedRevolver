using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTime : Item
{
    private const int time = 60; // seconds
    private Timer timer;
    public ItemTime(Timer timer)
    {
        this.timer = timer;
        name = "Time";
    }

    public override bool use()
    {
        // TODO particles effect or sth??

        timer.timeToEnd += time;
        
        return true;
    }
}
