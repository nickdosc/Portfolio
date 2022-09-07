using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Intro_Battle : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cineBrain;
    public Text LogText;
    public GameObject portal;
    public GameObject EnemySpawn;

    public GameObject EscapePortal;
    public GameObject Alec;
    public GameObject hiteffect;
    public Animator fade;
    bool onePress;


    public Animator anuAnim;
    public Animator golemAnim;
    public Animator alecAnim;

    public AudioSource audioSelect;
    public AudioSource area_audio;
    public AudioClip nextsound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlecFail(){
        if(!onePress){
        audioSelect.clip = nextsound;
        audioSelect.loop = false;
        audioSelect.Play();
        onePress = true;
        alecAnim.SetBool("Summon", true);
        LogText.text = "Alec's Summon Has failed.";
        StartCoroutine(StartTheScene());
        }

    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;
		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.Stop();
	}


    IEnumerator StartTheScene(){
        yield return new WaitForSeconds(1f);
        alecAnim.SetBool("Summon", false);
        yield return new WaitForSeconds(2f);
        LogText.text = "??? :Fool, let me show you how it's done.";
        anuAnim.SetBool("Summon", true);
        yield return new WaitForSeconds(0.9f);
        anuAnim.SetBool("Summon", false);
        portal.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        EnemySpawn.SetActive(true);
        LogText.text = "Alec : This is just like my dream.";
        yield return new WaitForSeconds(5f);
        LogText.text = "Alec : But you're not her.";
        yield return new WaitForSeconds(4f);
        LogText.text = "??? : Your soul shall be mine!";
        yield return new WaitForSeconds(4f);
        golemAnim.SetBool("Attack", true);
        hiteffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        hiteffect.SetActive(false);
        alecAnim.SetBool("Damaged", true);
        golemAnim.SetBool("Attack", false);
        LogText.text = "??? : HAHAHA, Feel the pain.";
        yield return new WaitForSeconds(5f);
        LogText.text = "Alec : Ugh.";
        yield return new WaitForSeconds(2f);
        cineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
        cineBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
        yield return new WaitForSeconds(3f);
        LogText.text = "??? : What is this?";
        yield return new WaitForSeconds(5f);
        LogText.text = "??? : Someone is interfering.";
        yield return new WaitForSeconds(5);
        EscapePortal.SetActive(true);
        LogText.text = "??? : NO! I MUST HAVE HIS SOUL.";
        Alec.SetActive(false);
        yield return new WaitForSeconds(2);
        fade.SetBool("out", true);
        StartCoroutine(FadeOut(area_audio, 1));
        yield return new WaitForSeconds(3);
        //Load next scene
        SceneManager.LoadScene("03_Second_Intro");
    }
}
