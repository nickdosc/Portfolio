using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext_Scene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeanim;
    public AudioSource area_audio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
        fadeanim.SetBool("out", true);
        StartCoroutine(WaitToTransition());
        }
    }
    
    IEnumerator WaitToTransition(){
        StartCoroutine(FadeOut(area_audio, 1));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;
		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.Stop();
	}
}
