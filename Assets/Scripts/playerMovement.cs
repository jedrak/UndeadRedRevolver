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
    public int magazinesize = 6;
    private float lastFire;
    public float FireDelay;
    public string weapon = "Revolver";
    public float ReloadDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Play("shotgun");
        }
    }
    void FixedUpdate()
    {
       
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput.normalized * moveSpeed;
        float shootHor = Input.GetAxisRaw("Horizontalshoot");
        float shootVert = Input.GetAxisRaw("Verticalshoot");
        if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + FireDelay + ReloadDelay)
        {
            ReloadDelay = 0;
            
            Shoot(shootHor, shootVert);
            magazinesize--;

            if (magazinesize == 0)
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

        if (weapon.Equals("Obrzyn"))
        {
            List<GameObject> bullets = new List<GameObject>();
            if (y < 0)
            {
                shotAngle = -shotAngle;
            }
            bullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, shotAngle + 10)) as GameObject);
            bullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, shotAngle)) as GameObject);
            bullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, shotAngle - 10)) as GameObject);

            float dx = 0, dy = 0;
            //lewy
            if (x < 0)
            {
                dx += (Mathf.Floor(x)) * bulletSpeed;
                dy -= 1;
            }
            else
            {
                dx += (Mathf.Ceil(x)) * bulletSpeed;
                dy += 1;
            }
            if (y < 0)
            {
                dy += (Mathf.Floor(y)) * bulletSpeed;
                dx += 1;
            }
            else
            {
                dy += (Mathf.Ceil(y)) * bulletSpeed;
                dx -= 1;
            }
            bullets[0].AddComponent<Rigidbody2D>().gravityScale = 0;
            bullets[0].GetComponent<Rigidbody2D>().velocity = new Vector3(dx, dy);
            FindObjectOfType<AudioManager>().Play("shotgun" );

            //środek
            bullets[1].AddComponent<Rigidbody2D>().gravityScale = 0;
            bullets[1].GetComponent<Rigidbody2D>().velocity = new Vector3(
                (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed);
            FindObjectOfType<AudioManager>().Play("shotgun" );

            // prawy
            dx = 0;
            dy = 0;
            if (x < 0)
            {
                dx += (Mathf.Floor(x)) * bulletSpeed;
                dy += 1;
            }
            else
            {
                dx += (Mathf.Ceil(x)) * bulletSpeed;
                dy -= 1;
            }
            if (y < 0)
            {
                dy += (Mathf.Floor(y)) * bulletSpeed;
                dx -= 1;
            }
            else
            {
                dy += (Mathf.Ceil(y)) * bulletSpeed;
                dx += 1;
            }
            bullets[2].AddComponent<Rigidbody2D>().gravityScale = 0;
            bullets[2].GetComponent<Rigidbody2D>().velocity = new Vector3(dx, dy);
            FindObjectOfType<AudioManager>().Play("shotgun" );
        }
        else // default == "Revolver"
        {
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
            FindObjectOfType<AudioManager>().Play("gunshot" + rand);
        }
    }
}