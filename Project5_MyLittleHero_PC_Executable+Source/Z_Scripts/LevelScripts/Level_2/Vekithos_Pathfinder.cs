using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vekithos_Pathfinder : MonoBehaviour
{
    public Dialogue[] diag;
    public BoxCollider2D diagtrigger;

    public Text ObjectiveText;

    private bool complete = false;
    private bool once = false;
    public bool[] booldiag;
    private bool inside = false;
    public bool toTheWorldTree = false;


    // Start is called before the first frame update
    void Start()
    {
        booldiag = new bool[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone && complete)
        {
            Destroy(diagtrigger);
            StartCoroutine(ExecuteAfterTime(0.5f));

        }
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && !once && inside)
        {
            booldiag[0] = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            
            once = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[0])
        {
            PlayDialogue(diag[1]);
            booldiag[0] = false;
            booldiag[1] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[1])
        {
            PlayDialogue(diag[2]);
            booldiag[1] = false;
            booldiag[2] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[2])
        {
            PlayDialogue(diag[3]);
            booldiag[1] = false;
            booldiag[2] = false;
            complete = true;
            toTheWorldTree = true;
            ObjectiveText.text = "Head to the World Tree!";

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

        GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;

    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        complete = false;
        once = false;
    }

    public void PlayDialogue(Dialogue Diag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Diag);
    }
}
