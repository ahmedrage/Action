using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float fireRate = 0;
	public float Damage = 10;
	//public LayerMask notToHit;

	public float randomMax;
	public float randomMin;

	public float kickBack;

	float random;


	float TimeToFire = 0;
	Transform firePoint;
	Transform gun;
	public string gunName;
	Transform firePointDirection;
	
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		firePointDirection = transform.FindChild ("FirePointDirection");
		gunName = "Gun01";
		gun = transform.FindChild ("Gun02");
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

		//kickBack = 1;
		random = Random.Range (randomMin, randomMax);
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 direction = new Vector2 (firePointDirection.position.x, firePointPosition.y + random);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, direction, 100);
		Debug.DrawLine (firePointPosition, direction, Color.cyan);
		if (hit.collider != null){
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
		}
		//Vector2 kickBackStart = new Vector2 (transform.position.x - kickBack, transform.position.y);
		//Vector2 kickBackEnd = new Vector2 (transform.position.x + kickBack, transform.position.y);

		//transform.localPosition = Vector2.Lerp (new Vector2 (transform.localPosition.x - kickBack, transform.localPosition.y), new Vector2 (transform.localPosition.x + kickBack, transform.localPosition.y), 1000);
		//transform.localPosition = Vector2.Lerp (new Vector2 (transform.localPosition.x + kickBack, transform.localPosition.y), new Vector2 (transform.localPosition.x - kickBack, transform.localPosition.y), 1000);
	}
}
