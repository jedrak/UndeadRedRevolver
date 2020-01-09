using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRotation : MonoBehaviour
{
    Animator anim;
    float rotationOffset = 0f;
    Transform gun;
    private SpriteRenderer rend;
    private Sprite pistol, shotgun, riffle;
    void Start()
    {

        gun = GetComponentInChildren<Transform>();
        anim = GetComponentInParent<Animator>();
        rend = GetComponentInChildren<SpriteRenderer>();
        pistol = Resources.Load<Sprite>("Revolver1");
        riffle = Resources.Load<Sprite>("Riffle1");
        shotgun = Resources.Load<Sprite>("Shotgun1");
        rend.sprite = pistol;
    }

    // Update is called once per frame
    void Update()
    {
        // subtracting the position of the player from the mouse position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // find the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        if (rotZ < 90 && rotZ > -90)
        {
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                anim.SetTrigger("Right_move");
            else
                anim.SetTrigger("Right_Idle");
            //Vector3 theScale = gun.localScale;
            //theScale.y = 1;
            //gun.localScale = theScale;
        }
        else if (rotZ > 90 || rotZ < -90)
        {
            //Vector3 theScale = gun.localScale;
            //theScale.y = -1;
            //gun.localScale = theScale;
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                anim.SetTrigger("Left_move");
            else
                anim.SetTrigger("Left_Idle");
        }


    }

    public void weaponChanged(string weaponName)
    {
        if (weaponName.Equals("Revolver"))
        {
            rend.sprite = pistol;

        }
        else if (weaponName.Equals("Shotgun"))
        {
            rend.sprite = shotgun;

        }
        else if (weaponName.Equals("Riffle"))
        {
            rend.sprite = riffle;
        }
    }
}
