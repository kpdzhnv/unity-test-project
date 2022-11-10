using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Difficulty { Easy = 0, Medium = 1, Hard = 2 };
    public static Difficulty difficulty;

    public static int score;
    public static float highscore;
    public static bool isPaused;
    public static int attempts;
    private float startTime;

    public UIScript uiScript;

    // Start is called before the first frame update
    void Awake()
    {
        isPaused = true;
        Time.timeScale = 0;
        attempts = PlayerPrefs.GetInt("Attempts", 0);
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", 0);
        score = 0;

        uiScript = GameObject.FindObjectOfType(typeof(UIScript)) as UIScript;
        uiScript.MainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
            score = (int)((Time.time - startTime) * 100);
    }

    public void SetDifficulty(int dif)
    {
        difficulty = (Difficulty)dif;
    }

    public void Play()
    {
        startTime = Time.time;

        isPaused = false;
        Time.timeScale = 1;
        uiScript.WhilePlayInfo();
    }

    // actually only called when the game is over
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;

        score = (int)((Time.time - startTime) * 100);

        attempts += 1;
        if (score > highscore)
            highscore = score;
        uiScript.GameOver();

        PlayerPrefs.SetInt("Attempts", attempts);
        PlayerPrefs.SetFloat("HighScore", highscore);
    }
}
