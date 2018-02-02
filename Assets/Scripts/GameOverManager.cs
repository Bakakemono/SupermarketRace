using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    private float filledPercents = 0.0f;
    [SerializeField]
    private Image curtain;

	// Use this for initialization
	void Start () {
        StartCoroutine(Fill());
	}

    private IEnumerator Fill()
    {
        while (true)
        {
            filledPercents += 0.01f;
            curtain.fillAmount = filledPercents;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
