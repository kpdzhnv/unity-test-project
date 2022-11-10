using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI inGameInfo;
    public GameObject mainMenu;
    public GameObject gameoverMenu;

    public TextMeshProUGUI gameoverInfo; // score + highscore + attempts

    private void Awake()
    {
        MainMenu();
    }

    // for Difficulty buttons
    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    // Start and PlayAgain buttons
    public void StartGame()
    {

        mainMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        inGameInfo.enabled = true;
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        inGameInfo.enabled = false;
    }

    public void GameOver()
    {
        mainMenu.SetActive(false);
        gameoverMenu.SetActive(true);
        inGameInfo.enabled = false;

        gameoverInfo.text = GameManager.score + "\n" + GameManager.highscore + "\n" + GameManager.attempts;
        // pause
    }



    void Update()
    {
        if (!GameManager.isPaused)
        {
            inGameInfo.text = "score: " + GameManager.score.ToString("F2");
        }
    }
}
