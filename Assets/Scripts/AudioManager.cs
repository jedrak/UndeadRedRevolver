using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public TimerManager timerManager;
    public AudioMixer audioMixer;
    private float masterVolume;
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DontDestroyOnLoad(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    void Start()
    {
        audioMixer.GetFloat("master_volume", out masterVolume);
        masterVolume += 80.0f;
        masterVolume /= 80.0f;
        masterVolume /= 6.0f; // x6 bo strasznie głośne są te dzwieki
        // Debug.Log("master volume: " + masterVolume);

        //if(timerManager._playerIsDead)
        //{
        //    Play("whiledead");
        //}
        //else
        Play("Theme");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }

        if (PauseMenu.GameIsPaused)
        {
            s.source.pitch *= 0.5f;
        }


        s.source.volume = masterVolume;

        s.source.Play();
        //Invoke("audioFinished", s.clip.length);
    }
}
