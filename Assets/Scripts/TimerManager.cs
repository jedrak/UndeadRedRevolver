using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public Timer timer;
    public RoomGenerator room;
    public bool _playerIsDead { get; set; }
    public bool _playerStateChanged { private get; set; }
    public int monsterKillcount { get; set; }
    public GameObject killCountText;
    public GameObject messageText;
    public GameObject gameplayInfoText;
    public RespawnController respawnController;
    public Material mat;

    private void Start()
    {
        _playerIsDead = true;
        mat.SetFloat("blendDuration", 2.0f);
        monsterKillcount = 0;
        StartCoroutine(SetGameplayInfoTextForTime("Move with WSAD, shoot with Arrows Keys", 10));
        StartCoroutine(SetMessageTextForTime(120)); // To delete if tutorial exist
    }

    void FixedUpdate()
    {
        killCountText.SetActive(_playerIsDead);

        if (timer.timeToEnd < 0)
        {
            FindObjectOfType<AudioManager>().Play("morde");

            _playerIsDead = true;
            _playerStateChanged = true;
            mat.SetFloat("startTime", Time.time);
        }

        if (_playerIsDead)
        {
            timer.timeToEnd = monsterKillcount * 2;
        }

        foreach (Transform t in room.GetComponentInChildren<Transform>())
        {
            if (t.gameObject.tag == "Spawner")
            {
                t.gameObject.SetActive(_playerIsDead);
            }
            if (t.gameObject.tag == "UI")
            {
                t.gameObject.SetActive(_playerIsDead);
            }
        }

        if (_playerStateChanged)
        {
            {
                StartCoroutine(SetGameplayInfoTextForTime(
                    "You have made " + monsterKillcount + " damege to monsters!\n" +
                    "It gives you " + Mathf.RoundToInt(timer.timeToEnd) + " seconds of alive time!",
                    6)
                );

                monsterKillcount = 0;

                respawnController.respawn();

                FindObjectOfType<AudioManager>().Play("hell");
            }

            foreach (Transform t in room.GetComponentInChildren<Transform>())
            {
                if (t.gameObject.tag == "Enemy") Destroy(t.gameObject);
            }
            _playerStateChanged = false;
        }
    }

    public IEnumerator SetGameplayInfoTextForTime(string text, float seconds)
    {
        gameplayInfoText.GetComponent<TextMeshProUGUI>().text = text;
        yield return new WaitForSeconds(seconds);
        gameplayInfoText.GetComponent<TextMeshProUGUI>().text = "";
    }

    IEnumerator SetMessageTextForTime(float seconds)
    {
        while (Time.time < seconds) // 2 min
        {
            if (_playerIsDead)
            {
                messageText.GetComponent<TextMeshProUGUI>().text = "You are dead.\nKill enemies to get more alive time!";
            }
            else
            {
                messageText.GetComponent<TextMeshProUGUI>().text = "You are alive.\nCollect items in chests and explore rooms!";
            }
            yield return new WaitForSeconds(1);
        }
        messageText.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void LoadMenuWithDelay(int seconds)
    {
        StartCoroutine(wait(seconds));
    }

    private IEnumerator wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        MonoBehaviour.FindObjectOfType<PauseMenu>().LoadMenu();
    }

}