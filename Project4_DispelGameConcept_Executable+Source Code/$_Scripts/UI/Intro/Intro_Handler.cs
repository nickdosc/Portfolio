using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_Handler : MonoBehaviour
{
    public Text IntroText;
    public Animator anim;
    public Animator fadeanim;
    // Start is called before the first frame update
    void Awake()
    {
       /* if (PlayerPrefs.GetInt("Sound") == 0) {
          
            AudioListener.volume = 0;
            
            
        }
         else
         {
            
            AudioListener.volume = 1;
            
         }*/
    }
    void Start()
    {
        StartCoroutine(IntroPlay1());
    }

 
    IEnumerator IntroPlay1(){

        //Intro dialogue

        yield return new WaitForSeconds(2f);
        IntroText.text = "Dreams...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "They say dreams have meanings...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "But in my dreams, I dream of magic realms.";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(5f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "...and her...";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "She's always better than me.";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "Why do I keep dreaming of this place.";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "In the end, she always throws a card to me, with the letter 'D'.";
        anim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        anim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        //fade
        fadeanim.SetBool("out", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("00_House_Starting_Level");
        //level change
    }
}
    
