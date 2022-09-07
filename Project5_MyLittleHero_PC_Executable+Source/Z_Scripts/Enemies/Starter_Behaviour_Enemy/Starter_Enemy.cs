using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Starter_Enemy : MonoBehaviour
{
  
    public float health;
    Color origionalColor;
    Vector2 LocationofPatrol;
    public float force;
    public float speed;
    public Animator anim;
    public bool cooldownOnpatrol = false;
    public bool patrolling = false;
    bool done = false;
    public GameObject container;
    public GameObject AITarget;
    public GameObject Point;
    public GameObject boom;
    public float flashTime = 0.5f;
    Bounds bounds;
    private float valueX;
    private float valueY;
    public bool isInside;
   


    // Start is called before the first frame update
    void Start()
    {
        AITarget.GetComponent<AIPath>().maxSpeed = speed;
        //Get bounds of the patrol area, and player trigger area.
        bounds = container.GetComponent<Collider2D>().bounds;
        origionalColor = gameObject.GetComponent<SpriteRenderer>().color;


    }

    // Update is called once per frame
    void Update()
    {
        
    
        if(patrolling && AITarget.GetComponent<AIPath>().reachedEndOfPath && !done && !isInside) {
            done = true;
            StartCoroutine(WaitToRestartPatrol());
        }
       
        
        if(isInside){
            patrolling = false;
            AITarget.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").GetComponent<Transform>();
        }

        
        if(!patrolling && !isInside) {
            patrolling = true;
            PatrolArea();
            Point.transform.localPosition = new Vector3(LocationofPatrol.x, LocationofPatrol.y, 0);
            AITarget.GetComponent<AIDestinationSetter>().target = Point.transform;
        }
    
        //Despawn Check
        if (health <= 0)
        {
            Instantiate(boom, this.transform.position, Quaternion.identity);
            Destroy(container);
        }

       // CheckAnim();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon"){
            health --;
            FlashRed();
            Vector2 direction = (transform.position + other.transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force);
            
        }
        if(other.tag == "Player"){
            Vector2 direction = (transform.position + other.transform.position).normalized;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth --;
            other.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

    }


//Function to define in which axis the enemy is moving so the animator can adjust.
//################ BEFORE RELEASE OPTIMIZE ANIMATORS $VALUES$ SHOULD BE MORE ACCURETLY CALCULATED ######################
    private void CheckAnim(){

        if (!isInside){
           //Calculate a value to decide in which direction you are moving more, so the animator can pick that animation.
           //Because there is diagonal movement for NPCs but no diagonal animations. (By design choice)
        valueX = (gameObject.transform.position.x - Point.transform.position.x);
        valueY = (gameObject.transform.position.y - Point.transform.position.y);
            //Convert the values to positives so we can se which one is more affected.
        Mathf.Abs(valueX);
        Mathf.Abs(valueY);
      //  print(Point.transform.position.x);
      //  print(gameObject.transform.position.x);

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

//Enemy Patrols its area.
    private void PatrolArea(){
        //patrolling = true;
        //Random within range offset that the enemy can move into.
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        LocationofPatrol = new Vector2 (offsetX, offsetY);

    }

    public void PlayerIsOut(){
        StartCoroutine(StartPathingAgain());
    }

    void FlashRed()
    {
     gameObject.GetComponent<SpriteRenderer>().color = Color.red;
     Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = origionalColor;
          
    }

    IEnumerator WaitToRestartPatrol(){

        yield return new WaitForSeconds(4f);
        patrolling = false;
        yield return new WaitForSeconds(0.8f);
        done = false;
        
       
    }

    IEnumerator StartPathingAgain(){

        yield return new WaitForSeconds(0.8f);
        patrolling = false;
        done = false;
        
    }
    IEnumerator CheckifChangingDirection(){

        yield return new WaitForSeconds(0.5f);
         anim.SetInteger("SpeedX", 0);
         anim.SetInteger("SpeedY", 0);
    }

  
}
