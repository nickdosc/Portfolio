using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Gem : MonoBehaviour
{
    float timeLeft;
    public SpriteRenderer sprite;
    private bool once;

    bool done;
    // Start is called before the first frame update
    void Start()
    {
      once = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if(!done){
            Glowup(new Color(0.7098f,0.1372f,0.2392f,1f));
            StartCoroutine(ChangeColorTransition());
        }else{
            Glowup(Color.white);
            StartCoroutine(ChangeColorTransition2());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            if(!once){
           once = true;
           GameObject.Find("Player").GetComponent<Player_Script>().red_gems++;
           Destroy(gameObject);
            }
        }
    }


    public void Glowup(Color target){
       if (timeLeft <= Time.deltaTime)
        { 
        
        // transition complete
        // assign the target color
        //playerSprite.color = target;
        // start a new transition
        
        target = new Color(target.r,target.g, target.b);
        timeLeft = 2.0f;
    }
     else
        {
        // transition in progress
        // calculate interpolated color
        sprite.color = Color.Lerp(sprite.color, target, Time.deltaTime / timeLeft);
    
        // update the timer
        timeLeft -= Time.deltaTime;
    }
    }
    
    IEnumerator ChangeColorTransition(){
        yield return new WaitForSeconds(2f);
        done = true;
    }

    IEnumerator ChangeColorTransition2(){
        yield return new WaitForSeconds(2f);
        done = false;
    }
}
