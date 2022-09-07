using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Trigger : MonoBehaviour
{

    //Display the Chapter one graphics when the player enters the Area that begins the specified chapter.
    public GameObject chapter;
    public Animator chapterAnim;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            chapter.SetActive(true);
            chapterAnim.SetBool("IsOpen", true);
            StartCoroutine(StartDelay());
        }
    }

    IEnumerator StartDelay(){
        yield return new WaitForSeconds(5f);
        chapterAnim.SetBool("IsOpen", false);
       // chapter.SetActive(false);
        Destroy(gameObject);
    }
}
