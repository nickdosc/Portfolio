using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mages_Script : MonoBehaviour
{
    public GameObject red_ultra_gem;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WhiteGem"){
            Destroy(other.gameObject);
            anim.SetBool("Activated", true);
            StartCoroutine(OnGemTouch());
        }
    }


    IEnumerator OnGemTouch(){
       yield return  new WaitForSeconds(2f);
       Instantiate(red_ultra_gem, gameObject.transform.position, Quaternion.identity);
       Destroy(gameObject);
    }
}
