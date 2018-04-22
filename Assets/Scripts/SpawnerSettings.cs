using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSettings : MonoBehaviour {
    public GameObject spawner2;
    public GameObject spawner3;


	// Use this for initialization
	void Start () {
		spawner2.SetActive(true);
        spawner3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.isStarted == true && GameManager.instance.level == 2)
        {
            spawner3.SetActive(true);
        }
//        else if (GameManager.instance.isStarted == true && GameManager.instance.level == 3)
//        {
//            spawner3.SetActive(true);
//        }
    }
}
