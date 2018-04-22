using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarStatus : MonoBehaviour {

    private float baseScale;
    private float currentScale;
    public Transform transform;
    public Health health;

	// Use this for initialization
	void Start () {
        baseScale = gameObject.transform.localScale.z;
        currentScale = baseScale;
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateSize()
    {
        if (health.isAlive)
        {
            float healthFloat = health.currentHealth / (float)health.maxHealth;
            currentScale = healthFloat * baseScale;
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, currentScale);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
        }
    }
}
