using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtons : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button loadButton;
    public Button exitButton;

    public void OnEnable()
    {
        optionsButton.onClick.AddListener(delegate { Options(); });
        exitButton.onClick.AddListener(delegate { Exit(); });
        startButton.onClick.AddListener(delegate { StartGame(); });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gra");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
