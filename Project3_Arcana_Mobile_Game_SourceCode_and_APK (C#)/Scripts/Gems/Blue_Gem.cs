using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Gem : MonoBehaviour
{   
    private bool isDragging;
    private bool done;
    private bool empower;
    //Bool to check if you have clicked on blue gem
    private bool haveTapped;
    float timeLeft;
    public SpriteRenderer sprite;
    void Start()
    {
        
    }
    public void OnMouseDown() {
        isDragging = true;
        empower = true;
        
        
    }

    public void OnMouseUp() {
        isDragging = false;
        empower = false;
      
    }


    // Update is called once per frame
    void Update()
    {
        if(isDragging){
       Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       transform.Translate(mousePosition); 
       
        }

        if(!done){
            GlowupGem(new Color(0,0.8948f,1f,1f));
            StartCoroutine(ChangeColorTransition());
        }else{
            GlowupGem(Color.white);
            StartCoroutine(ChangeColorTransition2());
        }

        if(empower){
            GameObject.Find("Player").GetComponent<Player_Script>().Glowup(Color.blue);;
            haveTapped = true;
        }else if(!empower && haveTapped){
            GameObject.Find("Player").GetComponent<Player_Script>().Glowup(Color.white);
        }
    }

    public void GlowupGem(Color target){
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
