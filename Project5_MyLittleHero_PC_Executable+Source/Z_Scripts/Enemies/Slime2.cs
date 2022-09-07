using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime2 : MonoBehaviour
{
    public float health;
    Color origionalColor;
    float force = 1;
    public GameObject enemy;
    public GameObject boom;
    public float flashTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        origionalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
          //Despawn Check
        if (health <= 0)
        {
            Instantiate(boom, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector2 direction = (transform.position + other.transform.position).normalized;

            GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth = GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth - 1;
            //print(GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth);

            other.GetComponent<Rigidbody2D>().AddForce(direction * force);

        }
        if (other.tag == "Weapon")
        {
            if (GameObject.Find("Player").GetComponent<PlayerCharacter>().armed){
                health--;
                FlashRed();
            }

        }
    }
    void FlashRed()
    {
     gameObject.GetComponent<SpriteRenderer>().color = Color.red;
     Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = origionalColor;
          
    }
}
