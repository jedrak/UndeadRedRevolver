using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public TimerManager timerManager;
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + timerManager.score;
    }
}
