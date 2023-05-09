using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;
    public static int score;
    public static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = 0;
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + score;
        if (score > highScore)
        {
            // Nếu điểm số mới cao hơn điểm số cao nhất, cập nhật lại điểm số cao nhất và lưu vào bộ nhớ
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);

        }


    }
    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("highScore", highScore);
    }
}

