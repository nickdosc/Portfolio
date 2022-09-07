using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    bool activated;
    private bool removePowers;
    public Transform PlayerTransform;
    public Transform TeleportTransform;
    public Animator anim;
    bool triggeredplayer;
    bool playersIn;
    //bool triggeredGem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(removePowers){
            GameObject.Find("Player").GetComponent<Player_Script>().Glowup(Color.white);
        }
        if(triggeredplayer){
            PlayerTransform.position = TeleportTransform.position;
            triggeredplayer = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BlueGem" && !activated){
            activated = true;
            anim.SetBool("IsActivated", true);
            Destroy(other.transform.parent.gameObject);
            OnActation();
            if (playersIn){
            PlayerTransform.position = TeleportTransform.position;
            triggeredplayer = false;
            }
        }
              
        if (other.tag == "Player")
        playersIn = true;

        if ((other.tag == "Player" || other.tag == "GreenGem") && activated)
        {
            if(other.tag == "Player")
            triggeredplayer = true;
            if(other.tag == "GreenGem"){
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            //other.GetComponentInParent<Transform>().position = TeleportTransform.position;
            //other.GetComponent<Transform>().position = TeleportTransform.position;
            other.transform.parent.Translate(TeleportTransform.localPosition);
            StartCoroutine(resetcollider(other));
            //other.transform.parent.GetComponent<Transform>().position = TeleportTransform.position;
            }
        }
            

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        playersIn = false;
        
    }

    public void OnActation(){
        removePowers = true;
        StartCoroutine(changeColorToDefault());
    }

    IEnumerator changeColorToDefault(){
        yield return new WaitForSeconds(2f);
        removePowers = false;
    }

     IEnumerator resetcollider(Collider2D other){
        yield return new WaitForSeconds(0.5f);
        other.GetComponent<BoxCollider2D>().enabled = true;
        other.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
    }
}
