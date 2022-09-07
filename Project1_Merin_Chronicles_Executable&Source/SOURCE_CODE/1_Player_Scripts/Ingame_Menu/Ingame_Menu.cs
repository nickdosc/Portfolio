using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Ingame_Menu : MonoBehaviour
{
    public bool inmenu; // Flag to check if menu is open
    public GameObject player; // Get the player game object.
    public GameObject ingameMenu; // The ingame menu game object.
    public GameObject settings; // The setings UI game object.
    public Animator menu_anim; // The in game menu animator.
    public GameObject sound_Check; // The sound check for the player prefs.
    public Toggle soundToggle; // The toggle to change the player prefs regarding sound.
    bool triggered; // Flag to check if sound is on.
    bool onload; // Check in on first load.



    
    // Set the sound to be active if its the first time we launch the game else turn it off if the player has selected so from the main menu or in game menu.
    void Awake()
    {   
        onload = true;
        if (PlayerPrefs.GetInt("Sound") == 0) {
            triggered = false;
            AudioListener.volume = 0;
            soundToggle.isOn = false;
            onload = false;
            
        }
         else
         {
            triggered = true;
            AudioListener.volume = 1;
            soundToggle.isOn = true;
            onload = false;
         }
        
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Resumes the game and sets the timescale to 1.
    public void Resume(){
        player.GetComponent<PlayerCharacter>().menu = false;
        Time.timeScale = 1f;
        menu_anim.SetBool("IsOpen", false);
    }

    //Opens the settings ui panel.
    public void Settings(){
        settings.SetActive(true);
        ingameMenu.GetComponent<Canvas>().enabled = false;
    }

    public void Back(){

    }

    //closes settings panel.
    public void BackSettings(){
        settings.SetActive(false);
        ingameMenu.GetComponent<Canvas>().enabled = true;
    }
    //Saves the game with current values.
    public void Save(){
        SaveSystem.SavePlayer(player.GetComponent<PlayerCharacter>());
        
    }

    //Quits to the main menu.
    public void Quit(){
        SceneManager.LoadScene("$0_MainMenu");
    }

    //Reloads the scene.
    public void Retry(){
        SceneManager.LoadScene("_Overworld");
    }

    //Mute all audio from all sources.
    public void MuteAudio(){
        if (triggered == false && !onload)
        {
            sound_Check.SetActive(true);
            triggered = true;
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.volume = 1;
            //FindObjectOfType<AudioListener>().enabled = true;
           


        } else
        {
            sound_Check.SetActive(false);
            triggered = false;
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.volume = 0;
            //FindObjectOfType<AudioListener>().enabled = false;
        }
    }
}
