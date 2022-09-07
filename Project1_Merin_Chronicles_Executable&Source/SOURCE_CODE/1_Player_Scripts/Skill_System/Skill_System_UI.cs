using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_System_UI : MonoBehaviour
{
    /*
    There are three skill paths in the game, these are Life - Trick - Arcane.
    I have named the variables accordingly for each path. The path the player
    will choose will be locked for the rest of the game

    The player will be presented with a screen to choose a path and then
    different screens depending on the path chosen.
    
    */
    public Animator lifeAnim;  // Life Path animator.
    public Animator trickAnim; // Trick Path animator.
    public Animator arcaneAnim; // Aracane Path animator.
    public GameObject Skill_background; // Background of the skill system.
    public GameObject Domain_of_Life; // Life path gameobject.
    public GameObject Domain_of_Trickestery; // Trickstery path gameobject.
    public GameObject Domain_of_Arcane; // Aracne path gameobject.
    public CanvasGroup general_canvas; // The canvas containing all paths.
    public GameObject confirmation; // Extra Confimation in case the player selects one of the paths.
    public GameObject player; // The player gameobject.


    //Path Buttons.
    public Button chooselife;
    public Button chooseTricks;
    public Button chooseArcane;

    //Path Booleans (One true the rest false)
    bool life;
    bool trickster;
    bool arcane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Selecting the a path will present the player with a an extra confirmation of choice, and then
    // move to a diffrent screen with skills.
    public void SelectionLife(){
        //general_canvas.blocksRaycasts = false;
        life = true;
        chooselife.interactable = false;
        chooseTricks.interactable = false;
        chooseArcane.interactable = false;
        confirmation.SetActive(true);
    }
    public void SelectionTrickstery(){
        trickster = true;
       // general_canvas.blocksRaycasts = false;
        chooselife.interactable = false;
        chooseTricks.interactable = false;
        chooseArcane.interactable = false;
        confirmation.SetActive(true);
    }
    public void SelectionArcane(){
      //  general_canvas.blocksRaycasts = false;
        chooselife.interactable = false;
        chooseTricks.interactable = false;
        chooseArcane.interactable = false;
        arcane = true;
        confirmation.SetActive(true);
    }


    //Set the selected path for the player and present with the new screen and skills.
    public void onConfirm(){
        if (life){
        player.GetComponent<PlayerCharacter>().orderOflife = true;
        Skill_background.SetActive(false);
        Domain_of_Life.SetActive(true);
        lifeAnim.SetBool("IsOpen", true);
        confirmation.SetActive(false);
        }
        if(trickster){
        player.GetComponent<PlayerCharacter>().orderOfTrickers = true;
        Skill_background.SetActive(false);
        Domain_of_Trickestery.SetActive(true);
        trickAnim.SetBool("IsOpen", true);
        confirmation.SetActive(false);
        }
        if(arcane){
        Skill_background.SetActive(false);
        Domain_of_Arcane.SetActive(true);
         arcaneAnim.SetBool("IsOpen", true);
        confirmation.SetActive(false);
        player.GetComponent<PlayerCharacter>().orderOfArcane = true;
        }
    }
    // In case the player goes back on the extra confirmation
    public void onBackConfirm(){
     //   general_canvas.blocksRaycasts = true;
        chooselife.interactable = true;
        chooseTricks.interactable = true;
        chooseArcane.interactable = true;
        life = false;
        trickster = false;
        arcane = false;
        confirmation.SetActive(false);
    }

    // Close skill menu.
    public void onGeneralBack(){
        if(life)
        lifeAnim.SetBool("IsOpen", false);
        if(trickster)
        trickAnim.SetBool("IsOpen", false);
        if(arcane)
        arcaneAnim.SetBool("IsOpen", false);
        player.GetComponent<PlayerCharacter>().openSkill = false;
    }
}
