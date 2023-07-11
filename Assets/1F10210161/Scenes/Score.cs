using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue; // スコアの変数

    private Text scoreText; // スコアを表示するテキスト

    private void Start()
    {
        scoreText = GetComponent<Text>();
        int scoreNow = PlayerPrefs.GetInt("Score"); 
        scoreText.text = "Score: " + scoreNow.ToString(); // スコアの値をテキストに反映する
    }

    private void Update()
    {
        // スコアの値をテキストに反映する
        int scoreNow = PlayerPrefs.GetInt("Score"); 
        scoreText.text = "Score: " + scoreNow.ToString();
    }
}
