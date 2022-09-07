using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Diag : MonoBehaviour
{
    public Dialogue diag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone){
            GameObject.Find("Player").GetComponent<Player_Script>().locked = false;
            Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            GameObject.Find("Player").GetComponent<Player_Script>().locked = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
        }
    }
}
