using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Pidgey;
    public GameObject Pidgeotto;
    public GameObject Pidgeot;

    private bool started = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isStarted == true && started == false)
        {
            InvokeRepeating("FireBird", 2, 4);
            started = true;
        }
	}

    void FireBird()
    {
        int num = (int)Random.Range(0f, 10f);
        Debug.Log(num % 2);
        if(num % 2 == 0)
            Instantiate(Pidgey, transform.position, transform.rotation);
    }
}
