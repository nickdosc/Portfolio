using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcLeader : MonoBehaviour
{
    public float health;

    public Vector2 posA;
    public Vector2 posB;
    public Vector2 nextpos;
    public float speed;
    public Transform enemyTransform;
    public Animator anim;

    Vector2 initialTransform;



    bool isInside;
    bool hasMoved;


    // Start is called before the first frame update
    void Start()
    {

        posA = enemyTransform.localPosition;
        initialTransform = posA;
        posB = GameObject.Find("Player").transform.localPosition;
        nextpos = posB;

    }

    // Update is called once per frame
    void Update()
    {
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
        if (Vector2.Distance(enemyTransform.localPosition, nextpos) <= 0.1 && nextpos == initialTransform && isInside == false)
        {
            // GoBackToPoint();
            anim.enabled = false;
            hasMoved = false;

        }

        if (health <= 0)
        {
            GameObject.Find("Amantha").GetComponent<AmanthaScript>().orcleader = true;
            Destroy(gameObject);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nextpos = posB;
            anim.enabled = true;
            isInside = true;
            hasMoved = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = false;
        }
    }


    private void Move()
    {
        enemyTransform.localPosition = Vector2.MoveTowards(enemyTransform.localPosition, nextpos, speed * Time.deltaTime);
        if (Vector2.Distance(enemyTransform.localPosition, nextpos) <= 0.1 && nextpos == initialTransform)
        {
            isInside = false;

        }
    }
    private void GoBackToPoint()
    {


        nextpos = initialTransform;
        //initialTransform = enemyTransform.localPosition;
        //initialTransform = posB;
        //Move();

    }


}

