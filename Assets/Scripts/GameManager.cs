using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("TextMode")]
    [SerializeField]
    private Text textMode;

    [Header("Speed")]
    [SerializeField]
    private Text speedText;
    private const string TEXT_SPEED = " km/h";
    private float convertSpeed = 3.6f;
    private int maxSpeed = 100;

    [Header("Timer")]
    [SerializeField]
    private float timer = 120.0f;
    private const string TIMER_TEXT = " Seconds left";
    private float timerMax;
    public float playerTimeScore;

    [Header("Life")]
    private const string LIFE_TEXT = " remaining articles";
    private PlayerControlerTest playerController;

    private DataKeeperManager dataKeeperManager;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerControlerTest>();
        dataKeeperManager = FindObjectOfType<DataKeeperManager>();

        timerMax = timer;
    }

    // Update is called once per frame
    void Update()
    {
        float speed  = 0;
        if (playerController != null)
        speed = playerController.speed * convertSpeed;

        if(speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        if (speed <= 0)
        {
            speed = 0;
        }
        if(speedText != null)
        speedText.text = Mathf.Round(speed) + TEXT_SPEED;

        if(dataKeeperManager.timerMode)
        {
            timer -= Time.deltaTime;
            textMode.text = Mathf.Round(timer) + TIMER_TEXT;
        }

        if (dataKeeperManager.lifesMode)
        {
            textMode.text = playerController.playerLife + LIFE_TEXT;
        }

        if (playerController.playerLife <= 0 && dataKeeperManager.lifesMode)
        {
            Lose();
        }

        if (timer <= 0 && dataKeeperManager.timerMode)
        {
            Lose();
        }

    }

    public void EasyLevel()
    {
        SceneManager.LoadScene("EasyLevelScene", LoadSceneMode.Single);
        dataKeeperManager.IsNotHardLevel();
    }

    public void MediumLevel()
    {
        SceneManager.LoadScene("MediumLevelScene", LoadSceneMode.Single);
        dataKeeperManager.IsNotHardLevel();

    }

    public void HardLevel()
    {
        SceneManager.LoadScene("HardLevelScene", LoadSceneMode.Single);
        dataKeeperManager.IsHardLevel();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenuScene", LoadSceneMode.Single);
        dataKeeperManager.IsNotHardLevel();

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(dataKeeperManager.LevelOnGoing, LoadSceneMode.Single);
    }
    
    public void Lose()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }

    public void Win()
    {
        SceneManager.LoadScene("WinScene", LoadSceneMode.Single);

        if (dataKeeperManager.isHardLevel && dataKeeperManager.timerMode)
        {
            dataKeeperManager.tmpScore = Mathf.RoundToInt(timerMax - timer);
            dataKeeperManager.ScoreboardCheck();
        }
    }
}
