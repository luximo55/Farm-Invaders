using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GameStartPanel;
    public GameObject BackgrondPanel;
    public GameObject ControlsPanel;
    public GameObject DifficultyPanel;
    public GameObject StartMenuPanel;

    public void Start()
    {
        StartMenuPanel.SetActive(false);
        Time.timeScale = 1;
        BackgrondPanel.SetActive(true);
    }

    public void Back()
    {
        ControlsPanel.SetActive(false);
        DifficultyPanel.SetActive(false);
    }

    public void Controls()
    {
        ControlsPanel.SetActive(true);
    }
    
    public void Play()
    {
        DifficultyPanel.SetActive(true);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
