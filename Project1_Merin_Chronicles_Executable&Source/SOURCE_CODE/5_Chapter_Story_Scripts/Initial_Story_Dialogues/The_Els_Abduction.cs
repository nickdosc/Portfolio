using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The_Els_Abduction : MonoBehaviour
{
    /*
    A Dialogue script that progresses the story as well as visually spawning and despawning
    gameobjects as props to aid in storytelling.
    */
    public Dialogue[] diag;
    public bool[] booldiag;   
    bool here = false;

    public Text objectiveText;
    public GameObject Merin_Image;
    public GameObject General_Image;
    public GameObject beam1;
    public GameObject beam2;
    public GameObject general;
    public GameObject els;
    // Start is called before the first frame update
    void Start()
    {
        booldiag = new bool[9];
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[0] && here){
            Merin_Image.SetActive(false);
            General_Image.SetActive(true);
            PlayDialogue(diag[1]);
            booldiag[0] = false;
            booldiag[1] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[1] && here){
            Merin_Image.SetActive(true);
            General_Image.SetActive(false);
            PlayDialogue(diag[2]);
            booldiag[1] = false;
            booldiag[2] = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[2] && here){
            Merin_Image.SetActive(false);
            General_Image.SetActive(true);
            PlayDialogue(diag[3]);
            booldiag[2] = false;
            booldiag[3] = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[3] && here){
            Merin_Image.SetActive(true);
            General_Image.SetActive(false);
            PlayDialogue(diag[4]);
            booldiag[3] = false;
            booldiag[4] = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[4] && here){
            Merin_Image.SetActive(false);
            General_Image.SetActive(true);
            PlayDialogue(diag[5]);
            booldiag[4] = false;
            booldiag[5] = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[5] && here){
            Merin_Image.SetActive(true);
            General_Image.SetActive(false);
            PlayDialogue(diag[6]);
            booldiag[5] = false;
            booldiag[6] = true;
        }
  
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[6] && here){
            Merin_Image.SetActive(false);
            General_Image.SetActive(true);
            PlayDialogue(diag[7]);
            booldiag[6] = false;
            booldiag[7] = true;
            beam1.SetActive(true);
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[7] && here){
            Merin_Image.SetActive(true);
            General_Image.SetActive(false);
            PlayDialogue(diag[8]);
            booldiag[7] = false;
            booldiag[8] = true;
            beam2.SetActive(true);
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[8] && here){
            Merin_Image.SetActive(false);
            General_Image.SetActive(false);
            StartCoroutine(KillAfterTime(3f));    
        }


        
    }

    public void PlayDialogue(Dialogue Diag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Diag);
    }

    //Player enters the range of the event.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            here = true;
            Merin_Image.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
            booldiag[0] = true;
        }
    }

    //Prop kill time.
    IEnumerator KillAfterTime(float time) {
        yield return new WaitForSeconds(time);
        Merin_Image.SetActive(false);
        General_Image.SetActive(false);
        objectiveText.text = "Gather infromation about the General's hideout.";
        GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
        Destroy(els);
        Destroy(general);
        Destroy(gameObject);
    }
}
