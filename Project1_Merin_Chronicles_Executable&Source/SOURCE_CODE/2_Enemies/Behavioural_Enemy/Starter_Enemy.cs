using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Starter_Enemy : MonoBehaviour
{
  
    public float health; // The health of the enemy
    Color origionalColor; // The original color of the enemy
    Vector2 LocationofPatrol; // The partol range of the enemy.
    public int force; // The force the enemy will apply to the player if a hit is registered.
    public float speed; // The speed of the enemy.
    public Animator anim; // The animator of the enemy.
    public bool cooldownOnpatrol = false; // The cooldown used for the patrolling of the enemy
    public bool patrolling = false; //  Flag to check if enemy is patrolling enemy.
    bool done = false; // Is the patrol done?
    public GameObject container; // The container is the gameobject of the patrol range.
    public GameObject AITarget; // The AI target is the target picked by the enemy to move into.
    public GameObject Point; // The point is an empty gameobject that is created so that the enemy can route towards.
    public GameObject boom; // The boom is an effect used when the enemy is destroyed.
    public float flashTime = 0.5f; // The flash time is the time the color changes when the enemy is hit.
    Bounds bounds; // The bounds of the patrolling area, will be used as bounds to spawn point.

    // The Xvalue and Yvalue are explained later in the script.
    private float valueX; 
    private float valueY;

    public bool isInside; // Is the player inside?
   


    // Start is called before the first frame update
    void Start()
    {
        //Assign max speed to the enemy and set the bounds and the original color.
        AITarget.GetComponent<AIPath>().maxSpeed = speed;
        //Get bounds of the patrol area, and player trigger area.
        bounds = container.GetComponent<Collider2D>().bounds;
        origionalColor = gameObject.GetComponent<SpriteRenderer>().color;


    }

    // Update is called once per frame
    void Update()
    {
        
        // While patrolling check if the enemy has reached the end of the path.
        if(patrolling && AITarget.GetComponent<AIPath>().reachedEndOfPath && !done && !isInside) {
            done = true;
            StartCoroutine(WaitToRestartPatrol());
        }
       
        // Check if the player is inside the range of the enemy.
        if(isInside){
            patrolling = false;
            AITarget.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").GetComponent<Transform>();
        }

        //If the enemy is not patrolling and the player is not inside.
        //Start patroling again by picking a new point and spawning the game object "Point" so that the enemy can route towards it.
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

        //Animator Checks
        CheckAnim();
    }

    /*
    If a projectile hits the enemy then reduce its life by 1.
    If the enemy touches the player apply force and reduce the current health value of the player by 1.
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectile"){
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
    private void CheckAnim(){

        if (!isInside){
           //Calculate a value to decide in which direction you are moving more, so the animator can pick that animation.
           //Because there is diagonal movement for NPCs but no diagonal animations. (By design choice)
        valueX = (gameObject.transform.position.x - Point.transform.position.x);
        valueY = (gameObject.transform.position.y - Point.transform.position.y);
            //Convert the values to positives so we can se which one is more affected.
        Mathf.Abs(valueX);
        Mathf.Abs(valueY);

        //Assign to which direction the enemy will be animated.
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
    //The player leaves the range of the enemy.
    public void PlayerIsOut(){
        StartCoroutine(StartPathingAgain());
    }


    //Flash red on the sprite of the enemy
    void FlashRed()
    {
     gameObject.GetComponent<SpriteRenderer>().color = Color.red;
     Invoke("ResetColor", flashTime);
    }

    //Revert the color to the original one of the enemy.
    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = origionalColor;
          
    }

    //Restart patrol if enemy has reached the patrol goal.
    IEnumerator WaitToRestartPatrol(){

        yield return new WaitForSeconds(4f);
        patrolling = false;
        yield return new WaitForSeconds(0.8f);
        done = false;
        
       
    }
    //Start pathing again if the player has been chased and left the range.
    IEnumerator StartPathingAgain(){

        yield return new WaitForSeconds(0.8f);
        patrolling = false;
        done = false;
        
    }
    //Check if changing direction or idle so that the animator can adjust.
    IEnumerator CheckifChangingDirection(){

        yield return new WaitForSeconds(0.5f);
         anim.SetInteger("SpeedX", 0);
         anim.SetInteger("SpeedY", 0);
    }

  
}
