using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroHandler : MonoBehaviour
{
    public Text IntroText;
    public Animator anim;
    public Animator fadeanim;
    // A script to handle the intro text with some delay, used when play is pressed for the firs time with no save file
    void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 0) {
          
            AudioListener.volume = 0;
            
            
        }
         else
         {
            
            AudioListener.volume = 1;
            
         }
    }
    void Start()
    {
        StartCoroutine(IntroPlay1());
    }

 
    IEnumerator IntroPlay1(){


        yield return new WaitForSeconds(2f);
        IntroText.text = "There once lived a girl...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "Lost in a world full of magic...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "Driven away from her home by an injustice...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(5f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "With a Mirror in hand, and a heart set to claim justice...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "She will travel the world...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        fadeanim.GetComponent<Animator>().Play("Transition_Closed");
        GameObject.Find("SceneManager").GetComponent<TransitionScene>().LoadWorld();
    }
    
}
