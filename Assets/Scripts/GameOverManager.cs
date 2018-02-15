using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    private float filledPercents = 0.0f;
    private const float ADDSECONDS = 0.01f;
    private const float WAITINGTIME = 3.0f;
    private const float TIMETOFILL = 0.03f;
    [SerializeField]
    private Image curtain;
    [SerializeField]
    private GameObject buttonPanel;
    private bool wait = true;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        StartCoroutine(Fill());
        StartCoroutine(WaitDisplay());
        gameManager = FindObjectOfType<GameManager>();
	}

    private IEnumerator Fill()
    {
        while (true)
        {
            filledPercents += ADDSECONDS;
            curtain.fillAmount = filledPercents;
            yield return new WaitForSeconds(TIMETOFILL);
        }
    }

    private IEnumerator WaitDisplay()
    {
        while (wait == true)
        {
            yield return new WaitForSeconds(WAITINGTIME);
            buttonPanel.SetActive(true);
            wait = false;
        }
    }

    public void Retry()
    {
        gameManager.Retry();
    }

    public void BackToMainMenu()
    {
        gameManager.BackToMenu();
    }
}
