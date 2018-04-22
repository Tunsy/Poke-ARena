using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterThunderGun : MonoBehaviour {

	public Rigidbody shot;
	public float fireRate;
	private float nextFire;
	public float speed;
	public Transform facingTransform;
	public bool powerUp=false;

	void Start(){
		Debug.Log ("hi there ");
		Debug.Log (GameManager.instance.getActive ());
		if (GameManager.instance.getActive () != "pikachu") {
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
