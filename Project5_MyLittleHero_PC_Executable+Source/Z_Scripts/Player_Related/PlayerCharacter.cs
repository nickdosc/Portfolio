using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public Text objectiveUI;
    public Text currencyText;
    public Animator objectiveAnimator;
    public Animator gameoverAnimator;
    public Animator MainMenuAnimator;
    public Animator SkillsMenuAnimator;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heartempty1;
    public GameObject heartempty2;
    public GameObject heartempty3;
    public GameObject heartempty4;
    Material powerup;
    Material swordPowerup;

    public bool interaction;
    public bool initiation;

    public bool locked;

    public float playerspeed;
    public Animator anim;

    public Animator SwordReady;

    public Renderer Sword;
    public SpriteRenderer ActualSword;


    private bool switcher = false;
    public bool armed = false;
    bool attacking = false;

    bool facingup = false;  
    Vector2 movement;
    Rigidbody2D rb2d;


    public int currency = 0;
    float moveVertical;
    float moveHorizontal;
    float spiritpower;
    public int hearts;
    public int maxhealth;
    float timeLeft;
    Color targetColor;
    
    //Player Skills
    //Skill 1 : Circle Attack
    public bool Skill_01 = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        locked = false;
        maxhealth = 3;
        hearts = 3;
        powerup = gameObject.GetComponent<SpriteRenderer>().material;
        swordPowerup = ActualSword.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
         //Player Lock
        if (locked){
        moveHorizontal = 0;
        moveVertical = 0;
        }
        
        currencyText.text = currency.ToString();
       
        if (maxhealth <= 0)
        {
            gameoverAnimator.SetBool("IsOpen", true);
            StartCoroutine(WaitTokill(0.4f));
            // Time.timeScale = 0;

        }
        //Starting HP
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


        if(!locked){
         if (Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0)
        {

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                moveVertical = 0;
                moveHorizontal = Input.GetAxisRaw("Horizontal");
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                moveHorizontal = 0;
                moveVertical = Input.GetAxisRaw("Vertical");
            }

        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        }

            movement = new Vector2(moveHorizontal, moveVertical);
        }



      

        if (moveHorizontal < 0 && ((moveVertical > 0) || (moveVertical < 0) || (moveVertical == 0)))
        {

            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));
                Sword.sortingOrder = 4;
                facingup = true;
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));
                ActualSword.flipX = false;
                ActualSword.flipY = false;


            }
            else if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                if (armed)
                {
                    Sword.sortingOrder = 4;
                    facingup = false;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                }
                else
                {
                    Sword.sortingOrder = 2;
                    facingup = false;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                }

                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

            }
            else
            {

                anim.SetInteger("SpeedX", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
                if (armed)
                {
                    Sword.sortingOrder = 4;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                    facingup = false;
                }
                else
                {
                    Sword.sortingOrder = 2;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                    facingup = false;
                }

            }
        }
        else if (moveHorizontal > 0 && ((moveVertical > 0) || (moveVertical < 0) || (moveVertical == 0)))
        {

            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));
                Sword.sortingOrder = 4;
                ActualSword.flipX = false;
                ActualSword.flipY = false;
                facingup = true;


            }

            else if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                if (armed)
                {
                    Sword.sortingOrder = 4;
                    facingup = false;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                }
                else
                {
                    Sword.sortingOrder = 2;
                    facingup = false;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                }
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));


            }
            else
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(1));
                if (armed)
                {
                    Sword.sortingOrder = 4;
                    facingup = false;
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                }
                else
                {
                    Sword.sortingOrder = 2;
                    facingup = false;
                    ActualSword.flipY = true;

                }

            }
        }
        else if (moveVertical != 0 && (moveHorizontal == 0))
        {
            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));
                Sword.sortingOrder = 4;
                facingup = true;
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));
                ActualSword.flipX = false;
                ActualSword.flipY = false;

            }
            if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                if (armed)
                {
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                    Sword.sortingOrder = 4;
                    facingup = false;
                }
                else
                {
                    ActualSword.flipX = false;
                    ActualSword.flipY = false;
                    Sword.sortingOrder = 2;
                    facingup = false;
                }
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

            }
        }
        else if (moveVertical == 0 && moveHorizontal == 0)
        {
            StartCoroutine(CheckIfChangingDirection());

        }

        //Button to get Armed
        if (Input.GetKeyDown(KeyCode.Z) && !locked)
        {
            if (armed)
            {
                armed = false;
                SwordReady.SetBool("Ready", false);
            }
            else
            {

                SwordReady.SetBool("Ready", true);
                armed = true;
            }

        }
        //Attack Button if Armmed
        if (Input.GetKeyDown(KeyCode.Mouse0) && !locked)
        {
            if (armed)
            {
                attacking = true;
            }
            else
            {
                attacking = false;
            }

            if (attacking)
            {
                SwordReady.SetBool("IsAttacking", true);
                StartCoroutine(PlayAttack(0.5f));
            }

        }


        //Circle Attack
        if (Input.GetKeyDown(KeyCode.Mouse1) && Skill_01 && !locked)
        {
            if (armed)
            {
                attacking = true;
            }
            else
            {
                attacking = false;
            }
            if (attacking)
            {
                SwordReady.SetBool("CircleAttack", true);
                StartCoroutine(PlayCircleAttack(0.5f));
            }

        }

     
        //Objective Button
        if (Input.GetKey(KeyCode.Tab))
        {
            objectiveAnimator.SetBool("IsOpen", true);
        } else
        {
            objectiveAnimator.SetBool("IsOpen", false);
        }

        //MainMenu Button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenuAnimator.SetBool("IsOpen", true);
            gameObject.GetComponent<PlayerCharacter>().enabled = false;
            StartCoroutine(WaitTokill(0.4f));
        }

        //Skills Button
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (switcher)
            {
                SkillsMenuAnimator.SetBool("IsOpen", false);
                switcher = false;
            } else
            {
                SkillsMenuAnimator.SetBool("IsOpen", true);
                switcher = true;
            }
            
        }

        if (!interaction)
        {
            initiation = false;
        }
        //Interaction Button
        if (Input.GetKey(KeyCode.V))
        {
            if (interaction)
            {
                initiation = true;
            }
        }

        //Glowing Effect intensity checks.
        if(armed){ 
           Glowup();
           GlowupSword();
        }
        else{
           GlowDown();
           GlowDownSword();
        }

          
     
    }
    private void  FixedUpdate() 
    {
        

        rb2d.MovePosition(rb2d.position + (movement * playerspeed));
        
    }


    private void Glowup(){
        var intensity = (powerup.color.r + powerup.color.g + powerup.color.b) / 3f;
        var factor = 5f / intensity;
       if (timeLeft <= Time.deltaTime)
        { 
  
        // transition complete
        // assign the target color
        powerup.color = targetColor;
        // start a new transition
        targetColor = new Color(50f, 50f, 50f);
        targetColor = new Color(targetColor.r*factor,targetColor.g*factor, targetColor.b*factor);
        timeLeft = 2.0f;
    }
     else
        {
        // transition in progress
        // calculate interpolated color
        powerup.color = Color.Lerp(powerup.color, targetColor, Time.deltaTime / timeLeft);
    
        // update the timer
        timeLeft -= Time.deltaTime;
    }
    }

    public void GlowDown(){
      
        if (timeLeft <= Time.deltaTime)
        { 
        // transition complete
        // assign the target color
        powerup.color = targetColor;
         // start a new transition
        targetColor = new Color(0.01f, 0.01f, 0.01f);
        timeLeft = 2.0f;
        }
     else
        {
        // transition in progress
        // calculate interpolated color
        powerup.color = Color.Lerp(powerup.color, targetColor, Time.deltaTime / timeLeft);
        // update the timer
        timeLeft -= Time.deltaTime;
    }

    }

    public void GlowupSword(){
      var intensity = (swordPowerup.color.r + swordPowerup.color.g + swordPowerup.color.b) / 3f;
       var factor = 5f / intensity;
       if (timeLeft <= Time.deltaTime)
        { 
        // transition complete
        // assign the target color
        swordPowerup.color = targetColor;
 
         // start a new transition
        targetColor = new Color(50f, 50f, 50f);
        targetColor = new Color(targetColor.r*factor,targetColor.g*factor, targetColor.b*factor);
        timeLeft = 2.0f;
    }
     else
        {
        // transition in progress
        // calculate interpolated color
        swordPowerup.color = Color.Lerp(swordPowerup.color, targetColor, Time.deltaTime / timeLeft);
    
        // update the timer
        timeLeft -= Time.deltaTime;
    }
    }


    public void GlowDownSword(){
      
        if (timeLeft <= Time.deltaTime)
        { 
        // transition complete
        // assign the target color
        swordPowerup.color = targetColor;
         // start a new transition
        targetColor = new Color(0.01f, 0.01f, 0.01f);
        timeLeft = 2.0f;
        }
     else
        {
        // transition in progress
        // calculate interpolated color
        swordPowerup.color = Color.Lerp(swordPowerup.color, targetColor, Time.deltaTime / timeLeft);
        // update the timer
        timeLeft -= Time.deltaTime;
    }
    }

    IEnumerator CheckIfChangingDirection()
    {
        yield return new WaitForSeconds(0.05f);
        if (moveVertical == 0 && moveHorizontal == 0){
            anim.SetInteger("SpeedX", Mathf.RoundToInt(0));
            anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
            
        }
        if (armed)
        {
            Sword.sortingOrder = 4;
            ActualSword.flipX = false;
            ActualSword.flipY = false;
        }
        else
        {
            if(!facingup){
            Sword.sortingOrder = 2;
            ActualSword.flipX = false;
            ActualSword.flipY = false;
            }
            else{
            Sword.sortingOrder = 4;
            ActualSword.flipX = false;
            ActualSword.flipY = false;  
            }
        }

 
 
    }
    IEnumerator PlayAttack(float time)
    {
        yield return new WaitForSeconds(time);
        SwordReady.SetBool("IsAttacking", false);
        attacking = false;
    }

    IEnumerator PlayCircleAttack(float time)
    {
        yield return new WaitForSeconds(time);
        SwordReady.SetBool("CircleAttack", false);
        attacking = false;
    }

    IEnumerator WaitTokill(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0f;
  
    }

}
