using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarManager : MonoBehaviour {

    private float currentPlayerHP;
    [SerializeField] private float maxPlayerHP;
    private float percentPlayerLife;
    [SerializeField] private Image lifePlayerBar;
    private PlayerControlerTest playerControler;
    [SerializeField]
    private Text livesText;

    // Use this for initialization
    void Start () {
        playerControler = FindObjectOfType<PlayerControlerTest>();
    }
	
	// Update is called once per frame
	void Update () {
        //Player
        currentPlayerHP = playerControler.playerLife;
        percentPlayerLife = currentPlayerHP / maxPlayerHP;
        lifePlayerBar.fillAmount = percentPlayerLife;
        lifePlayerBar.color = Color.Lerp(Color.red, Color.green, percentPlayerLife);
        livesText.text = currentPlayerHP + "/" + maxPlayerHP + " remaining articles";
    }
}
