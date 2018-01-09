﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Text speedText;
    private const string TEXT_SPEED = " km/h";

    [SerializeField]
    private  float timer;
    [SerializeField]
    private Text timerText;
    private const string TEXT_TIMER = " Seconds left";

    private PlayerControlerTest playerController;

	// Use this for initialization
	void Start () {
        playerController = FindObjectOfType<PlayerControlerTest>();
	}
	
	// Update is called once per frame
	void Update () {
        
        speedText.text = Mathf.Round(playerController.speed*3.6f) + TEXT_SPEED;
        timer -= Time.deltaTime;
        timerText.text = Mathf.Round(timer) + TEXT_TIMER;
	}
}
