using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float score;
    public static float highscore;
    public static bool isPaused;
    public static int attempts;
    private float startTime;

    // Start is called before the first frame update
    void Awake()
    {
        isPaused = true;
        PlayerPrefs.GetInt("Attempts", 0);
        PlayerPrefs.GetFloat("HighScore", highscore);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Play()
    {
        startTime = Time.time;

        isPaused = false;
        Time.timeScale = 1;
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        score = Time.time - startTime;

        attempts += 1;
        if (score > highscore)
            highscore = score;

        PlayerPrefs.SetInt("Attempts", attempts);
        PlayerPrefs.SetFloat("HighScore", highscore);
    }
}
