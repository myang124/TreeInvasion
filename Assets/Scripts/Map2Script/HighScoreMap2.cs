﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMap2 : MonoBehaviour
{

    public Text highscore;
    public Text score;

    // Use this for initialization
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore2").ToString();
        score.text = PlayerPrefs.GetInt("Score2").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
