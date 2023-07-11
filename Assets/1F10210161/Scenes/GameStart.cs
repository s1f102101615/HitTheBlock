using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button startButton;

    void Start()
{
    startButton.onClick.AddListener(TaskOnClick);
}


    private void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
