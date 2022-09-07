using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Container : MonoBehaviour
{
    //Script of the NPC range container to check if player is inside.
    public GameObject npc;
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = true;
            npc.GetComponent<NPC_Behaviour>().isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = false;
            npc.GetComponent<NPC_Behaviour>().isInside = false;
        }   
    }
}
