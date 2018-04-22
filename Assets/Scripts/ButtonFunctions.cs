using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

public void nextLevel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager.level++;
    }
}
