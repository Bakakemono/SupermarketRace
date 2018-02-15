using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeperManager : MonoBehaviour {

    public bool timerMode = true;
    public bool lifesMode = false;

    public string LevelOnGoing;
    
    public int firstScore = 0;
    public int secondScore = 0;
    public int thirdScore = 0;
    public int fourthScore = 0;
    public int fifthScore = 0;
    public int tmpScore = 0;


    public bool isHardLevel = false;

    // Use this for initialization
    void Start () {

        firstScore = PlayerPrefs.GetInt("firstScore");
        secondScore = PlayerPrefs.GetInt("secondScore");
        thirdScore = PlayerPrefs.GetInt("thirdScore");
        fourthScore = PlayerPrefs.GetInt("fourthScore");
        fifthScore = PlayerPrefs.GetInt("fifthScore");

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseMode()
    {
        bool tmpSwitch = false;
        if(timerMode && !tmpSwitch)
        {
            timerMode = false;
            lifesMode = true;
            tmpSwitch = true;
        }

        if(lifesMode && !tmpSwitch)
        {
            timerMode = true;
            lifesMode = false;
            tmpSwitch = true;
        }
    }

    public void ScoreboardCheck()
    {
        if(tmpScore <= firstScore || firstScore == 0)
        {
            fifthScore = fourthScore;
            fourthScore = thirdScore;
            thirdScore = secondScore;
            secondScore = firstScore;
            firstScore = tmpScore;
        }

        else if (tmpScore <= secondScore || secondScore == 0)
        {
            fifthScore = fourthScore;
            fourthScore = thirdScore;
            thirdScore = secondScore;
            secondScore = tmpScore;
        }
        else if (tmpScore <= thirdScore || thirdScore == 0)
        {
            fifthScore = fourthScore;
            fourthScore = thirdScore;
            thirdScore = tmpScore;
        }

        else if (tmpScore <= fourthScore || fourthScore == 0)
        {
            fifthScore = fourthScore;
            fourthScore = tmpScore;
        }

        else if (tmpScore <= fifthScore || fifthScore == 0)
        {
            fifthScore = tmpScore;
        }

        PlayerPrefs.SetInt("firstScore", firstScore);
        PlayerPrefs.SetInt("secondScore", secondScore);
        PlayerPrefs.SetInt("thirdScore", thirdScore);
        PlayerPrefs.SetInt("fourthScore", fourthScore);
        PlayerPrefs.SetInt("fifthScore", fifthScore);

        firstScore = PlayerPrefs.GetInt("firstScore");
        secondScore = PlayerPrefs.GetInt("secondScore");
        thirdScore = PlayerPrefs.GetInt("thirdScore");
        fourthScore = PlayerPrefs.GetInt("fourthScore");
        fifthScore = PlayerPrefs.GetInt("fifthScore");

    }

    public void IsHardLevel()
    {
        isHardLevel = true;
    }

    public void IsNotHardLevel()
    {
        isHardLevel = false;
    }

}
