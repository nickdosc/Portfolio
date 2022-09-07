using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad_Progress_Vekithos : MonoBehaviour
{
    public Dialogue diag;
    public GameObject Amantha;
    
    private bool done = false;
    private bool once = false;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone && done)
        {
           if (once)
            {
                return;
            } else
            {
                once = true;
                StartCoroutine(ExecuteAfterTime(0.5f));
            }
           
        }
        if (Amantha.GetComponent<AmanthaScript>().megacomplete)
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !Amantha.GetComponent<AmanthaScript>().megacomplete && !done)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;;
            done = true;
        }

       
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;

    }
}
