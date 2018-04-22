using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour {

    public AudioClip titleSong;

	// Use this for initialization
	void Start () {
        SoundManager.instance.PlayMusic(titleSong);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
