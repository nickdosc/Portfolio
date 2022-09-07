using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    //A script that handles the intro of the game in case there is no save file.

    
    public GameObject CrossFade;
    void Start()
    {
       if ( SceneManager.GetActiveScene().name == "Intro") {
           CrossFade.GetComponent<Animator>().Play("Transition_Open");
       }
       if ( SceneManager.GetActiveScene().name == "_Overworld") {
           CrossFade.GetComponent<Animator>().Play("Transition_Open");
       }
    }
    public void LoadWorld(){
        StartCoroutine(LoadTheWorld());
        
    }


    IEnumerator LoadTheWorld()
    {
        
        yield return new WaitForSeconds(3f);
        //CrossFade.GetComponent<Animator>().SetTrigger("Next");
        if ( SceneManager.GetActiveScene().name == "Intro"){
             SceneManager.LoadScene("_Overworld");
        } 
        else
        {
        SceneManager.LoadScene("Intro");
        }
    }
}
