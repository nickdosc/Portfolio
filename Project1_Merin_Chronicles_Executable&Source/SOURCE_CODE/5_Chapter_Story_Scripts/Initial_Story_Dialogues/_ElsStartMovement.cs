using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ElsStartMovement : MonoBehaviour
{
    //Movement values for the Els Gameobject
    public GameObject QuickTip;
    public bool begins = false;
    public Vector2 posA;
    public Vector2 posB;
    public Vector2 nextpos;
    Vector2 initialTransform;
    public Transform transformB;

    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Animator anim;
    public float speed;

    int counter;
    public Transform SelfTransform;
    void Start()
    {
        counter = 0;
        posA = SelfTransform.localPosition;
        initialTransform = posA;
        posB = transformB.localPosition;
        nextpos = posB;
    }

    
    void Update()
    {
        if (begins){
            ElsMove();
          //  begins = false;
        }
        if (counter == 4){
            GameObject.Find("Player").GetComponent<PlayerCharacter>().locked = false;
            QuickTip.GetComponent<Animator>().SetBool("IsOpen", false);
            Destroy(gameObject);
        }
    }

    //Move the Els gameobject as well as change the animator accordingly to the path that the object is moving.
    void ElsMove(){
        if (counter == 0){
            anim.SetBool("IsMoving", true);
            anim.SetBool("IsRight",true);
        }
         if (counter == 1){
            anim.SetBool("IsDown",true);
         //   anim.SetBool("IsRight", false);
            
        }
         if (counter == 2){
            anim.SetBool("IsRight",true);
            anim.SetBool("IsDown",false);
        }
    //Move the gameobject.
        SelfTransform.localPosition = Vector2.MoveTowards(SelfTransform.localPosition, nextpos, speed * Time.deltaTime);
        if (Vector2.Distance(SelfTransform.localPosition, nextpos) <= 0.1)
        {
            ChangeDestination();
            counter++;
        }

    }

    //Game object pathing, the game object goes through 3 key locations.
    private void ChangeDestination()
    {
        if (counter == 1){
            nextpos = location1.localPosition;
        }
        if (counter == 2){
            //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
            nextpos = location2.localPosition;
        }
        if (counter == 3){
           // gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
            nextpos = location3.localPosition;
        }
       

    }
}
