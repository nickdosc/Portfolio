using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Collision : MonoBehaviour
{
    float force = 3000f;
    public GameObject enemy;
    // Start is called before the first frame update
    private void Start()
    {

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
            if (GameObject.Find("Player").GetComponent<PlayerCharacter>().armed)
                enemy.GetComponent<Patrol_Enemy>().health--;

        }
    }
}
