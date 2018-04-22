using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ResetToCamera();
	}

    public void ResetToCamera()
    {
        transform.position = Camera.main.transform.position;
    }
}
