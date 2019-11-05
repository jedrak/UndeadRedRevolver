using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextUpdater : MonoBehaviour
{

    public TimerManager timerManager;
    void Update()
    {
        //gameObject.SetActive(timerManager._playerIsDead);
        GetComponent<TextMeshProUGUI>().text = "" + timerManager.monsterKillcount;
    }
}
