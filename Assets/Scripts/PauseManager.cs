using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    private GameObject HudPanel;
    [SerializeField]
    private GameObject PausePanel;

    private bool IsOnpause = false;
    private int Cooldown = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Pause") && !IsOnpause && Cooldown == 0)
        {
            PauseGame();
            Cooldown = 1;
        }
        if (Input.GetButtonDown("Pause") && IsOnpause && Cooldown == 0)
        {
            ResumeButton();
            Cooldown = 1;
        }

        Cooldown--;
        if (Cooldown <= 0)
        {
            Cooldown = 0;
        }
        
    }

    public void PauseGame()
    {
        HudPanel.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsOnpause = true;
    }

    public void ResumeButton()
    {
        HudPanel.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        IsOnpause = false;
    }
}
