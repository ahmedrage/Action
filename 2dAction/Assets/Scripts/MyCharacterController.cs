using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour {
	public Rigidbody2D Rb;
	public GameObject Player;
	public bool grounded;
	public float Speed;
	public float jumpForce;
	private float move;
	public bool facingRight;
	public Transform playerGraphics;
	public Transform arm;
	public float armOffset;
	public Animator animator;
	public float isMoving;
	public Transform cursor;
	public Quaternion armRotation;
	public armRotation ArmRotation;
	public int armRotationOffset;
	public float killFloor;

	void Start () {
		move = Input.GetAxis ("Horizontal");
		playerGraphics = transform.FindChild("Rob");
		arm = transform.FindChild ("RobArm");
		facingRight = true;
	}
	void Update () {
		armRotation = arm.rotation;
		cursor.position = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

		if (move != 0) {
			isMoving = 1;
		} else {
			isMoving = 0;
		}

		Animate ();
		Move ();

		if (transform.position.y < killFloor ) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	void Move () {
		move = Input.GetAxis ("Horizontal");

		// Jumping
		if (Rb.velocity.y == 0)
			grounded = true;
		else
			grounded = false;

		Vector2 jumpPos = new Vector2 (0,jumpForce * 100); // Calculating the jump force

		if (Input.GetButtonDown ("Jump") && grounded == true) { // Checking for jump
			Rb.AddForce (jumpPos); // Jumping
		}
		// End Jumping

		// Movement

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * Speed, GetComponent<Rigidbody2D>().velocity.y);

		if (cursor.position.x > transform.position.x && !facingRight) {
			//if(Rb.position.x != 0)
			//arm.position = new Vector2 (arm.position.x + armOffset, arm.position.y);

			Flip ();
			armRotationOffset = 0;
		} else if (cursor.position.x < playerGraphics.position.x && facingRight) {
			//if(Rb.position.x != 0) 
			//arm.position = new Vector2 (arm.position.x - armOffset, arm.position.y);

			Flip ();
			armRotationOffset = 180;
		}

	}

	void Flip () {
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		//Vector3 armScale = arm.localScale;
		//armRotation = arm.rotation;
		theScale.x *= -1;
		//armScale.x *= -1;
		transform.localScale = theScale;
		//arm.localScale = armScale;
	}

	void FixedUpdate () {
		arm.rotation = armRotation;

	}

	void Animate() {

		animator.SetFloat ("playerSpeed", isMoving);
		animator.SetBool ("Grounded", grounded);
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print ("Detected");
		Application.LoadLevel (Application.loadedLevel);
	} 


	}



