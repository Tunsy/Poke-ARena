using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private float speed = 1.0f;
    public int damage;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerHealth");
        speed = Random.Range(0.5f, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isStarted == true)
        {
            float distance = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, distance);
        }
	}

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "PlayerHealth")
        {
            setDamage();
            player.GetComponent<Health>().TakeDamage(damage);            
            Destroy(gameObject);
        }
    }

    private void setDamage()
    {
        if(gameObject.tag == "Magnemite")
        {
            damage = 10;
        }
        else if(gameObject.tag == "Voltorb")
        {
            damage = 25;
        }
        else
        {
            damage = 40;
        }
    }
}
