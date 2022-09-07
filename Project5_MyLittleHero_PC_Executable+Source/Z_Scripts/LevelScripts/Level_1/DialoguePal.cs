using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePal : MonoBehaviour
{
    public Dialogue[] diag;
    public BoxCollider2D diagtrigger;
    public BoxCollider2D goThrough;

    public Text ObjectiveText;

    public bool[] booldiag;
    bool complete = false;
   
 
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
            goThrough.enabled = false;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;

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
            ObjectiveText.text = "Visit Cathia!";
        }
    
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other);
        if (other.tag == "Player")
        {
            
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            booldiag[0] = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);

        }

    }


    public void PlayDialogue(Dialogue Diag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Diag);
    }
}
