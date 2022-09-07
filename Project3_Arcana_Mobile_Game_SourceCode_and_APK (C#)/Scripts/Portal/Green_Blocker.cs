using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Blocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GreenGem"){
            Destroy(other.transform.parent.gameObject);
            GameObject.Find("Player").GetComponent<Player_Script>().returntoState = true;
            Destroy(gameObject);
        }
    }
}
