using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Event : MonoBehaviour
{

    public GameObject EventToTrigger; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            EventToTrigger.SetActive(true);
            Destroy(gameObject);
        }
    }
}
