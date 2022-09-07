using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _1_FirstDialogue : MonoBehaviour
{
    bool complete = false; // is the dialogue complete
    public Dialogue[] diag; // The dialgoue array

    public bool[] booldiag; // bool diag for each dialogue

    public GameObject LocationUI; // Location UI on screen
    public GameObject MerrinImage; // The image of Merin in game
    public GameObject ElsImage; // The image of Els in game.

    public GameObject Quicktip; // Tip display.

    public GameObject Els; // Els gameobject (Els is an ingame character.)
    public Text ObjectiveText; // The objective text viewed when TAB is pressed.
    
    // Start is called before the first frame update
    void Start()
    {

        //Change location UI and set the values for the dialogue that is about to commence.
        LocationUI.GetComponent<Text>().text = "~ Ront Woods ~";
        LocationUI.GetComponent<Animator>().SetBool("IsOpen",true);
        booldiag = new bool[4];
        GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
        StartCoroutine(WelcomeToVengeance());
    }

    // Update is called once per frame
    void Update()
    {
        //Start dialgue and swap images accordingly to who is speaking.
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
            MerrinImage.SetActive(true);
            PlayDialogue(diag[3]);
            booldiag[2] = false;       
            ObjectiveText.text = "Head to Ront Village!";
            complete = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && complete){
           // GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
            Quicktip.GetComponent<Animator>().SetBool("IsOpen", true);
            Els.GetComponent<_ElsStartMovement>().begins = true;
            ElsImage.SetActive(false);
            MerrinImage.SetActive(false);
            Destroy(gameObject);
        }
        
        
    }
    public void PlayDialogue(Dialogue Diag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Diag);
    }

    //A pause for the player to be displayed with a tip on how to move, before being free to explore
    IEnumerator WelcomeToVengeance(){

        yield return new WaitForSeconds(4f);
            booldiag[0] = true;
            ElsImage.SetActive(true);
            LocationUI.GetComponent<Animator>().SetBool("IsOpen",false);
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
            
    }
}
