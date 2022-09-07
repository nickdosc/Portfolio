using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public Animator Tipanim;
    public Text TipText;
    public Text ObjectiveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ObjectiveText.text = "Speak with Cathian Villagers.";
            TipText.text = "You're about to Enter your first Town, to speak with People use V";
            Tipanim.SetBool("IsOpen", true);
        }
      
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        Destroy(gameObject);
    }
}
