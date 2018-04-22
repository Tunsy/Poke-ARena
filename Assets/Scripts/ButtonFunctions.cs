using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	private GameObject shooter;

    public void nextLevel()
    {
//		Debug.Log (GameManager.instance.getActive());
		if (GameManager.instance.getActive () == "pikachu") {
			Debug.Log ("hfasoeijfoaisejfosae");
			shooter = GameObject.FindGameObjectWithTag ("Pikachu Projectile");
			shooter.SetActive (true);
//			shooter = shooter.GetComponent<PlayerShooterScript> ();
//			shooter.enabled (true);
		}
//		} else if (GameManager.instance.getActive () == "magikarp") {
//			shooter = GameObject.FindGameObjectWithTag ("Magikarp Projectile");
//			shooter.SetActive (true);
//		} else{
//			shooter = GameObject.FindGameObjectWithTag ("Cyndaquil Projectile");
//			shooter.SetActive (true);
//		}

        SoundManager.instance.PlayBattleMusic();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager.level++;
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
    }
}
