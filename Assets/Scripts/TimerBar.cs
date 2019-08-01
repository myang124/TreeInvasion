using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour {

    Image timerBar;
    public float maxTime = 60f; //60 secs can change
    float timeRemaining;


	// Use this for initialization
	void Start ()
    {
        timerBar = GetComponent<Image>();
        timeRemaining = maxTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(timeRemaining > 0)
        {
            timeRemaining = timeRemaining - Time.deltaTime;
            timerBar.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            Time.timeScale = 0;
        }
	}
}
