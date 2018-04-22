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
			Click ();
		}
//		Debug.Log (squirtle.transform.eulerAngles.y);

//		if (squirtle.transform.eulerAngles.y < -90) {
//			squirtle.transform.rotation = Quaternion.Euler(0, -88, 0);
//		}
//		if (squirtle.transform.localEulerAngles.y > 270) {
//			squirtle.transform.rotation = Quaternion.Euler(0, 88, 0);
//		}
	}
		

	public void OnPointerDown(PointerEventData eventData){
		buttonPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		buttonPressed = false;
	}

	void Click(){
		if (GameManager.instance.isStarted) {

				squirtle.transform.Rotate (Vector3.up * 5);

		}

	}

}
