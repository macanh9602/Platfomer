using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    public TMP_Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        HighScoreText.text = "High Score : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
