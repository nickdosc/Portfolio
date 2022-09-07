using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsTip : MonoBehaviour
{
    public Text tipText;
    public Text tipHead;
    public Animator tipAnim;

     private void OnTriggerEnter2D(Collider2D other)
    {
        tipHead.text = "Skills";
        tipText.text = "Unlock skills using the K button.";
        tipAnim.GetComponent<Animator>().SetBool("IsOpen", true);
        StartCoroutine(WaitToKill());


    }

    IEnumerator WaitToKill(){
        yield return new WaitForSeconds(4f);
        tipAnim.GetComponent<Animator>().SetBool("IsOpen", false);
        Destroy(gameObject);
    }
}
