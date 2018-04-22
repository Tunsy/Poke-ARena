using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterWaterGun : MonoBehaviour {

	public Rigidbody shot;
	public float fireRate;
	private float nextFire;
	public float speed;
	public Transform facingTransform;
	public bool powerUp=false;

	// Use this for initialization
	void Awake () {
		if (GameManager.instance.getActive () != "Magikarp") {
			this.gameObject.SetActive (false);
		}
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
			bullet.velocity = bullet.transform.forward * speed;


		}

	}

}
