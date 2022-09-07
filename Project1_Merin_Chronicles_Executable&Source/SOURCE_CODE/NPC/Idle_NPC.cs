using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_NPC : MonoBehaviour
{
    public Dialogue diag; // Dialogue that the NPC will display when interacted with.
    public bool isInside; // If the player is inside.
    bool talking; // if the player is currently interacting with the npc.

    public BoxCollider2D trigger;

    void Update()
    {
        //Freeze player movement if a dialogue is initiated and display a dialogue.
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && isInside){
            talking = true;
            trigger.enabled = false;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
        }
        //If dialogue is done unolck the player movememt.
        if (FindObjectOfType<DialogueManager>().isDone && talking){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
            trigger.enabled = true;
            talking = false;  
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = true;
            isInside = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = false;
            isInside = false;
        }   
    }
}
