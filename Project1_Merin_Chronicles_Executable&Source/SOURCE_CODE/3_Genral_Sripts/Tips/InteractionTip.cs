using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTip : MonoBehaviour
{
    public Text tipText;
    public Text tipHead;
    public Animator tipAnim;
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
        tipHead.text = "Interaction";
        tipText.text = "Interact with the villagers using E.";
        tipAnim.GetComponent<Animator>().SetBool("IsOpen", true);
        StartCoroutine(WaitToKill());
        }

    }

    IEnumerator WaitToKill(){
        yield return new WaitForSeconds(4f);
        tipAnim.GetComponent<Animator>().SetBool("IsOpen", false);
        Destroy(gameObject);
    }
}
