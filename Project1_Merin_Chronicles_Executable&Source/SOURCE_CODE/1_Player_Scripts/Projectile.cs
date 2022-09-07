using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime; // Life time of the projectile.
    public float speed; // Speed of the projectile.

    public SpriteRenderer sprite; // The sprite of the projectile.


    //Directional Variables.
    bool left;
    bool right;
    bool up;
    bool down;

    //Rigid body of the Projectile
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        // During start assing the rigid body for the projectile and check in which position the player is at so it spawns accordingly.
        body = GetComponent<Rigidbody2D>();
       // body.velocity = new Vector2(speed, updown);

       //If player is facing down.
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().iamDown){
            sprite.transform.Rotate(new Vector3(0,0,90));
            down = true;
        }

        //if player is facing up
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().iamUp){
            sprite.transform.Rotate(new Vector3(0,0,-90));
            up = true;
        }
        //if player is facing left
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().iamLeft){
            left = true;   
        }

        //if player is facing right
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().iamRight){
                 sprite.transform.Rotate(new Vector3(0,0,-180));
            right = true;
        }
    }

  
    void FixedUpdate()
    {
        //Move the projectile according to the spawned direction for the specified lifetime using the functions for direction.
        if (down){
            DownProjectile();
        }
        if (up){
            UpProjectile();
        }
        if (left){
            LeftProjectile();   
        }
        if (right){
            RightProjectile();
        }
        StartCoroutine(ProjectileLife(lifetime));
        
    }

    //Move projectile upwards.
    void UpProjectile(){
        transform.Translate(Vector2.up * speed);
    }
    //Move projectile downwards.
    void DownProjectile(){
        transform.Translate(Vector2.down * speed);
    }

    //Move projectile rightward.
    void RightProjectile(){
        transform.Translate(Vector2.right * speed);
    }

    //Move projectile leftward.
    void LeftProjectile(){
        transform.Translate(Vector2.left * speed);
    }

    //Projectile life time unitl despawn.
    IEnumerator ProjectileLife(float time){

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    //If projectile enters an enemy's hitbox damage it.
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy"){
            //other.GetComponent<Basic_Enemy>().health --;
        }
    }

}
