using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School_Appearance : MonoBehaviour
{
    public GameObject EnemyForces;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
           StartCoroutine(StartAnim());
        }
    }

    IEnumerator StartAnim(){
        yield return new WaitForSeconds(0.5f);
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 0;
        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, (gameObject.GetComponent<SpriteRenderer>().color = tmp), Mathf.PingPong(Time.time, 2.5f));
        EnemyForces.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
