using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int scoreValue; // スコアの変数

    private Text scoreText; // スコアを表示するテキスト
    
    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreValue = 0; // 初期スコアを設定する
        PlayerPrefs.SetInt("Score", scoreValue);
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreValue.ToString(); // スコアの値をテキストに反映する
        PlayerPrefs.SetInt("Score", scoreValue);
    }
}