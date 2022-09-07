using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Back_From_The_Mirror : MonoBehaviour
{

    // Script that changes objective text at a certain story point.
    public Text objectiveText;
    public Light2D globalLight;
    public GameObject playerLight;
    // Start is called before the first frame update
  
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            objectiveText.text = "Find Els!";
            globalLight.intensity = 1f;
            playerLight.SetActive(false);
            Destroy(gameObject);   
        }
    }
}
