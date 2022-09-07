using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class NPC_Behaviour : MonoBehaviour
{
    public Dialogue diag; //Dialogue of the NPC
    Vector2 LocationofPatrol; // Patrol radius of the NPC
    public float speed; // NPC Speed
    public Animator anim; // NPC animator
    public bool cooldownOnpatrol = false; //Patrol cooldown on NPC
    public bool patrolling = false; // Flag to check if NPC is patrolling
    bool done = false; // If NPC is done patrolling
    public GameObject container; // The radius in which the NPC patrols
    public GameObject AITarget; // The waypoint target of the NPC to move towards.
    public GameObject Point; // Point is an empty gameobject spawned to initiate the movement of the NPC according to world values.
    Bounds bounds; // The patrol bounds.

    //Values are explained later in the script.
    private float valueX;
    private float valueY;

    public bool isInside; // Check if the player is inside
    bool talking; // Check if the player is talking to the npc
    bool notmoving = false; // Check if the NPC is moving


   


    // Start is called before the first frame update
    void Start()
    {
        
        AITarget.GetComponent<AIPath>().maxSpeed = speed;
        //Get bounds of the patrol area, and player trigger area.
        bounds = container.GetComponent<Collider2D>().bounds;


    }

    // Update is called once per frame
    void Update()
    {   
        //Animator check
        if(!notmoving)
        CheckAnim(); 

        //If NPC has reached the end of path, pick a new one.
        if(patrolling && AITarget.GetComponent<AIPath>().reachedEndOfPath && !done && !talking) {
            notmoving = true;
            done = true;
            anim.SetInteger("SpeedX", 0);
            anim.SetInteger("SpeedY", 0);
            StartCoroutine(WaitToRestartPatrol());
        }

     
        
        //If player initiates a dialogue, display the dialogue and stop the NPC from patrolling
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().initiation && isInside){
            AITarget.GetComponent<AIPath>().StopAllCoroutines();
            AITarget.GetComponent<BoxCollider2D>().enabled = false;
            AITarget.GetComponent<AIPath>().enabled = false;
            AITarget.GetComponent<Seeker>().enabled = false;
            AITarget.GetComponent<AIDestinationSetter>().enabled = false;
            StopAllCoroutines();
            patrolling = false;
            talking = true;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = true;
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
        }

        //If the NPC is not talking nor patrolling, start patrolling.
        if(!patrolling && !talking) {
            patrolling = true;
            notmoving = false;
            PatrolArea();
            Point.transform.localPosition = new Vector3(LocationofPatrol.x, LocationofPatrol.y, 0);
            AITarget.GetComponent<AIDestinationSetter>().target = Point.transform;
           
        }
        
        //If dialogue is complete start pathing again.
        if (FindObjectOfType<DialogueManager>().isDone && talking){
            patrolling = true;
            notmoving = false;
            talking = false;
            StartCoroutine(AfterTalk());
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false; 
            done = false;
                 
        }
      
    
    
    }


    //Function to define in which axis the enemy is moving so the animator can adjust.
    private void CheckAnim(){

        if (!isInside){
           //Calculate a value to decide in which direction you are moving more, so the animator can pick that animation.
           //Because there is diagonal movement for NPCs but no diagonal animations. (By design choice)
        valueX = (gameObject.transform.position.x - Point.transform.position.x);
        valueY = (gameObject.transform.position.y - Point.transform.position.y);
            //Convert the values to positives so we can se which one is more affected.
        Mathf.Abs(valueX);
        Mathf.Abs(valueY);


        if(valueX > valueY){
            if (gameObject.transform.position.x - Point.transform.position.x < 0){
                anim.SetInteger("SpeedX", 1);
                anim.SetInteger("SpeedY", 0);
            }
            else if (gameObject.transform.position.x - Point.transform.position.x > 0){
                anim.SetInteger("SpeedX", -1);
                anim.SetInteger("SpeedY", 0);
            }
            else if (gameObject.transform.position.x - Point.transform.position.x == 0){
                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", 0);
            }   
        }
        else if (valueY > valueX){
                if (gameObject.transform.position.y - Point.transform.position.y < 0){
                anim.SetInteger("SpeedY", 1);
                anim.SetInteger("SpeedX", 0);
            }
            else if (gameObject.transform.position.y - Point.transform.position.y > 0){
                anim.SetInteger("SpeedY", -1);
                anim.SetInteger("SpeedX", 0);
            }
            else if (gameObject.transform.position.y - Point.transform.position.y == 0){
                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", 0);
            }
        }
        else if(valueX == valueY) {
                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", 0);
        }
        }
    else if (isInside) {
        GameObject player = GameObject.Find("Player");
        valueX = (gameObject.transform.position.x - player.transform.position.x);
        valueY = (gameObject.transform.position.y - player.transform.position.y);
        Mathf.Abs(valueX);
        Mathf.Abs(valueY);


        if(valueX > valueY){
            if (gameObject.transform.position.x - player.transform.position.x < 0){
                anim.SetInteger("SpeedX", 1);
                anim.SetInteger("SpeedY", 0);
            }
            else if (gameObject.transform.position.x - player.transform.position.x > 0){
                anim.SetInteger("SpeedX", -1);
                anim.SetInteger("SpeedY", 0);
            }
            else if (gameObject.transform.position.x - player.transform.position.x == 0){
                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", 0);
            }   
        }
        else if (valueY > valueX){
                if (gameObject.transform.position.y - player.transform.position.y < 0){
                anim.SetInteger("SpeedY", 1);
                anim.SetInteger("SpeedX", 0);
            }
            else if (gameObject.transform.position.y - player.transform.position.y > 0){
                anim.SetInteger("SpeedY", -1);
                anim.SetInteger("SpeedX", 0);
            }
            else if (gameObject.transform.position.y - player.transform.position.y == 0){
                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", 0);
            }
        }
        else if(valueX == valueY) {
                anim.SetInteger("SpeedX", 0);
                anim.SetInteger("SpeedY", 0);
        }
    }
    }

    //Patrol function usde to pick the destination.
    private void PatrolArea(){
        //patrolling = true;
        //Random within range offset that the enemy can move into.
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        LocationofPatrol = new Vector2 (offsetX, offsetY);

    }

    IEnumerator WaitToRestartPatrol(){

        yield return new WaitForSeconds(4f);
        patrolling = false;
        notmoving = false;
        yield return new WaitForSeconds(0.8f);
        done = false;   
    }
    //After NPC talk is initiated. Re-enable pathing scripts.
    IEnumerator AfterTalk(){
        yield return new WaitForSeconds(0.5f);
        AITarget.GetComponent<AIPath>().enabled = true;
        AITarget.GetComponent<Seeker>().enabled = true;
        AITarget.GetComponent<AIDestinationSetter>().enabled = true;
        AITarget.GetComponent<BoxCollider2D>().enabled = true;
        AITarget.GetComponent<AIPath>().maxSpeed = speed;
        
    }

    //Check if NPC is moving to decide which animation to display.
    IEnumerator CheckifChangingDirection(){

        yield return new WaitForSeconds(0.5f);
         anim.SetInteger("SpeedX", 0);
         anim.SetInteger("SpeedY", 0);
    }

  
}
