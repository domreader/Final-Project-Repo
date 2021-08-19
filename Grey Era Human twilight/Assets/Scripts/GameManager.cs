using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public void restartGame()
    {
        SceneManager.LoadScene("2");

        Time.timeScale = 1f;

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("StartUI");
    }
    public void startGame()
    {

        SceneManager.LoadScene("2");

    }

    public void settingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public Button settingsButton;
    public Button applyButton;
    public Button resetButton;
    public Button cancelButton;
    public Button resumeGameButton;

    public Canvas settingsCanvas;
    public Canvas menuCanvas;
    void Start()
    {

        settingsButton.onClick.AddListener(openSettings);
        applyButton.onClick.AddListener(applyGraphics);
        resetButton.onClick.AddListener(resetGraphics);
        cancelButton.onClick.AddListener(closeSettings);
        resumeGameButton.onClick.AddListener(resumeButton);
    }

    public void openSettings()
    {

        settingsCanvas.enabled = true;
        Debug.Log("Button Clicked");

    }

    public void applyGraphics()
    {
        Debug.Log("Applied");
    }

    public void resetGraphics()
    {
        Debug.Log("Reset Graphics");
    }

    public void closeSettings()
    {
        settingsCanvas.enabled = false;
    }


    public void resumeButton()
    {
        menuCanvas.enabled = false;
    }
}
