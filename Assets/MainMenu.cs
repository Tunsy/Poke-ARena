using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public AudioClip buttonClick;

	public void PlayGame()
    {
        StartCoroutine("StartGame");
    }

    public IEnumerator StartGame()
    {
        SoundManager.instance.PlaySingle(buttonClick);
        while (SoundManager.instance.efxSource.isPlaying)          // while audio is playing,
        {
            yield return null;                        // chill out in here.
        }
        SceneManager.LoadScene("main");  // then, continue on.
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
