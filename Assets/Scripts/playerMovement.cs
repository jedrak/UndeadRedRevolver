using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerMovement : MonoBehaviour
{

    public Vector2 playerInput;
    Rigidbody2D rb;
    Animator anim;
    public float moveSpeed;

    public Rigidbody2D center;
    Transform firePoint;
    public Camera cam;

    Vector2 mousePos;
    List<GameObject> bullets = new List<GameObject>();

    // Start is called before the first frame update

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // Vector2 LookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;
        //   rb.rotation = angle;



         playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput.normalized * moveSpeed;
        //MoveDown();
        MoveLeft();
        MoveRight();
        //MoveUp();

    }
    void MoveUp()
    {
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Back_move");
        }
        if (Input.GetKeyUp(KeyCode.W)&& !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Back_Idle");
        }
    }
    void MoveDown()
    {
       
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Front_move");
        }
        if (Input.GetKeyUp(KeyCode.S) && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Front_Idle");
        }
    }
    void MoveLeft()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Left_move");
        }
        //if (Input.GetKeyUp(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.D))
        //{
        //    anim.SetTrigger("Left_Idle");
        //}
    }
    void MoveRight()
    {
      
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Right_move");
        }
        //if (Input.GetKeyUp(KeyCode.D) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.W))
        //{
        //    anim.SetTrigger("Right_Idle");
        //}
    }

}