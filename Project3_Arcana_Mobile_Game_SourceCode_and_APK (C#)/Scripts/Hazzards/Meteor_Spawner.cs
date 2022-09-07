using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Spawner : MonoBehaviour
{
    public GameObject meteor;
    public float spawnCooldown = 5;
    private float timeUntilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilSpawn = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            // Do your enemy spawns here
            Instantiate(meteor);
            // Reset for next spawn
            timeUntilSpawn = spawnCooldown;
        }

    }
}

