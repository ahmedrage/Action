using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour {
	public Rigidbody2D Rb;
	public GameObject Player;
	public bool grounded;
	public float Speed;
	public float jumpForce;
	void Start () {
	}
	void Update () {
		Move ();
	}
	void Move () {
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

		Vector3 pos = Player.transform.position;
		pos.x = pos.x + Input.GetAxis ("Horizontal") /100 * Speed ;
		Player.transform.position = pos ;
	}

}

