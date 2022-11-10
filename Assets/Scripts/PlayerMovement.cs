using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public UIScript script;

    enum Difficulty { Easy = 0, Medium = 1, Hard = 2 };
    [SerializeField]
    private Difficulty difficulty;

    public int speedForward;
    public float speedVertical;
    private Rigidbody rb;

    private float lastTimeSpeedUp;
    private int interval;
    private float speedIncrease;

    void Start()
    {
        
        //initialization 
        rb = transform.GetComponent<Rigidbody>();
        difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", 1);

        if (difficulty == Difficulty.Medium)
            InitializeMedium();
        else if (difficulty == Difficulty.Hard)
            InitializeHard();
        else
            InitializeEasy();
    }

    void Update()
    {
        // jump
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.up * speedVertical / 4, ForceMode.Impulse);

        // speed increase
        if (Time.time > lastTimeSpeedUp + interval )
        {
            speedVertical += speedIncrease;
            lastTimeSpeedUp = Time.time;
        }
    }

    // physics
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speedForward);
        rb.AddForce(Vector3.down * speedVertical);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
            GameOver();
    }

    void InitializeEasy()
    {
        speedForward = 10;
        speedVertical = 4;

        // hardcoded 15 seconds for speed increase
        interval = 15;
        speedIncrease = 0.5f;
        lastTimeSpeedUp = 0;
    }

    void InitializeMedium()
    {
        speedForward = 12;
        speedVertical = 4;

        // hardcoded 15 seconds for speed increase
        interval = 12;
        speedIncrease = 0.5f;
        lastTimeSpeedUp = 0;
    }

    void InitializeHard()
    {
        speedForward = 15;
        speedVertical = 4;

        // hardcoded 15 seconds for speed increase
        interval = 15;
        speedIncrease = 0.5f;
        lastTimeSpeedUp = 0;
    }

    private void GameOver()
    {

        Debug.Log("Game Over");
    }
}
