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
    public int score { get; set; }
    public GameObject killCountText;
    public GameObject scoreText;
    public GameObject messageText;
    public GameObject gameplayInfoText;
    public RespawnController respawnController;
    public Material mat;

    private void Start()
    {
        _playerIsDead = true;
        mat.SetFloat("blendDuration", 1.0f);
        monsterKillcount = 0;
        score = 0;
        gameplayInfoText.GetComponent<TextMeshProUGUI>().text = "Move with WSAD, shoot with Arrows Keys";
    }

    void FixedUpdate()
    {
        if (Time.time > 10) gameplayInfoText.GetComponent<TextMeshProUGUI>().text = "";

        killCountText.SetActive(_playerIsDead);
        scoreText.SetActive(!_playerIsDead);
        if (_playerIsDead)
        {
            messageText.GetComponent<TextMeshProUGUI>().text = "You are dead.\nKill enemies to get more alive time!";
        }
        else
        {
            messageText.GetComponent<TextMeshProUGUI>().text = "You are alive.\nCollect items in chests and explore rooms!";
        }
        if (timer.timeToEnd < 0)
        {
            FindObjectOfType<AudioManager>().Play("morde");

            _playerIsDead = true;
            _playerStateChanged = true;
            mat.SetFloat("startTime", Time.time);
        }
        if (_playerIsDead)
        {
            foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
            {
                sp.color = new Color(.7f, .5f, .5f, 1.0f);
            }
            timer.timeToEnd = monsterKillcount * 2;
            score = 0;

        }
        else
        {
            foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
            {
                sp.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

            //timer.timeToEnd = 10 + 2 * monsterKillcount;
            monsterKillcount = 0;

        }

        foreach (Transform t in room.GetComponentInChildren<Transform>())
        {
            //Debug.Log(t.gameObject, this);
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
            if (!_playerIsDead)
            {
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
}
