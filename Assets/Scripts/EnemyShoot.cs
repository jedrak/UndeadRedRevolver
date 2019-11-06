using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShoot : MonoBehaviour
{


    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float cooldown;

    private AIPath path;
    private float _lastTime;

    private void Start()
    {
        path = GetComponent<AIPath>();
    }
    void FixedUpdate()
    {
        if (path.reachedEndOfPath || path.remainingDistance < 1)
        {
            if (Time.time > _lastTime + cooldown)
            {
                float x = path.target.position.x - transform.position.x;
                float y = path.target.position.y - transform.position.y;
                Vector3 v = new Vector3(x, y);
                //v = v.normalized;
                Shoot(v.x, v.y);
                _lastTime = Time.time;
            }
        }
    }


    void Shoot(float x, float y)
    {
        float shotAngle = Vector3.Angle(new Vector3(x, y), Vector3.right);
        GameObject bullet;
        if (y < 0)
        {
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -shotAngle)) as GameObject;
        }
        else
        {
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, shotAngle)) as GameObject;
        }

        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
              (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed);

    }


}
