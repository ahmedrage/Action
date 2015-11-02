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
	void Start () {
		move = Input.GetAxis ("Horizontal");
		playerGraphics = transform.FindChild("Rob");
		facingRight = true;
	}
	void Update () {
		Move ();
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

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

	}

	void Flip () {
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = playerGraphics.localScale;
		theScale.x *= -1;
		playerGraphics.localScale = theScale;
	}

}

//GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);