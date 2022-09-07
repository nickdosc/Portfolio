using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Animator anim;
    public GameObject fade;

    public GameObject[] Stars;
    public GameObject backArrow;

    public GameObject Levels_1_10;
    public GameObject Levels_11_20;
    public GameObject Levels_21_30;


    int page;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        anim.SetBool("IsOpen", true);
        for (int i =0; i<Stars.Length; i++){
            Stars[i].SetActive(false);
        }
    }

    public void BackPlay(){
        anim.SetBool("IsOpen", false);
        for (int i =0; i<Stars.Length; i++){
            Stars[i].SetActive(true);
        }
    }

    public void loadlevel(string level)
    {
        // bool[] levelcheck = GetComponent<PlayerCharacter>().levelsPassed;
        fade.SetActive(true);
        StartCoroutine(FadetoLevel(level));

    }

    public void NextRealm(){
        if (page < 2)
        page++;
        if (page == 1){
            Levels_1_10.SetActive(false);
            Levels_11_20.SetActive(true); 
            backArrow.SetActive(true);           
        }
        if (page == 2){
            Levels_11_20.SetActive(false);
            Levels_21_30.SetActive(true);
            backArrow.SetActive(true); 
        }

    }

    public void PreviousRealm(){
        if(page>=0)
        page--;
        if (page == 0){
            Levels_1_10.SetActive(true);
            Levels_11_20.SetActive(false); 
            backArrow.SetActive(false);            
        }
        if (page == 1){
            Levels_11_20.SetActive(true);
            Levels_21_30.SetActive(false);
            backArrow.SetActive(true); 
        }

    }
    public void Quit(){
        Application.Quit();
    }



    IEnumerator FadetoLevel(string level)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
