using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();
    public AudioClip victorySound;

    public bool isStarted = false;
    public bool isGameOver = false;
    public int score = 0;
    public int level = 1;

    public Dictionary<string, GameObject> healthLevels = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> projectiles = new Dictionary<string, GameObject>();
    public GameObject levelButton;
    public GameObject deathScreen;


    private Text scoreState;
    public AudioClip spawnAudio;

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

        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        levelButton = GameObject.FindGameObjectWithTag("LevelButton");
        deathScreen = GameObject.FindGameObjectWithTag("Death");
        deathScreen.SetActive(false);
        levelButton.SetActive(false);
        scoreState = GameObject.FindGameObjectWithTag("ScoreState").GetComponent<Text>();
        scoreState.text = "Count: " + score.ToString();
        int i = 0;
        Debug.Log("Starting 23");

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerHealth"))
        {
            healthLevels.Add(obj.name, obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(obj.name, obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GeneralProjectile"))
        {
            Debug.Log(obj.name);
            projectiles.Add(obj.name, obj);
        }

        foreach (string key in projectiles.Keys)
        {
            projectiles[key].gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (score >= 50 && level == 1)
        {
            SoundManager.instance.StopMusic();
            SoundManager.instance.PlaySingle(victorySound);
            Time.timeScale = 0f;
            levelButton.SetActive(true);
            GameManager.instance.level = 2;
        }

        else if (score >= 250 && level == 2)
        {
            SoundManager.instance.PlaySingle(victorySound);
            Time.timeScale = 0f;
            levelButton.SetActive(true);
            GameManager.instance.level = 3;
        }

    }

    public void StartGame()
    {
        SoundManager.instance.PlaySingle(spawnAudio);
        Time.timeScale = 0f;
        levelButton.SetActive(true);
        isStarted = true;
    }

    public void EndGame()
    {
        isGameOver = true;
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore(int scoreIncrement)
    {
        score += scoreIncrement;
        scoreState.text = "Count: " + score.ToString();

    }

    public string getActive()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();

        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in activeTrackables)
        {
            return tb.TrackableName;
        }
        return "";
    }

    public void ResetProjectiles()
    {
        foreach (string obj in GameManager.instance.projectiles.Keys)
        {
            GameManager.instance.projectiles[obj].gameObject.SetActive(false);
        }
    }
}
