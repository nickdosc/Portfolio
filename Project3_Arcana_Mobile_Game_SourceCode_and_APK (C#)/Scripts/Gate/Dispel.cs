using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dispell_UI;
    bool isInside;
    public bool dispelled;
    bool done;
    Color dispeller;

    
    void Start()
    {
        dispeller = new Color(0.7098f,0.1372f,0.2392f,1f);
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(dispelled){
            isInside = false;
            GameObject.Find("Player").GetComponent<Player_Script>().Glowup(Color.white);
        }
        if(isInside){
            GameObject.Find("Player").GetComponent<Player_Script>().Glowup(dispeller);
            done = false;
        }
        else{
            if(!done){
                GameObject.Find("Player").GetComponent<Player_Script>().Glowup(Color.white);
                StartCoroutine(changeColorToDefault());
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            if(GameObject.Find("Gate").GetComponent<Gate_Script>().red == GameObject.Find("Player").GetComponent<Player_Script>().red_gems){
                dispell_UI.SetActive(true);
                isInside = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            isInside = false;
            dispell_UI.SetActive(false);
            
        }
    }

    IEnumerator changeColorToDefault(){
        yield return new WaitForSeconds(2f);
        done = true;
    }
}
