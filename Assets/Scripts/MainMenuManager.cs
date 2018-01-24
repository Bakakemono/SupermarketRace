using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject LevelSelectionPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButton()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectionPanel.SetActive(true);
    }

    public void EasyButton()
    {

    }

    public void MediumButton()
    {

    }

    public void HardButton()
    {
        SceneManager.LoadScene("HardLevelScene");
    }

    public void BackButton()
    {
        MainMenuPanel.SetActive(true);
        LevelSelectionPanel.SetActive(false);
    }

    public void ScoreButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
