using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol_Enemy : MonoBehaviour
{
    public float health;

    public Vector2 posA;
    public Vector2 posB;
    public Vector2 nextpos;
    public float speed;


    public Transform enemyTransform;
    public Transform transformB;
    Vector2 initialTransform;

    public SpriteRenderer spr;
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


        if (health <= 0)
        {
            Destroy(gameObject);
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

        if (switcher)
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
            spr.flipX = false;
            switcher = false;
        }
        else
        {
            spr.flipX = true;
            switcher = true;
        }
    }
}
