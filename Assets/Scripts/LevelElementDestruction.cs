using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelElementDestruction : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // destroy when invisible for the player
        if (transform.position.z < player.position.z - 10)
            Destroy(this.gameObject);
    }
}
