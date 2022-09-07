using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Script : MonoBehaviour
{
    public Dialogue diag;

    private bool complete = false;
    private bool once = false;
    private bool inside = false;
    private bool chestClaimed = false;

    public GameObject chestOpenSprite;

    int currencyContained;

    /****************************
     * Loot Table To Be Defined *
    ****************************/

    void Start()
    {
        currencyContained = Random.Range(2, 5);
    }


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
            diag.sentences = new string[] {"The Chest Contained " + currencyContained + " Yorls!"};

            /****************************
             * Loot Table To Be Defined *
            ****************************/
            GameObject.Find("Player").GetComponent<PlayerCharacter>().currency = GameObject.Find("Player").GetComponent<PlayerCharacter>().currency + currencyContained;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            chestOpenSprite.SetActive(true);

            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            FindObjectOfType<PlayerCharacter>().enabled = false;
            complete = true;
            once = true;
        }
    }





    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        FindObjectOfType<PlayerCharacter>().enabled = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
        chestClaimed = true;

    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        complete = false;
        once = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inside = false;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = false;
            StartCoroutine(ExecuteAfterTime2(1));
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
}
