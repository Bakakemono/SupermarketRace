using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject LevelSelectionPanel;
    [SerializeField]
    private GameObject OptionPanel;
    [SerializeField]
    private GameObject ScorePanel;

    private GameManager gameManager;
    private DataKeeperManager dataKeeperManager;

    [SerializeField]
    private Text textMode;
    private const string Life = "Lifes";
    private const string Timer = "Timer";

    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
        dataKeeperManager = FindObjectOfType<DataKeeperManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if (dataKeeperManager.timerMode)
        {
            textMode.text = Timer;
        }

        if (dataKeeperManager.lifesMode)
        {
            textMode.text = Life;
        }
	}

    public void PlayButton()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectionPanel.SetActive(true);
    }

    public void EasyButton()
    {
        gameManager.EasyLevel();
        dataKeeperManager.LevelOnGoing = "EasyLevelScene";
    }

    public void MediumButton()
    {
        gameManager.MediumLevel();
        dataKeeperManager.LevelOnGoing = "MediumLevelScene";
    }

    public void HardButton()
    {
        gameManager.HardLevel();
        dataKeeperManager.LevelOnGoing = "HardLevelScene";
    }

    public void BackPlayButton()
    {
        MainMenuPanel.SetActive(true);
        LevelSelectionPanel.SetActive(false);
    }

    public void BackOptionButton()
    {
        MainMenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }

    public void BackOScoreButton()
    {
        MainMenuPanel.SetActive(true);
        ScorePanel.SetActive(false);
    }


    public void OptionButton()
    {
        MainMenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void ChooseMode()
    {
        dataKeeperManager.ChooseMode();
    }

    public void ScoreButton()
    {
        MainMenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }

    public void ExitButton()
    {
        gameManager.Exit();
    }
}
