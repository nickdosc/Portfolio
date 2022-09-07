using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class School_Script : MonoBehaviour
{
   bool initial = false;
    bool proccesing = false;
    bool complete = false;
    bool chatting = false;
    bool NextDialogue = false;
    public Dialogue[] diag;
    bool firstDiag;
    int totaldialogues = 0;
    int currentdialogueNum = 0;
    float t; //Time
    float p; //Second Time
    public float duration; //Duration of camera until fully zoomed
    public Animator fade;
    public GameObject portal1;
    public AudioSource area_audio;
    public Cinemachine.CinemachineVirtualCamera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        initial = true;
        totaldialogues = diag.Length;
    }

    // Update is called once per frame
    void Update()
    {


        //After First Dialogue, if we have more we need to display them, but also give the player time to read them
        if(firstDiag && !proccesing && (currentdialogueNum <= totaldialogues) && !initial){
            proccesing = true;
            NextDialogue = true;
            ManyDialogues();
            
        }

        if(currentdialogueNum == totaldialogues && firstDiag){
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().MultiDiag = false;
            complete = true;
        }


        if(chatting){
            t += Time.deltaTime/duration;
            mainCamera.m_Lens.OrthographicSize = Mathf.Lerp(3.5f, 2, t);
        }
        if(!chatting && complete){
            p += Time.deltaTime/duration;
            mainCamera.m_Lens.OrthographicSize = Mathf.Lerp(2, 3.5f, p);
        }
        if (FindObjectOfType<DialogueManager>().isDone && !complete){
            proccesing = false;
            NextDialogue = false;
        }

        if (FindObjectOfType<DialogueManager>().isDone && complete){
            chatting = false;
            StartCoroutine(KillEvent());
            
        }

        if (FindObjectOfType<DialogueManager>().isDone && initial && !complete){
            initial = false;
            if(currentdialogueNum == totaldialogues){
                complete = true; 
            }
        }
    }

    IEnumerator StartDialogue(){

        yield return new WaitForSeconds(0.2f);
        chatting = true;
        FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
        currentdialogueNum = totaldialogues;      
    }
    IEnumerator KillEvent(){
        yield return new WaitForSeconds(3f);
        portal1.SetActive(true);
        fade.SetBool("out", true);
        StartCoroutine(FadeOut(area_audio, 1));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("battle_scene_intro");
        //transition to scene

    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;
		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.Stop();
	}

    public void ManyDialogues(){
        chatting = true;
        if(!firstDiag){
            firstDiag = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
            currentdialogueNum = 1;
        }
        if(NextDialogue && firstDiag){
            FindObjectOfType<DialogueManager>().StartDialogue(diag[currentdialogueNum]);
            currentdialogueNum++;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            GameObject.Find("Player_Character").GetComponent<Player_Script>().locked = true;
            if(diag.Length > 1){
                GameObject.Find("DialogueManager").GetComponent<DialogueManager>().MultiDiag = true;
                ManyDialogues();
            }
            else{
            StartCoroutine(StartDialogue());
            }
        }
    }
}
