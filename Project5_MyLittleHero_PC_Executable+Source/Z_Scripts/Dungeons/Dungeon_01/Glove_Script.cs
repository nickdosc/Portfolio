using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove_Script : MonoBehaviour
{

    public Dialogue diag;
    public GameObject dungeoncontroller;
    public GameObject satchel;

    private bool complete = false;
    private bool once = false;
    private bool inside = false;
    private bool done = false;
   

    public bool hassatchel = false;
    

    int currencyContained;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dungeoncontroller.GetComponent<Dungeon_01_Controller>().satchels > 0)
        {
            hassatchel = true;
        }
        else
        {
            hassatchel = false;
        }
       
        if (FindObjectOfType<DialogueManager>().isDone && complete)
        {

            StartCoroutine(ExecuteAfterTime(0.5f));
          
           

        }
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && !once && inside)
        {
            //Type how much Currency the chest contained in the Dialogue for the player to know.
            // Along with any other loot contained.
            if (!done)
            {
                diag.name = "";
                diag.sentences = new string[] { "Find something to place on the glove" };
            }
            

            if (hassatchel)
            {
                satchel.SetActive(true);
                done = true;
                dungeoncontroller.GetComponent<Dungeon_01_Controller>().counter++;
                diag.name = "";
                diag.sentences = new string[] { "The Glove is Activated" };
                dungeoncontroller.GetComponent<Dungeon_01_Controller>().satchels = dungeoncontroller.GetComponent<Dungeon_01_Controller>().satchels - 1;
            }


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

        FindObjectOfType<PlayerCharacter>().enabled = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
   

    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        complete = false;
        once = false;
       // Destroy(gameObject);
    }
}
