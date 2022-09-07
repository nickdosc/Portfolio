using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Coin : MonoBehaviour
{

    // A script to increase the player's currency every time the player touches a coin.


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerCharacter>().currency++;
            Destroy(gameObject);
            
        }
            

    }
}
