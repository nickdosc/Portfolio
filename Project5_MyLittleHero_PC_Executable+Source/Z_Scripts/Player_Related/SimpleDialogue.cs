using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogue : MonoBehaviour
{
    public Dialogue diag;
    private bool complete = false;
    private bool once = false;
    private bool inside = false;
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
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && !once && inside)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
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
            StartCoroutine(ExecuteAfterTime2(1));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inside = true;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = true;
        }     
    }
 
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

       GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;

    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        complete = false;
        once = false;
    }
}
