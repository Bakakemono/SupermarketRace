using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    [Header("Tuto")]
    [SerializeField]
    private GameObject CanvasTutoRoll;
    [SerializeField]
    private GameObject CanvasTutoTurn;
    [SerializeField]
    private GameObject CanvasTutoEnemies;
    [SerializeField]
    private GameObject CanvasEndTuto;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PanelTuto1()
    {
        Destroy(CanvasTutoRoll);
    }

    public void PanelTuto2On()
    {
        CanvasTutoTurn.SetActive(true);  
    }

    public void PanelTuto2Off()
    {
        Destroy(CanvasTutoTurn);
    }

    public void PanelTuto3On()
    {
        CanvasTutoEnemies.SetActive(true);
    }

    public void PanelTuto3Off()
    {
        Destroy(CanvasTutoEnemies);
    }

    public void PanelTutoEnd()
    {
        CanvasEndTuto.SetActive(true);
    }
}
