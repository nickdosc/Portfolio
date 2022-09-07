using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satchel_Script : MonoBehaviour
{

    public Dialogue diag;
    public GameObject dungeoncontroller;
    private bool complete = false;
    private bool once = false;
    private bool inside = false;
    private bool chestClaimed = false;

    

    int currencyContained;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (FindObjectOfType<DialogueManager>().isDone && complete)
        {

            StartCoroutine(ExecuteAfterTime(0.5f));

        }
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && !once && inside && !chestClaimed)
        {
            //Type how much Currency the chest contained in the Dialogue for the player to know.
            // Along with any other loot contained.
            diag.name = "";
            diag.sentences = new string[] { "You collected a Satchel" };
            dungeoncontroller.GetComponent<Dungeon_01_Controller>().satchels++;




            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            FindObjectOfType<PlayerCharacter>().enabled = false;
            complete = true;
            once = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inside = false;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inside = true;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = true;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        FindObjectOfType<PlayerCharacter>().enabled = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
        chestClaimed = true;
        Destroy(gameObject);

    }

  
}
