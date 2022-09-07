using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Player_Script : MonoBehaviour
{
    public float playerspeed;
    public Animator anim;

    private Rigidbody2D rb2d;

    float moveVertical;
    float moveHorizontal;
    public bool locked;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1f;
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
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


    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + (movement * playerspeed));
    }



}
