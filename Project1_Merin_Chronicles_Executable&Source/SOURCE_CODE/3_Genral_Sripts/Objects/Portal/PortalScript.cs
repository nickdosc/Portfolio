using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    //A teleport script to move the player when touching a portal.

    public GameObject fade; // an object that fades the screen
    public Transform PlayerTransform;
    public Transform goTo;
    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
          StartCoroutine(StartTeleport());
        }
            

    }

    //Teleport player to the desired location
    IEnumerator StartTeleport(){  
        fade.GetComponent<Animator>().SetBool("Fade", true);
        yield return new WaitForSeconds(1.5f);
        PlayerTransform.position = goTo.position;
        yield return new WaitForSeconds(2f);
        fade.GetComponent<Animator>().SetBool("Fade", false);
        Destroy(gameObject);
        
    }
}
