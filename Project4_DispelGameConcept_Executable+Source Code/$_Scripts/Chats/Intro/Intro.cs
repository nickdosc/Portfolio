using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject ChatImage;
    bool complete = false;
    bool chatting = false;
    public Dialogue[] diag;
    public bool[] booldiag;
    float t; //Time
    float p; //Second Time
    public float duration; //Duration of camera until fully zoomed
    public Cinemachine.CinemachineVirtualCamera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player_Character").GetComponent<Player_Script>().locked = true;
        StartCoroutine(WelcomeToDispel());
    }

    // Update is called once per frame
    void Update()
    {
        if(chatting){
            t += Time.deltaTime/duration;
            mainCamera.m_Lens.OrthographicSize = Mathf.Lerp(3.5f, 2, t);
        }
        if(!chatting && complete){
            p += Time.deltaTime/duration;
            mainCamera.m_Lens.OrthographicSize = Mathf.Lerp(2, 3.5f, p);
        }
        if (FindObjectOfType<DialogueManager>().isDone && booldiag[0]){
            ChatImage.SetActive(false);
            booldiag[0] = false;
            chatting = false;
            complete = true;
        }

        if (FindObjectOfType<DialogueManager>().isDone && complete){
            StartCoroutine(KillEvent());
            
        }
    }

    IEnumerator WelcomeToDispel(){

        yield return new WaitForSeconds(2f);
            booldiag[0] = true;
            chatting = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag[0]);
            ChatImage.SetActive(true);
            
    }
    IEnumerator KillEvent(){
        yield return new WaitForSeconds(3f);
        GameObject.Find("Player_Character").GetComponent<Player_Script>().locked = false;
        Destroy(gameObject);
    }


}
