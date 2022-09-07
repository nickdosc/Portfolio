using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class _3_After_Bridge : MonoBehaviour
{

    /*
    This script controls a dialogue as well as change the values of the lighting used in the game
    for story related reasons.

    Also fade serves as a screen fade used in order to hide the screen from the player while changing these values.
    */
    public Dialogue diag;

    bool here = false;
    public GameObject Els_Attack;
    public GameObject Shadow_Els;

    public Light2D Global_Light;
    public float light_intensity;
    public GameObject player_light;
    public GameObject Merin_Image;

    public Animator fade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isDone && here){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
            Merin_Image.SetActive(false);
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            StartCoroutine(Arrival());
        }
    }
    IEnumerator Arrival(){


        yield return new WaitForSeconds(2f);
        Destroy(Els_Attack);
        Destroy(Shadow_Els);
        Global_Light.intensity = light_intensity;
        player_light.SetActive(true);
        fade.SetBool("Fade", false);
        yield return new WaitForSeconds(1.5f);
        here = true;
        Merin_Image.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(diag);



    }

    
}
