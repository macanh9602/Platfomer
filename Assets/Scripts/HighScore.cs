using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    public TMP_Text HighScoreText;
    public TMP_Text LastScoreText;  
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        int lastScore = PlayerPrefs.GetInt("lastScore");
        HighScoreText.text = "High Score : " + highScore;
        LastScoreText.text = "Last Score : " + lastScore;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ResetHighScore()
    {
        Score.highScore = 0;
        PlayerPrefs.SetInt("highScore", Score.highScore);
        SceneManager.LoadScene(0);
    }
}
