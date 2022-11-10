using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    enum Difficulty { Easy = 0, Medium = 1, Hard = 2 };
    [SerializeField]
    private Difficulty difficulty;

    public GameObject bordersPrefab;
    public GameObject obstaclePrefab;
    private Vector3 lastBordersPosition;
    private Vector3 lastObstaclePosition;

    public GameObject playerPrefab;
    private GameObject player;

    public int N; // distance between obstacles

    // range for the obstacles to be spawned
    private float minHeight;
    private float maxHeight;

    private void Awake()
    {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", 1);
    }

    void Start()
    {
        lastBordersPosition = new Vector3(0, 0, 0);
        lastObstaclePosition = new Vector3(0, 0, 20);
        N = 15; 

        minHeight = -2.5f;
        maxHeight = 2.5f;
    }

    void Update()
    {
        if (!GameManager.isPaused)
        {
            // instantiate objects for the level
            if (Vector3.Distance(lastBordersPosition, player.transform.position) < 100)
            {
                Instantiate(bordersPrefab, lastBordersPosition, Quaternion.identity);
                lastBordersPosition = lastBordersPosition + Vector3.forward * 10;
                Instantiate(obstaclePrefab, lastObstaclePosition, Quaternion.identity);
                lastObstaclePosition.z += N;
                float pos = Random.Range(minHeight, maxHeight);
                lastObstaclePosition.y = pos;
            }
        }
    }
}
