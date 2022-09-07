using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2_Bridge_Stop : MonoBehaviour
{

    /*
    Similarly to the first dialogue scipt, this script controls a dialogue as well as spawns a gameobject used as a
    prop for the story and trasnporting the player to a new place.
    */

    bool spawn = false;
    bool complete = false;
    public Dialogue[] diag;

    public bool[] booldiag;
    public GameObject Fadeout;
    public GameObject MerrinImage;
    public GameObject ElsImage;

    public Transform TeleportTransform;
    public GameObject ShadowMerin;
    
    // Start is called before the first frame update
    void Start()
    {
        booldiag = new bool[6];
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dialogues
         if (FindObjectOfType<DialogueManager>().isDone && booldiag[0]){
            ElsImage.SetActive(false);
            MerrinImage.SetActive(true);
            PlayDialogue(diag[1]);
            booldiag[0] = false;
            booldiag[1] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[1])
        {
            ElsImage.SetActive(true);
            MerrinImage.SetActive(false);
            PlayDialogue(diag[2]);
            booldiag[1] = false;
            booldiag[2] = true;
        }
           if (FindObjectOfType<DialogueManager>().isDone && booldiag[2])
        {
            ElsImage.SetActive(false);
            MerrinImage.SetActive(false);
            PlayDialogue(diag[3]);
            booldiag[2] = false;
            booldiag[3] = true;
         
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[3])
        {
            ElsImage.SetActive(false);
            MerrinImage.SetActive(true);
            PlayDialogue(diag[4]);
            booldiag[3] = false;
            booldiag[4] = true;
            //complete = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[4])
        {
            ElsImage.SetActive(true);
            MerrinImage.SetActive(false);
            PlayDialogue(diag[5]);
            booldiag[4] = false;
            booldiag[5] = true;
            complete = true;
        }

        //Spawn Merin Shadow, And start Enum to fade screen
        if (FindObjectOfType<DialogueManager>().isDone && complete){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
            if (!spawn) {
            Instantiate(ShadowMerin, GameObject.Find("Player").transform.position + new Vector3(3f,0f), Quaternion.identity);
            spawn = true;
            }
            StartCoroutine(ShadowOblitaration());
            //Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            StartCoroutine(StartTheBridge());
        }
    }
    public void PlayDialogue(Dialogue Diag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Diag);
    }
    IEnumerator StartTheBridge(){

        yield return new WaitForSeconds(1f);
        booldiag[0] = true;
        ElsImage.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
    }

    IEnumerator ShadowOblitaration(){

        yield return new WaitForSeconds(2f);
        Fadeout.GetComponent<Animator>().SetBool("Fade", true);
        MerrinImage.SetActive(false);
        ElsImage.SetActive(false);
        yield return new WaitForSeconds(1f);
        GameObject.Find("Player").GetComponent<Transform>().position = TeleportTransform.position;
        Destroy(gameObject);
    
    }
}
