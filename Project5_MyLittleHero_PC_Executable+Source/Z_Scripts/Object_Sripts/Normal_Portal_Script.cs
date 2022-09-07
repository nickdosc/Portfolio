using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Portal_Script : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform TeleportTransform;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            PlayerTransform.position = TeleportTransform.position;
        }


    }
}
