using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu_Controller : MonoBehaviour
{
    bool settings; // Check if Setings is open flag.
    [Range(0, 2)]public int counter; // Counter is used to navigate the main menu.
    [Range(0, 3)]public int settingsCounter; // Settings counter is used to navigate the settings menu.
    public GameObject ToLoad; // Load if player has save file

    //Cursor display for each button
    //Main Menu Cursors.
    public GameObject PlayCursor; 
    public GameObject SettingsCursor;
    public GameObject QuitCursor;
    //Settings Cursors.
    public GameObject VolumeCursor;
    public GameObject DeleteCursor;
    public GameObject ContactCursor;
    public GameObject BackCursor;
    public GameObject sound_Check;
    bool triggered;
    bool volume;
    //White Buttons to be shown when pressed
    public GameObject WhitePlay;
    public GameObject WhiteSettings;
    public GameObject WhiteQuit;

    //Animator
    public Animator SettingsMenuAnimator;

    //Fade
    public GameObject Crossfade;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 0) {
             triggered = false;
             AudioListener.volume = 0;
        }
        else
         {
             triggered = true;
             AudioListener.volume = 1;
         }
    }
    void Start()
    {
        //Variable assignment on scene load up.
        Time.timeScale = 1f;
        counter = 0;
        settingsCounter = 0;
        settings = false;

       
    }

    //Player pref checks and menu navigation counters check.
    void Update()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            sound_Check.SetActive(false);
            triggered = false;
        } else
        {
            sound_Check.SetActive(true);
            triggered = true;
        }
        if (AudioListener.volume == 1)
        {
            PlayerPrefs.SetInt("Sound", 1);
            sound_Check.SetActive(true);
            triggered = true;
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            sound_Check.SetActive(false);
            triggered = false;
        }
    
    if (Input.GetKeyDown(KeyCode.DownArrow)){
        if (counter < 2) 
        counter++;
        if(settings)
        if (settingsCounter < 3)
        settingsCounter++;
        
      
    }

    //Menu Navigation
    if (Input.GetKeyDown(KeyCode.UpArrow)){
        if (counter > 0)
        counter--;
        if (settings)
        if (settingsCounter > 0)
        settingsCounter--;

        }


    /*
    The counter displays the current cursor alongside with performing the current button's actions.
    */
    if (counter == 0 && !settings) {
        PlayCursor.SetActive(true);
        SettingsCursor.SetActive(false);
    
    }
    if (counter == 1 && !settings) {
        PlayCursor.SetActive(false);
        SettingsCursor.SetActive(true);
        QuitCursor.SetActive(false);
    
    }
    if (counter == 2 && !settings) {
        SettingsCursor.SetActive(false);
        QuitCursor.SetActive(true);
    }

    if (settingsCounter == 0 && settings){
        VolumeCursor.SetActive(true);
        DeleteCursor.SetActive(false);
    }
    if (settingsCounter == 1) {
        VolumeCursor.SetActive(false);
        DeleteCursor.SetActive(true);
        ContactCursor.SetActive(false);
    }
    if (settingsCounter == 2){
        DeleteCursor.SetActive(false);
        ContactCursor.SetActive(true);
        BackCursor.SetActive(false);

    }
    if (settingsCounter == 3){
        ContactCursor.SetActive(false);
        BackCursor.SetActive(true);
    }

    if (Input.GetKeyDown(KeyCode.Z)){
        //Play button loads the game
        if (counter == 0 && !settings){
            WhitePlay.SetActive(true);
            Crossfade.SetActive(true);
            string path = Application.persistentDataPath + "/player.data";
            if(File.Exists(path)){
                ToLoad.SetActive(true);
                DontDestroyOnLoad(ToLoad);
                //GameObject.Find("SceneManager").GetComponent<TransitionScene>().LoadWorld();
               
                SceneManager.LoadScene("_Overworld");

            } else{
                GameObject.Find("SceneManager").GetComponent<TransitionScene>().LoadWorld();
            }


            
            
            


        }
        //Settings button opens the settings of the game.
        if (counter == 1 && !settings){
            settings = true;
            WhiteSettings.SetActive(true);
            SettingsMenuAnimator.SetBool("IsOpen",true);
            SettingsCursor.SetActive(false);
            VolumeCursor.SetActive(true);
            StartCoroutine(checkVolume());
            
            
        }
        //Quit the application
        if (counter == 2&& !settings){
            Application.Quit();
        }
        //Volume
        if (settingsCounter == 0 && settings && volume) {
            
         if (triggered == false)
        {
            sound_Check.SetActive(true);
            triggered = true;
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.volume = 1;
           
           


        } else
        {
            sound_Check.SetActive(false);
            triggered = false;
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.volume = 0;
        
        }
            
        }
        //Delete Save Data
        if (settingsCounter == 1) {
            string path = Application.persistentDataPath + "/player.data";
            if(File.Exists(path)){
               File.Delete(path);

            } else{
                Debug.LogError("No save file found.");
            }

        }
        //Contact Dev (Placeholder)
        if (settingsCounter == 2) {
            
        }
        //Back
        if (settingsCounter == 3) {
            SettingsMenuAnimator.SetBool("IsOpen", false);
            WhiteSettings.SetActive(false);
            BackCursor.SetActive(false);
            settings = false;
            counter = 0;
            settingsCounter = 0;
            volume = false;
        }
    }

    }//update end
        IEnumerator checkVolume(){
            yield return new WaitForSeconds(0.5f);
            volume = true;
        }
 
}
