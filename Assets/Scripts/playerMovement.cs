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
    public int magazinesize=6;
    private float lastFire;
    public float FireDelay;
    public float ReloadDelay=0;
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
        if((shootHor!=0||shootVert!=0) && Time.time>lastFire +FireDelay+ ReloadDelay)
        {
            ReloadDelay = 0;
            if (magazinesize>0)
            {
                Shoot(shootHor, shootVert);
                magazinesize--;
               
            }
            else
            {
                
                FindObjectOfType<AudioManager>().Play("reload");
                magazinesize = 6;
                ReloadDelay = 0.5f;
            }
            lastFire = Time.time;
        }
    }
    void Shoot(float x, float y)
    {
        int rand = Random.Range(1, 7);
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
        FindObjectOfType<AudioManager>().Play("gunshot"+rand);
       

    }
}