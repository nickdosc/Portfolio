using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy : MonoBehaviour
{
    public float health; // Health of the enemy character.

    //Position Vectors for movement of the enemy character.
    public Vector2 posA; 
    public Vector2 posB;

    //Which will be the next position of the enemy character.
    public Vector2 nextpos;
    //The speed of the Enemy Character.
    public float speed;

    //Boom is the effect that is played when an enemy is destroyed.
    public GameObject boom;

    // The world transform of the enemy.
    public Transform enemyTransform;
    //public Animator anim;
   
   // The initial transform of the enemy, as in the one it spawned.
    Vector2 initialTransform;

    
    // If the player is inside, this is used for chasing mechanics.
    bool isInside;
    // If the enemy has moved, this is used for retracing steps.
    bool hasMoved;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get the initial values of the current possition and the next position that the enemy should head to.
        posA = enemyTransform.localPosition;
        initialTransform = posA;
        posB = GameObject.Find("Player").transform.localPosition;
        nextpos = posB;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Check if player is inside the range of the enemy, if so change the next position to chase the player charater.
        */
        posB = GameObject.Find("Player").transform.localPosition;
        if (isInside)
        {
            Move();
            nextpos = posB;
        }
        if (isInside == false && hasMoved)
        {
            GoBackToPoint();
            Move();
        }


        //This check is here to confirm that the enemy has successfully retraced back after the player has exited its range.
        if (Vector2.Distance(enemyTransform.localPosition, nextpos) <= 0.1 && nextpos == initialTransform && isInside == false)
        {
            hasMoved = false;
        }
        //If enemy has no health left, destroy it.
        if (health <= 0)
        {
            Instantiate(boom, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //Trigger check for player.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nextpos = posB;
           // anim.enabled = true;
            isInside = true;
            hasMoved = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       

    }
    //If player exits, retrace steps.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = false;
        }
    }
   
    //The function that moves the enemy.
    private void Move()
    {
        enemyTransform.localPosition = Vector2.MoveTowards(enemyTransform.localPosition, nextpos, speed * Time.deltaTime);
        if (Vector2.Distance(enemyTransform.localPosition, nextpos) <= 0.1 && nextpos == initialTransform)
        {
            isInside = false;
           
        }
    }

    //The retracing function.
    private void GoBackToPoint()
    {


        nextpos = initialTransform;
        //initialTransform = enemyTransform.localPosition;
        //initialTransform = posB;
        //Move();
        
    }

}
