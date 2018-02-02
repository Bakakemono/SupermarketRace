using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Speed")]
    [SerializeField]
    private Text speedText;
    private const string TEXT_SPEED = " km/h";

    [Header("Timer")]
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timer = 120.0f;
    private const string TIMER_TEXT = " Seconds left";

    [Header("Life")]
    [SerializeField]
    private Text lifeText;
    private const string LIFE_TEXT = " remaining articles";

    private PlayerControlerTest playerController;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerControlerTest>();
    }

    // Update is called once per frame
    void Update()
    {

        speedText.text = Mathf.Round(playerController.speed * 3.6f) + TEXT_SPEED;
        timer -= Time.deltaTime;
        timerText.text = Mathf.Round(timer) + TIMER_TEXT;
        lifeText.text = playerController.playerLife + LIFE_TEXT;
        if (timer <= 0 || playerController.playerLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
