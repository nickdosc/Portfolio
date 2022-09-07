using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Animator fade_anim;
    
    public AudioSource audio_source;
    public AudioClip clicksound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        audio_source.clip = clicksound;
        audio_source.loop = false;
        audio_source.Play();
        fade_anim.SetBool("out", true);
        StartCoroutine(StartIntro());
    }

    IEnumerator StartIntro(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("$Intro");
    }
}
