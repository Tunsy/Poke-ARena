using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerRotateScript2 : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

	private Button spinButton;
	private GameObject pokemon;
	public bool buttonPressed;
	float y;
	// Use this for initialization
	void Start () {
		spinButton = GetComponent<Button>();
	}

	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isStarted)
        {
            if(GameManager.instance.getActive() != null)
                pokemon = GameManager.instance.players[GameManager.instance.getActive()];
            if (buttonPressed)
            {
                y = pokemon.transform.rotation.eulerAngles.y;
                //			if (y <= 180) {
                Click();
                //			}
            }
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
				pokemon.transform.Rotate (Vector3.up * -5);
		}

	}
}
