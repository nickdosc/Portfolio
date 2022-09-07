using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Green : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject green_spawn;
    public BoxCollider2D box;
    private bool once;
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
            if(once == false){
            once = true;
            StartCoroutine(DestroyAfterAnim());
            }
  
        }
    }

    IEnumerator DestroyAfterAnim(){
        yield return new WaitForSeconds(2f);
        Instantiate(green_spawn, gameObject.GetComponent<Transform>().localPosition, Quaternion.identity);
        Destroy(gameObject);
    }
}
