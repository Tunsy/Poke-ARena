using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    public void nextLevel()
    {
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
