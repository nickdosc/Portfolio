using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class _3_Mirror_Talk : MonoBehaviour
{
    public Dialogue[] diag; 
    public bool[] booldiag; 
    bool complete = false;
    bool here = false;

    public Animator notification;
    public Text notification_text;

    public GameObject Merin_Image;
    public GameObject Merin_PowerUp;
    public GameObject After_Mirror;
    public Transform TeleportTransform;



    public Light2D playerlight;


    // Start is called before the first frame update
    void Start()
    {
        booldiag = new bool[6];
    }

    // Update is called once per frame
    void Update()
    {
        //Dialogues
         if (FindObjectOfType<DialogueManager>().isDone && booldiag[0] && here){
            Merin_Image.SetActive(false);
            PlayDialogue(diag[1]);
            booldiag[0] = false;
            booldiag[1] = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && booldiag[1] && here)
        {
            Merin_Image.SetActive(true);
            PlayDialogue(diag[2]);
            booldiag[1] = false;
            booldiag[2] = true;
        }
           if (FindObjectOfType<DialogueManager>().isDone && booldiag[2] && here)
        {
            Merin_PowerUp.SetActive(true);
            Merin_Image.SetActive(false);
            PlayDialogue(diag[3]);
            booldiag[2] = false;
            booldiag[3] = true;
         
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[3] && here)
        {
            Merin_Image.SetActive(true);
            PlayDialogue(diag[4]);
            booldiag[3] = false;
            booldiag[4] = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[4] && here)
        {
            Merin_Image.SetActive(false);
            PlayDialogue(diag[5]);
            booldiag[4] = false;
            booldiag[5] = true;
            complete = true;
        }


        //On dialogue finish activate the first Skill of the player as well
        //as diplay a notification tip to the player that explains how the skill is used.
         if (FindObjectOfType<DialogueManager>().isDone && complete &&  here){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().Mirror_Projectile = true;
            Merin_Image.SetActive(false);
            Merin_PowerUp.SetActive(false);
            notification_text.text = "New Skill! ~Mirro-Force~ Press Z to Use.";
            notification.SetBool("IsOpen", true);
            playerlight.pointLightOuterRadius = 8;
            GameObject.Find("Player").GetComponent<Transform>().position = TeleportTransform.position;
            After_Mirror.SetActive(true);
            StartCoroutine(KillAfterTime(5f));
        }

    }

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

      public void PlayDialogue(Dialogue Diag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Diag);
    }

    IEnumerator KillAfterTime(float time) {
        yield return new WaitForSeconds(time);
        notification.SetBool("IsOpen", false);
        Destroy(gameObject);
    }
}
