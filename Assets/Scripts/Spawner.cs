using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Magnemite;
    public GameObject Magneton;
    public GameObject Voltorb;

    private bool started = false;
    private int interval;

	// Use this for initialization
	void Start () {
        interval = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isStarted == true && started == false)
        {
            InvokeRepeating("FireBird", 2, interval);
            started = true;
        }
        if (GameManager.level == 2)
            interval = 2;
        else if (GameManager.level == 3)
            interval = 1;
	}

    void FireBird()
    {
        int num = (int)Random.Range(0f, 100f);
        Debug.Log(GameManager.level);
        if (num % 2 == 0)
        {
            if (GameManager.level == 1)
            {
                Instantiate(Magnemite, transform.position, transform.rotation);
            }
            else if(GameManager.level == 2)
            {
                Instantiate(Voltorb, transform.position, transform.rotation);
            }
            else if(GameManager.level == 3)
            {
                Instantiate(Magneton, transform.position, transform.rotation);
            }
            else { }
        }
    }
}
