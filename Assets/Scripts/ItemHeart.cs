using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHeart : Item
{
    public ItemHeart()
    {
        name = "Heart";
    }

    public override bool use()
    {
        // game win
        TimerManager tm = Component.FindObjectOfType<TimerManager>();
        tm.gameplayInfoText.GetComponent<TextMeshProUGUI>().text =
        "You tricked the Devil, you have found your HEART!\nNow you can live happy ever after.";

        Component.FindObjectOfType<RoomGenerator>().spawnMobs = false;
        EnemyHealth[] enemies = MonoBehaviour.FindObjectsOfType<EnemyHealth>();
        foreach (var enemy in enemies)
        {
            MonoBehaviour.Destroy(enemy.gameObject);
        }

        BulletController[] enemieBullet = MonoBehaviour.FindObjectsOfType<BulletController>();
        foreach (var bullet in enemieBullet)
        {
            MonoBehaviour.Destroy(bullet.gameObject);
        }

        tm._playerIsDead = false;
        tm.timer.timeToEnd = 60;

        tm.LoadMenuWithDelay(60);

        // time stop
        // Time.timeScale = 0.0f;
        return true;
    }
}
