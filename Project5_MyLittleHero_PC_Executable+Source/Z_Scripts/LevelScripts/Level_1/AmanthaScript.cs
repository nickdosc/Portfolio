using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmanthaScript : MonoBehaviour
{
    public Dialogue[] diag;
    public Dialogue[] diag2;
    public BoxCollider2D diagtrigger;


    public GameObject OrcTrigger;

    public Text ObjectiveText;

    bool complete = false;
    bool once = false;

    public bool megacomplete = false;

    bool once2 = false;
    
    public bool[] booldiag;
    public bool[] afterorc;
    public bool orcleader;

    private bool inside = false;

    // Start is called before the first frame update
    void Start()
    {
        booldiag = new bool[4];
        afterorc = new bool[5];
    }

    // Update is called once per frame
    void Update()
    {
        

        if (FindObjectOfType<DialogueManager>().isDone && complete)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(diagtrigger);
            StartCoroutine(ExecuteAfterTime(0.5f));
           

        }
        if (megacomplete)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(ExecuteAfterTime(0.5f));
            //Destroy(diagtrigger2);
        }
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && !once && inside &&!orcleader)
        {
            booldiag[0] = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
            GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            FindObjectOfType<PlayerCharacter>().enabled = false;
            //complete = true;
            once = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[0] && !orcleader)
        {
            PlayDialogue(diag[1]);
            booldiag[0] = false;
            booldiag[1] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[1] && !orcleader)
        {
            PlayDialogue(diag[2]);
            booldiag[1] = false;
            booldiag[2] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[2] && !orcleader)
        {
            PlayDialogue(diag[3]);
            booldiag[1] = false;
            booldiag[2] = false;
            complete = true;

            ObjectiveText.text = "Slay the Orc Leader!";

        }

        //After Killing the Orc Leader
        
        if (orcleader)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            //OrcTrigger.GetComponent<BoxCollider2D>().enabled = true;
        }



        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && !once2 && inside && orcleader)
        {
            afterorc[0] = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag2[0]);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            
            once2 = true;
            

        }


        if (FindObjectOfType<DialogueManager>().isDone && afterorc[0])
        {
            PlayDialogue(diag2[1]);
            afterorc[0] = false;
            afterorc[1] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && afterorc[1])
        {
            PlayDialogue(diag2[2]);
            afterorc[1] = false;
            afterorc[2] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && afterorc[2])
        {
            PlayDialogue(diag2[3]);
            afterorc[2] = false;
            afterorc[3] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && afterorc[3])
        {
            PlayDialogue(diag2[4]);
            afterorc[3] = false;
            afterorc[4] = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && afterorc[4])
        {
            PlayDialogue(diag2[5]);
            afterorc[4] = false;
            megacomplete = true;

            ObjectiveText.text = "Head to Vekithos!";
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
