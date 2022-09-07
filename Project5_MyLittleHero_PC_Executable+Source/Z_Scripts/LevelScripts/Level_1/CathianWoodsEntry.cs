using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CathianWoodsEntry : MonoBehaviour
{
    public Dialogue diag;
    public SpriteRenderer sprite;
    public BoxCollider2D block;
    public BoxCollider2D diagtrigger;

    public Text Tiptext;
    public Animator Tipanim;



    bool cathian = false;
    bool done = false;
    bool trigger = false;
    void Update()
    {
        if (FindObjectOfType<GuardScript>().cathianwoodsActive)
        {
            sprite.enabled = false;
            block.enabled = false;
            cathian = true;
            done = true;
            trigger = true;
            diagtrigger.enabled = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && done &&!trigger)
        {
            diagtrigger.enabled = false;
            StartCoroutine(ExecuteAfterTime(0.5f));
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !cathian)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            done = true;
        }

        if (collision.tag == "Player" && cathian) 
        {
           
            Tipanim.SetBool("IsOpen", true);
            Tiptext.text = "You're starting your first Adventure! Look for Hearts to restore health!";
            Destroy(gameObject);
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;

    }
}
