using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterScript : MonoBehaviour {

	public Rigidbody shot;
	public float fireRate;
	private float nextFire;
	public float speed;
	public Transform facingTransform;
	public bool powerUp=false;

	// Use this for initialization
	void Start () {
		
	}
	
//	 Update is called once per frame
	void Update () {
		if (GameManager.instance.isStarted && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Rigidbody bullet= Instantiate(shot, transform.position, facingTransform.rotation) as Rigidbody;
			if (powerUp) {
				Rigidbody bullet1= Instantiate(shot, transform.position, facingTransform.rotation) as Rigidbody;
				bullet.velocity = bullet.transform.forward * (speed);
				Rigidbody bullet2= Instantiate(shot, transform.position, facingTransform.rotation) as Rigidbody;
				bullet.velocity = bullet.transform.forward * (speed);
			}
//			bullet.transform.localEulerAngles = new Vector3 (90, 0,0);
//			Vector3 dir = Quaternion.AngleAxis(transform.parent.transform.eulerAngles.z, Vector3.forward) * Vector3.right;
//			bullet.AddForce(dir*100);
//			bullet.AddForce (0, 0, 100);
			bullet.velocity = bullet.transform.forward * speed;


		}
		
	}

//	void Fire ()
//	{
//		Instantiate(shot, transform.position, transform.rotation);
//	}
}
