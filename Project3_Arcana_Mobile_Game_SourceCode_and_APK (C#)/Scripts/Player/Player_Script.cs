using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Player_Script : MonoBehaviour
{
    public GameObject game_over_HUD;
    public GameObject pure_red_effect;
    public int red_gems;
    public float playerspeed;
    public Animator anim;

    private Rigidbody2D rb2d;

    float moveVertical;
    float moveHorizontal;
    float timeLeft;
    public bool isDestroyer;
    public bool locked;
    public bool gameover;
    public bool returntoState;
    public bool pure_state;
    public int levelsPassed;
    //bool Menuopen = false;

    public Text red_gems_UI;
    Vector2 movement;
    SpriteRenderer playerSprite;
    Color targetColor;

    // Start is called before the first frame update
    void Start()
    {   
        pure_state = false;
        Time.timeScale = 1f;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        red_gems = 0;
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 0;
            //FindObjectOfType<AudioListener>().enabled = false;
        }
        else
        {
            AudioListener.volume = 1;
            //FindObjectOfType<AudioListener>().enabled = true;
        }
        isDestroyer = false;
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if(gameover){
            game_over_HUD.SetActive(true);
            
        }

        if(returntoState){
           Glowup(Color.white);
           StartCoroutine(ReturnState());
        }

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 0;
            //FindObjectOfType<AudioListener>().enabled = false;
        }
        else
        {
            AudioListener.volume = 1;
            //FindObjectOfType<AudioListener>().enabled = true;
        }
        //int spawnpointIndex = Random.Range(0, projectileSpawnPoint.Length);

        red_gems_UI.text = red_gems.ToString();
    

        //###################### MOBILE VERSION ##########################
        //Button Check
        if(!locked){
         if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 && CrossPlatformInputManager.GetAxis("Vertical") != 0)
        {

            if (CrossPlatformInputManager.GetAxis("Horizontal") != 0)
            {
               moveVertical = 0;
               moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            }
            else if (CrossPlatformInputManager.GetAxis("Vertical") != 0)
            {
                moveHorizontal = 0;
                moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
            }

        }
        else
        {
            moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        }
        
 
        }

        if(locked){
            moveHorizontal = 0;
            moveVertical = 0;
        }


          if (moveHorizontal < 0 && ((moveVertical > 0) || (moveVertical < 0) || (moveVertical == 0)))
        {

            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

            }
            else if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

            }
            else
            {

                anim.SetInteger("SpeedX", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedY", Mathf.RoundToInt(0));


            }
        }
        else if (moveHorizontal > 0 && ((moveVertical > 0) || (moveVertical < 0) || (moveVertical == 0)))
        {

            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));

            }

            else if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));

                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));


            }
            else
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(1));


            }
        }
        else if (moveVertical != 0 && (moveHorizontal == 0))
        {
            if (moveVertical > 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(1));

                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));


            }
            if (moveVertical < 0)
            {

                anim.SetInteger("SpeedY", Mathf.RoundToInt(-1));
                anim.SetInteger("SpeedX", Mathf.RoundToInt(0));

            }
        }
        else if (moveVertical == 0 && moveHorizontal == 0)
        {
            anim.SetInteger("SpeedX", Mathf.RoundToInt(0));
            anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
        }



        movement = new Vector2(moveHorizontal, moveVertical);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //FindObjectOfType<PlayerUI>().OpenMenu();
            /*if (Menuopen)
            {
                FindObjectOfType<PlayerUI>().CloseMenu();
                Menuopen = false;
            } else
            {
                FindObjectOfType<PlayerUI>().OpenMenu();
                Menuopen = true;
            }
            */
        }

        if(pure_state){
            pure_state = false;
            StartCoroutine(PureGemAbsorbed());
        }

    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + (movement * playerspeed));
    }



    //Power up Dispel
    public void Glowup(Color target){
       if (timeLeft <= Time.deltaTime)
        { 
        
        // transition complete
        // assign the target color
        //playerSprite.color = target;
        // start a new transition
        
        target = new Color(target.r,target.g, target.b);
        timeLeft = 2.0f;
    }
     else
        {
        // transition in progress
        // calculate interpolated color
        playerSprite.color = Color.Lerp(playerSprite.color, target, Time.deltaTime / timeLeft);
    
        // update the timer
        timeLeft -= Time.deltaTime;
    }
    }

    IEnumerator ReturnState(){
        yield return new WaitForSeconds(2f);
        returntoState = false;
    }
    

    IEnumerator PureGemAbsorbed(){
        pure_red_effect.SetActive(true);
        yield return new WaitForSeconds(2f);
        pure_red_effect.SetActive(false);
       
    }


}
