using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFigure : MonoBehaviour
{
    public Dialogue diag;

    public GameObject skull;
    public GameObject Portal;


    private bool once = false;
    private bool done = false;
    private bool inside = false;


    
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone && done)
        {

            StartCoroutine(ExecuteAfterTime(0.5f));

        }
        if (!once && inside)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            done = true;
            once = true;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inside = false;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().interaction = false;
            StartCoroutine(ExecuteAfterTime2(1));
        }

    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
        Portal.SetActive(true);
        Destroy(skull);
        Destroy(gameObject);


    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        done = false;
        once = false;

    }
}
