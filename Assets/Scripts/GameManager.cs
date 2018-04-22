using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();

    public bool isStarted = false;
    public bool isGameOver = false;
    public int score = 0;
    public static int level = 1;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void StartGame()
    {
        isStarted = true;
    }

    public void EndGame()
    {
        isGameOver = true;
    }

    public void AddScore(int scoreIncrement)
    {
        score += scoreIncrement;
    }
}
