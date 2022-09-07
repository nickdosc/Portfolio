using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public BoxCollider2D box;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //If key enters collision

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Key"){
            Destroy(box);
            Destroy(other.gameObject);
            anim.SetBool("Open", true);
            StartCoroutine(DestroyAfterAnim());
  
        }
    }

    IEnumerator DestroyAfterAnim(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
