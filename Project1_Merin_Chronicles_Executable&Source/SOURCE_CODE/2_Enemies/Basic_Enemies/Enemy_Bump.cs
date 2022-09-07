using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bump : MonoBehaviour
{
    // Start is called before the first frame update
    float force = 1f; // The force that the enemy will apply to the player if it hit is registered.
    public float flashTime; // Flash time is for graphical color change.

    Color origionalColor; // The original sprite color
    public GameObject enemy; // The enemy game object.
    public GameObject mainbody; // The main body of the enemy.

    // Start is called before the first frame update
    private void Start()
    {
        //Get the original color of the enemy
       origionalColor = enemy.GetComponent<SpriteRenderer>().color;
    }

    //Flash red on the enemy sprite.
    void FlashRed()
    {
     enemy.GetComponent<SpriteRenderer>().color = Color.red;
     Invoke("ResetColor", flashTime);
    }

    //Reset color to the orginal one for the enemy.
    void ResetColor()
    {
        enemy.GetComponent<SpriteRenderer>().color = origionalColor;
        
        
        
    }
    //If enemy hits player, apply force and substract life from the current life points of the Player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector2 direction = (transform.position + other.transform.position).normalized;

            GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth = GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth - 1;
            //print(GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth);

            other.GetComponent<Rigidbody2D>().AddForce(direction * force);

        }
        // If a projectile hits the enemy, then flash red and reduce its life.
        if (other.tag == "Projectile")
        {
            FlashRed();
            Vector2 direction = (transform.position + other.transform.position).normalized;
            mainbody.GetComponent<Rigidbody2D>().AddForce(direction * force);
            mainbody.GetComponent<Basic_Enemy>().health--;
         
        }
    }

    
}
