using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Enemy_Script : MonoBehaviour
{
    public GameObject baseEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            baseEnemy.GetComponent<Starter_Enemy>().StopAllCoroutines();
            baseEnemy.GetComponent<Starter_Enemy>().isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
           baseEnemy.GetComponent<Starter_Enemy>().isInside  = false;
           baseEnemy.GetComponent<Starter_Enemy>().PlayerIsOut();
        }
    }
}
