using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int min;
    public int sec;
    public Text timer;
    public bool gameIsOver = false;

	// Use this for initialization
	void Start () {
        StartCoroutine("MinLost");
        StartCoroutine("SecLost");
	}
	
	// Update is called once per frame
	void Update () {
        //lets player see amount of time left
        timer.text = min + ":" + sec;
        //ends game when timer hits 0
        if(min == 0 && sec == 0)
        {
            StopCoroutine("MinLost");
            StopCoroutine("SecLost");
            gameIsOver = true;
        }
	}
    // subracts one from the minuite once second reaches 0;
    IEnumerator MinLost()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(sec == 0)
            {
                min--;
                sec = 60;
            }
        }
    }
    // counts down seconds 
    IEnumerator SecLost()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            sec--;
        }
    }
}
