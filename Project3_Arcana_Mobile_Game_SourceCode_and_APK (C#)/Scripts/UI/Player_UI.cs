using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dispel_magic;
    public GameObject levelcomplete_UI;
    public GameObject level_blocker;
    public GameObject physical_blocker;
    public GameObject dispel_button;
    public GameObject dispel_area;
    public GameObject fade;
    public GameObject in_game_menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dispel(){
        dispel_magic.SetActive(true);
        dispel_area.GetComponent<Dispel>().dispelled = true;
        dispel_area.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(waitForAnimation(2.4f));
        dispel_button.SetActive(false);
    }

    public void NextLevel(){
        Time.timeScale = 1f;
        fade.SetActive(true);
        StartCoroutine(FadetoLevel());
        
    }

    public void QuitToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("$_Main_Menu");
    }

    public void Continue(){
        Time.timeScale = 1f;
        in_game_menu.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu(){
        if(GameObject.Find("Player").GetComponent<Player_Script>().gameover == false){
        in_game_menu.SetActive(true);
        Time.timeScale = 0f;
        }
    }

    IEnumerator waitForAnimation(float time){
        yield return new WaitForSeconds(time);
        dispel_magic.SetActive(false);
        level_blocker.SetActive(false);
        Destroy(physical_blocker);
        Destroy(dispel_area);
    }

    
    IEnumerator FadetoLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
