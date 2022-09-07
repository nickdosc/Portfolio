using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{

    //Initial Variable declaration
    public GameObject firstEvent; //For the first boot of the game
    public GameObject Projectile; //The Projectile of the first skill learnt by the player
    public GameObject Gameover_Menu; //The UI menu for game over.
    public GameObject ingame_Menu; // The UI for the in game menu.
    public Animator Objective_UI; // The animator that controls the current objective
    public Text objective;  // The text of the current objective.

    public Animator menu_anim; // The in game menu animator
    public float playerspeed; // The speed of the player
    float moveVertical; // The current vertial speed of the player
    float moveHorizontal; // The current horizontal speed of the player.
    public Animator anim; // The player animation.

    public bool menu; // A boolean used to check if the menu is open.
    public bool interaction; // If the player is interacting with an NPC turn this boolean on.

    public bool initiation; // Initiation is used when a dialogue is initiated by the player and not an event.

    Vector2 movement; // A vector controlling movement.
    Rigidbody2D rb2d; // The rigidbody 2d component of the player.

    public int hearts; // The current HP of the player.
    public int maxhealth; // The max HP of the player.

    public float pushstrength; // Projectile skill push back power.
    bool cooldown = true; // Cooldown on Projectile skill.

    public bool locked = false; // If player is locked, movement is restricted.

    //Directional Variables.
    public bool iamLeft;
    public bool iamRight;
    public bool iamDown;
    public bool iamUp;


    public Text currencyText;

    //Skill Unlocks
    public bool Mirror_Projectile = false; //First Skill

    //Skill System Booleans and Variables
    public Animator skillanim1;
    public Animator skillAnimlife;
    public Animator skillAnimTrick;
    public Animator skillAnimArcane;
    public bool openSkill;
    public bool orderOflife;
    public bool orderOfTrickers;
    public bool orderOfArcane;






    //UI Hearts
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heartempty1;
    public GameObject heartempty2;
    public GameObject heartempty3;
    public GameObject heartempty4;

    public int currency = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Inital Variables for the Game, Time scale is set to one in case of game over, Retry or load
        Time.timeScale = 1f;
        rb2d = GetComponent<Rigidbody2D>();
        iamDown = true;
        iamUp = false;
        iamRight = false;
        iamLeft = false;
        //Check if there is a previous save file
        if(GameObject.Find("ToLoad") != null){
            Destroy(firstEvent);
            locked = false;
            PlayerData data = SaveSystem.LoadPlayer();
            
            maxhealth = data.health;
            currency = data.coins;

            gameObject.transform.position = new Vector3(data.position[0], data.position[1], 0);

            objective.text = data.objectiveText;

            if(data.hasSkill1)
            Mirror_Projectile = true;
        
      
        } else {
        maxhealth = 3;
        hearts = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {   



         currencyText.text = currency.ToString();
       
        //Check if player is alive
        if (maxhealth <= 0)
        {
            ingame_Menu.GetComponent<Canvas>().enabled = false;
            Gameover_Menu.SetActive(true);
            Time.timeScale = 0;

        }

        //Starting Player Health
        if (hearts <= 3)
        {
            if (maxhealth != 3)
            {
                if (maxhealth == 2)
                {
                    //  GameObject.Find("HealthPoint3").SetActive(false);
                    //  GameObject.Find("HeartEmpy3").SetActive(true);
                    heart1.SetActive(false);
                    heartempty1.SetActive(true);


                }
                if (maxhealth == 1)
                {
                    //   GameObject.Find("HealthPoint2").SetActive(false);
                    //   GameObject.Find("HeartEmpy2").SetActive(true);
                    heart2.SetActive(false);
                    heartempty2.SetActive(true);

                }
                if (maxhealth == 0)
                {
                    heart3.SetActive(false);
                    heartempty3.SetActive(true);
                }

            }
        }
        //If Player has 4 hearts
        if (hearts ==4)
        {
            if (maxhealth != 4)
            {
                if (maxhealth == 3)
                {
                    //  GameObject.Find("HealthPoint3").SetActive(false);
                    //  GameObject.Find("HeartEmpy3").SetActive(true);
                    heart4.SetActive(false);
                    heartempty4.SetActive(true);


                }
                if (maxhealth == 2)
                {
                    //  GameObject.Find("HealthPoint3").SetActive(false);
                    //  GameObject.Find("HeartEmpy3").SetActive(true);
                    heart1.SetActive(false);
                    heartempty1.SetActive(true);
                    heartempty4.SetActive(true);


                }
                if (maxhealth == 1)
                {
                    //   GameObject.Find("HealthPoint2").SetActive(false);
                    //   GameObject.Find("HeartEmpy2").SetActive(true);
                    heart2.SetActive(false);
                    heartempty2.SetActive(true);
                    heartempty4.SetActive(true);

                }
                if (maxhealth == 0)
                {
                    heart3.SetActive(false);
                    heartempty3.SetActive(true);
                    heartempty4.SetActive(true);
                }

            }
        }    


    //Player Lock for Dialogues
    if (locked){
        moveHorizontal = 0;
        moveVertical = 0;
    }
    //Player Movement
    if (!locked) {

        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                moveVertical = 0;
                moveHorizontal = Input.GetAxis("Horizontal");
             
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                moveHorizontal = 0;
                moveVertical = Input.GetAxis("Vertical");
               
            }
            

        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
    }

        if (moveHorizontal > 0){
            moveHorizontal = 1;
        }
        if (moveHorizontal < 0){
            moveHorizontal = -1;
        }
        if (moveVertical > 0){
            moveVertical = 1;
        }
        if (moveVertical < 0){
            moveVertical = -1;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
            moveHorizontal = 0;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)){
            moveVertical = 0;
        }

        movement = new Vector2(moveHorizontal, moveVertical);

        //Player Animations
        //Check animator according to movement in order to decide which animation should be displayed also mark the current direction of the player
        //The current direction of the player is imporant for the projectile skill learnt later in the game.
        if (moveHorizontal < 0 && ((moveVertical > 0) || (moveVertical < 0) || (moveVertical == 0)))
        {

            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

                iamUp = true;
                iamDown = false;
                iamLeft = false;
                iamRight = false;


            }
            else if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

                iamDown = true;
                iamUp = false;
                iamLeft = false;
                iamRight = false;

            }
            else
            {
                anim.SetInteger("SpeedX", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedY", Mathf.RoundToInt(0));

                iamLeft = true;
                iamDown = false;
                iamRight = false;
                iamUp = false;
            }
        }
        else if (moveHorizontal > 0 && ((moveVertical > 0) || (moveVertical < 0) || (moveVertical == 0)))
        {

            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));

                iamUp = true;
                iamDown = false;
                iamLeft = false;
                iamRight = false;
            }

            else if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

                iamDown = true;
                iamLeft = false;
                iamRight = false;
                iamUp = false;


            }
            else
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(1));
              
                iamRight = true;
                iamDown = false;
                iamLeft = false;
                iamUp = false;
               

            }
        }
        else if (moveVertical != 0 && (moveHorizontal == 0))
        {
            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

                iamUp = true;
                iamDown = false;
                iamLeft = false;
                iamRight = false;
           

            }
            if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));         
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

                iamDown = true;
                iamUp = false;
                iamLeft = false;
                iamRight = false;

            }
        }
        else if (moveVertical == 0 && moveHorizontal == 0)
        {
            StartCoroutine(CheckIfChangingDirection());

        }

        //Button to see objective
        if (Input.GetKey(KeyCode.Tab))
        {
            Objective_UI.SetBool("IsOpen", true);
        }else{
            Objective_UI.SetBool("IsOpen", false);
        }


        //Attack Button Projectile launch and camera shake
        if (Input.GetKey(KeyCode.Z) && !locked && Mirror_Projectile)
        //if (Input.GetKey(KeyCode.Z))
        {
          if(cooldown == true) {
            if (iamDown){
                locked = true;
                cooldown = false;
                anim.SetBool("IsAttackingDown", true);
                Instantiate(Projectile, gameObject.transform.position + new Vector3(0f,-0.5f), Quaternion.identity);
                StartCoroutine(Refresh_MirrorProjectile(0.6f));
                CameraShake.Instance.ShakeCamera(3f, 0.1f);
                rb2d.AddForce(transform.up * pushstrength);

            }
            if(iamUp){
                locked = true;
                cooldown = false;
                anim.SetBool("IsAttackingUp", true);
                Instantiate(Projectile, gameObject.transform.position + new Vector3(0f,0.5f), Quaternion.identity);
                StartCoroutine(Refresh_MirrorProjectile(0.6f));
                CameraShake.Instance.ShakeCamera(3f, 0.1f);
                rb2d.AddForce(-transform.up * pushstrength);
            }
            if (iamLeft){
                locked = true;
                cooldown = false;
                anim.SetBool("IsAttackingLeft", true);
                Instantiate(Projectile, gameObject.transform.position + new Vector3(-0.5f,0f), Quaternion.identity);       
                StartCoroutine(Refresh_MirrorProjectile(0.6f));
                CameraShake.Instance.ShakeCamera(3f, 0.1f);
                rb2d.AddForce(transform.right * pushstrength);
      

            }
            if(iamRight){
                locked = true;
                cooldown = false;
                anim.SetBool("IsAttackingRight", true);
                Instantiate(Projectile, gameObject.transform.position + new Vector3(0.5f,0f), Quaternion.identity);
                StartCoroutine(Refresh_MirrorProjectile(0.6f));
                CameraShake.Instance.ShakeCamera(3f, 0.1f);
                rb2d.AddForce(-transform.right * pushstrength);
               
            }
          }
           
        }

        //MainMenu Button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // MainMenuAnimator.SetBool("IsOpen", true);
          //  gameObject.GetComponent<PlayerCharacter>().enabled = false;
          
        }

        //Skills Button
        if (Input.GetKeyDown(KeyCode.K))
        {
          if(openSkill){
            if(!orderOfArcane && !orderOflife && !orderOfTrickers){
              skillanim1.SetBool("Selection", false);
              openSkill = false;
             }
            else{
                if(orderOflife){
                        skillAnimlife.SetBool("IsOpen", false);
                        openSkill = false;
                }
                else if(orderOfTrickers){
                        skillAnimTrick.SetBool("IsOpen", false);
                        openSkill = false;
                }
                else if(orderOfArcane){
                        skillAnimArcane.SetBool("IsOpen", false);
                        openSkill = false;
                }
            }

          } 
          else{

          if(!orderOfArcane && !orderOflife && !orderOfTrickers){
              skillanim1.SetBool("Selection", true);
              openSkill = true;
          }
          else{
                if(orderOflife){
                        skillAnimlife.SetBool("IsOpen", true);
                        openSkill = true;
                }
                else if(orderOfTrickers){
                        skillAnimTrick.SetBool("IsOpen", true);
                        openSkill = true;
                }
                else if(orderOfArcane){
                        skillAnimArcane.SetBool("IsOpen", true);
                        openSkill = true;
                }
           
          }

          }
            
        }

        if (!interaction)
        {
            initiation = false;
        }
        //Interaction Button
        if (Input.GetKey(KeyCode.E))
        {
            if (interaction)
            {
                initiation = true;
            }
        }
    

        //Menu Button
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!menu){
            menu = true;
            menu_anim.SetBool("IsOpen", true);
            StartCoroutine(PauseGame());
            }
            else if (menu){
            menu = false;
            menu_anim.SetBool("IsOpen", false);
            Time.timeScale = 1f;
            }    

        }



        
   

    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + (movement * playerspeed));
    }

    private void GameOver(){
        Time.timeScale = 0f;
        Gameover_Menu.SetActive(true);
        
    }

    //Animator check to see if player is idle
    IEnumerator CheckIfChangingDirection()
    {
        yield return new WaitForSeconds(0.1f);
        if (moveVertical == 0 && moveHorizontal == 0){
            anim.SetInteger("SpeedX", Mathf.RoundToInt(0));
            anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
        }
    }

    IEnumerator Refresh_MirrorProjectile(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("IsAttackingDown", false);
        anim.SetBool("IsAttackingUp", false);
        anim.SetBool("IsAttackingLeft", false);
        anim.SetBool("IsAttackingRight", false);
        cooldown = true;
        locked = false;
    
 
  
    }

    IEnumerator PauseGame(){
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
    
}
