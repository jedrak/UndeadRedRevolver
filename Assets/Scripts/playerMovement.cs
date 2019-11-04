using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Vector2 playerInput;
    Rigidbody2D rb;

    public float moveSpeed;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float FireDelay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
           playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput.normalized * moveSpeed;
        float shootHor = Input.GetAxisRaw("Horizontalshoot");
        float shootVert = Input.GetAxisRaw("Verticalshoot");
        if((shootHor!=0||shootVert!=0) && Time.time>lastFire +FireDelay)
            {
            Shoot(shootHor, shootVert);
            lastFire = Time.time;
        }
    }
    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
              (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed);

    }
}