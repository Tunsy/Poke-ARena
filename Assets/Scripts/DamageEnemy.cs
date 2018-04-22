using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {


	public int damageAmount;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) 
	{
		if(other.gameObject.GetComponent<EnemyBehavior>() != null)
		{
			Debug.Log ("trigger collision");
			EnemyBehavior script = other.gameObject.GetComponent<EnemyBehavior>() as EnemyBehavior;
			int score = script.getPoints ();

			//GameManager.instance.AddScore(score);
			Destroy (other.gameObject);
		}
	}
}
