using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextUpdater : MonoBehaviour
{

    public TimerManager timerManager;
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "Killcount: " + timerManager.monsterKillcount;
    }
}
