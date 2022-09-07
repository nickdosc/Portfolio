using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Tip : MonoBehaviour
{
    public Text tipText;
    public Text tipHead;
    public Animator tipAnim;
    // A tip displayed to the player when first encountering coins in the game.
    
     private void OnTriggerEnter2D(Collider2D other)
    {
        tipHead.text = "Coins";
        tipText.text = "Scattered across the land are Coins, make sure to gather them.";
        tipAnim.GetComponent<Animator>().SetBool("IsOpen", true);
        StartCoroutine(WaitToKill());


    }

    IEnumerator WaitToKill(){
        yield return new WaitForSeconds(4f);
        tipAnim.GetComponent<Animator>().SetBool("IsOpen", false);
        Destroy(gameObject);
    }
}
