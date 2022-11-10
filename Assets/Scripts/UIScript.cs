using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI inGameInfo;
    public TextMeshProUGUI inGameDifficulty;
    public GameObject mainMenu;
    public GameObject gameoverMenu;

    public TextMeshProUGUI gameoverInfo; // score + \n + highscore + \n + attempts

    public GameManager gmScript;

    void Start()
    {
        gmScript = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    void Update()
    {
        if (!GameManager.isPaused)
        {
            inGameInfo.text = "score: " + GameManager.score;
            inGameDifficulty.text = GameManager.difficulty.ToString();
        }
    }

    // for Difficulty buttons
    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
        gmScript.SetDifficulty(difficulty);
    }

    // Start and PlayAgain buttons
    public void StartGame()
    {
        gmScript.Play();
    }

    public void WhilePlayInfo()
    {
        mainMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        inGameInfo.enabled = true;
        inGameDifficulty.enabled = true;
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        inGameInfo.enabled = false;
        inGameDifficulty.enabled = false;
    }

    public void GameOver()
    {
        mainMenu.SetActive(false);
        gameoverMenu.SetActive(true);
        inGameInfo.enabled = false;
        inGameDifficulty.enabled = false;

        gameoverInfo.text = GameManager.score + "\n" + GameManager.highscore + "\n" + GameManager.attempts;
    }
}
