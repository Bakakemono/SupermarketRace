using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour {

    [Header("Score")]
    [SerializeField]
    private Text[] ScoreDisplay;

    private const string FIRST = "1st : ";
    private const string SECOND = "2nd : ";
    private const string THIRD = "3rd : ";
    private const string FOURTH = "4th : ";
    private const string FIFTH = "5th : ";
    private const string SECONDS = " seconds";


    private DataKeeperManager dataKeeperManager;

	// Use this for initialization
	void Start () {
        dataKeeperManager = FindObjectOfType<DataKeeperManager>();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreDisplay[0].text = FIRST + dataKeeperManager.firstScore + SECONDS;
        ScoreDisplay[1].text = SECOND + dataKeeperManager.secondScore + SECONDS;
        ScoreDisplay[2].text = THIRD + dataKeeperManager.thirdScore + SECONDS;
        ScoreDisplay[3].text = FOURTH + dataKeeperManager.fourthScore + SECONDS;
        ScoreDisplay[4].text = FIFTH + dataKeeperManager.secondScore+ SECONDS;


    }
}
