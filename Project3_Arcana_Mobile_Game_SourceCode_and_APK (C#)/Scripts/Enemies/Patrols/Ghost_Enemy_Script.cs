using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost_Enemy_Script : MonoBehaviour
{

    public Vector2 posA;
    public Vector2 posB;
    public Vector2 nextpos;
    public float speed;

    
    public Transform enemyTransform;
    public Transform transformB;
    Vector2 initialTransform;

    //public SpriteRenderer spr;
    bool switcher;
    // Start is called before the first frame update
    void Start()
    {
       
        posA = enemyTransform.localPosition;
        initialTransform = posA;
        posB = transformB.localPosition;
        nextpos = posB;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Player_Script>().gameover = true;
            Time.timeScale = 0;
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.tag == "GreenGem"){
            Destroy(other.transform.parent.gameObject);
            FindObjectOfType<Player_Script>().gameover = true;
            Time.timeScale = 0;
        }

    }
    private void Move()
    {
        enemyTransform.localPosition = Vector2.MoveTowards(enemyTransform.localPosition, nextpos, speed * Time.deltaTime);
        if (Vector2.Distance(enemyTransform.localPosition, nextpos) <= 0.1)
        {
            ChangeDestination();
        }


    }
    private void ChangeDestination()
    {
        Flip();

        if(switcher)
        nextpos = initialTransform;
        else
        nextpos = posB;
        //initialTransform = enemyTransform.localPosition;
        //initialTransform = posB;
        //Move();

    }

    void Flip()
    {
        if (switcher)
        {
            if (gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0,-180,0))
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,0);
            else
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,-180,0);
           // spr.flipX = false;
            switcher = false;
        }
        else
        {
          //  spr.flipX = true;
            if (gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0,-180,0))
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,0);
            else
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,-180,0);
            switcher = true;
        }
    }
}
