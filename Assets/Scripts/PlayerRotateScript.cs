using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerRotateScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

	private Button spinButton;
	private GameObject squirtle;
	public bool buttonPressed;
	float y;
	// Use this for initialization
	void Start () {
		spinButton = GetComponent<Button>();
		squirtle = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (buttonPressed) {
			y = squirtle.transform.rotation.eulerAngles.y;
//			if (y >= -180) {
				Click ();
//			}
		}
	}
		

	public void OnPointerDown(PointerEventData eventData){
		buttonPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		buttonPressed = false;
	}

	void Click(){
		if (GameManager.instance.isStarted) {
//			float y = squirtle.transform.rotation.eulerAngles.y;
//			if (y >= -90 && y<=90) {
				squirtle.transform.Rotate (Vector3.up * 5);
//			}
		}

	}

}
