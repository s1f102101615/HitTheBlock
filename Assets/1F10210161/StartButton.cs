using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton; // スタートボタンの参照

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // ゲームの開始処理を行う

        // スタートボタンを非表示にする
        startButton.gameObject.SetActive(false);
    }
}
