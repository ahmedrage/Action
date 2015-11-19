using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask notToHit;

	float TimeToFire = 0;
	Transform firePoint;
	Transform firePointDirection;
	
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		firePointDirection = transform.FindChild ("FirePointDirection");
		if (firePoint == null) {
			print ("Fire point missing");
		}
	}

	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			if (Input.GetButton ("Fire1") && Time.time > TimeToFire) {
				TimeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}

	void Shoot () {
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 direction = firePointDirection.position;
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, direction, 100, notToHit);
		Debug.DrawLine (firePointPosition, direction, Color.cyan);
		if (hit.collider != null){
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
		}
	}
}
