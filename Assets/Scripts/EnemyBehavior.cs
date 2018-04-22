using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private float speed = 1.0f;
    public int damage;
    private GameObject player;
	private int points;

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 2f);
		setPoints ();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isStarted == true)
        {
            player = GameManager.instance.healthLevels[GameManager.instance.getActive()];
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
            Debug.Log(player.GetComponent<Health>().currentHealth);            
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
	private void setPoints(){
		if(gameObject.tag == "Magnemite")
		{
			points = 10;
		}
		else if(gameObject.tag == "Voltorb")
		{
			points = 25;
		}
		else
		{
			points = 40;
		}
	}
	public int getPoints(){
		return points;
	}
}
