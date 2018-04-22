using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();

    public bool isStarted = false;
    public bool isGameOver = false;
    public int score = 0;
    public int level = 1;

    public Dictionary<string, GameObject> healthLevels = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> projectiles = new Dictionary<string, GameObject>();
    public GameObject levelButton;
    public GameObject deathScreen;


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

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("PlayerHealth"))
        {
            healthLevels.Add(obj.name, obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(obj.name, obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GeneralProjectile"))
        {
            projectiles.Add(obj.name, obj);
        }
    }

    private void Update()
    {
        if(score >= 150 && level == 1)
        {
            Time.timeScale = 0f;
            levelButton.SetActive(true);
            GameManager.instance.level = 2;
        }

        else if (score >= 500 && level == 2)
        {
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
}
