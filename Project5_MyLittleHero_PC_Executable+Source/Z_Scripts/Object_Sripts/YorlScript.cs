﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YorlScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerCharacter>().currency++;
            Destroy(gameObject);
        }
    }
}