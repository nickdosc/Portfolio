using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Second_Intro_Script : MonoBehaviour
{
    public Text IntroText;
    public Animator Textanim;
    public Animator fadeanim;

    public GameObject Logo;
    
    public GameObject Alec;
    public GameObject AlecTransform;

    public Color TransformColor;

    Color originalAlec;

    bool transform1;
    bool transform2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroPlay1());
        originalAlec = Alec.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform1){
        Alec.GetComponent<SpriteRenderer>().color = Color.Lerp(originalAlec, TransformColor, Mathf.PingPong(Time.time, 1));
        
        }
        if(transform2){
        AlecTransform.GetComponent<SpriteRenderer>().color = Color.Lerp(TransformColor, originalAlec, Mathf.PingPong(Time.time, 1));
        }

    }

    IEnumerator IntroPlay1(){
        yield return new WaitForSeconds(2f);
        IntroText.text = "Dreams...";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(2f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "Am I still dreaming?";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "I can't understand what is happening.";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "But still, this all feels so familiar...";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "I...";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        ///Animation to tranform here
        transform1 = true;
        yield return new WaitForSeconds(5f);
        transform1 = false;
        Alec.GetComponent<SpriteRenderer>().enabled = false;
        AlecTransform.SetActive(true);
        transform2 = true;
    //    yield return new WaitForSeconds(2f);

        yield return new WaitForSeconds(4f);
        transform2 = false;
        AlecTransform.GetComponent<SpriteRenderer>().color = Color.white;
        IntroText.text = "I feel...";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "This realm...";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(2f);
        IntroText.text = "A Game By Nikolas Doschoris";
        Textanim.SetBool("NextLine", true);
        yield return new WaitForSeconds(4f);
        Textanim.SetBool("NextLine", false);
        yield return new WaitForSeconds(1f);
        Logo.SetActive(true);
        yield return new WaitForSeconds(5f);
        fadeanim.SetBool("out", true);
        yield return new WaitForSeconds(2f);
        //Change Scene.

    }
}
