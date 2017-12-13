using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Text speedText;

    private const string TEXT_SPEED = " km/h";
    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        speedText.text = Mathf.Round(playerController.speed*3.6f) + TEXT_SPEED;
	}
}
