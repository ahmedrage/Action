using UnityEngine;
using System.Collections;

public class armRotation : MonoBehaviour {

	public int rotationOffset;
	public float mousePos;
	public MyCharacterController characterController;

	void Update () {
		//rotationOffset = characterController.armRotationOffset;
		mousePos = Input.mousePosition.x;
		Vector3 differince = Camera.main.ScreenToWorldPoint (Input.mousePosition) + transform.position;
		differince.Normalize ();

		float rotZ = Mathf.Atan2 (differince.y, differince.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);

	}
}
