using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Photon.MonoBehaviour
{


    public PhotonView photonView;
    [SerializeField] private float playerspeed;


    [SerializeField] public bool locked;
    [SerializeField] private Animator anim;
    private Animator objectiveAnimator;

   
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject PlayerVCM_Camera;
    public Text PlayerNameText;


    Vector2 movement;
    Rigidbody2D rb2d;


    public int currency = 0;
    float moveVertical;
    float moveHorizontal;
    float spiritpower;
    public int maxhealth;
    float timeLeft;
    Color targetColor;


    // Start is called before the first frame update
    
    private void Awake(){
        if(photonView.isMine){
            objectiveAnimator = GameObject.Find("Quest_Log").GetComponent<Animator>();
            PlayerCamera.SetActive(true);
            PlayerVCM_Camera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;
        }
        else{
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.cyan;
        }
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Player movement Handling.
    [PunRPC]
    void Update()
    {
        if(photonView.isMine){ 
            //Player Lock
        if (locked){
        moveHorizontal = 0;
        moveVertical = 0;
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
            StartCoroutine(CheckIfChangingDirection());

        }
   

        //Open Objective UI
        if(Input.GetKey(KeyCode.Tab))
        {
            objectiveAnimator.SetBool("isOpen", true);
        }
        else
        {
            objectiveAnimator.SetBool("isOpen", false);
        }
     
    }//Photonview Is mine up to here

        }
         
    [PunRPC]
    private void  FixedUpdate() 
    {
        if(photonView.isMine)
        rb2d.MovePosition(rb2d.position + (movement * playerspeed));
        
    }

 

    IEnumerator CheckIfChangingDirection()
    {
        yield return new WaitForSeconds(0.05f);
        if (moveVertical == 0 && moveHorizontal == 0){
            anim.SetInteger("SpeedX", Mathf.RoundToInt(0));
            anim.SetInteger("SpeedY", Mathf.RoundToInt(0));
            
        }
 
    }
 

    IEnumerator WaitTokill(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0f;
  
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player"){
            Physics2D.IgnoreCollision(collisionInfo.collider, GetComponent<Collider2D>());
        }
    }

}
