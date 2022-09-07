using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTheSword : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Portal;

    public Dialogue diag;
    

    public Animator TipAnim;
    public Text TipText;

    bool getSword = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone && (getSword))
        {


            StartCoroutine(ExecuteAfterTime(0.5f));

        }
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            FindObjectOfType<PlayerCharacter>().enabled = false;
            getSword = true;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        FindObjectOfType<PlayerCharacter>().enabled = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
        Sword.SetActive(true);
        TipAnim.SetBool("IsOpen", true);
        TipText.text = "Well Done! You have your sword. Use Z to arm yourself and LMB To attack. Good Luck!";
        Portal.SetActive(true);
        Destroy(gameObject);
        
    }

}
