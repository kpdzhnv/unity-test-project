using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float distanceToPlayer;
    public Transform player;

    void Start()
    {
        distanceToPlayer = -7;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        //follow the player
        transform.position = new Vector3(0, 0, player.transform.position.z + distanceToPlayer);
    }
}
