using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private float speed = 1.0f;
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if(collider.gameObject.tag == "Player")
        {
            doDamage();
            Destroy(gameObject);
        }
    }

    private void doDamage()
    {
        if(gameObject.tag == "pidgey")
        {
            //player.health -= 10;
        }
        else if(gameObject.tag == "pidgeotto")
        {

        }
        else
        {

        }
    }
}
