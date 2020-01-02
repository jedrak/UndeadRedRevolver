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
	int type = 0;
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
		
		if (Input.GetKeyDown(KeyCode.Q))
		{
			
			type++;
			if (type > 2)
			{
				type = 0;
			}
			
		}
		if (type == 0)
		{
			rend.sprite = pistol;
			
		}
		else if (type == 1)
		{
			rend.sprite = shotgun;

		}
		else if (type == 2)
		{
			rend.sprite = riffle;
			

		}
		if (rotZ<90||rotZ>270)
		{
			anim.SetTrigger("Right_Idle");
			//Vector3 theScale = gun.localScale;
			//theScale.y = 1;
			//gun.localScale = theScale;
		}
		else
		{
			//Vector3 theScale = gun.localScale;
			//theScale.y = -1;
			//gun.localScale = theScale;
			//anim.SetTrigger("Left_Idle");

		}

			
	}
}
