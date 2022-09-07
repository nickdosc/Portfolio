using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Script : MonoBehaviour
{
    // The script handling the light's animations in the city.
    
    public Light2D lamp;
    bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!complete){
            complete = true;
            lamp.pointLightOuterRadius = Random.Range(1f, 2.5f);
            StartAgain();
        }
        
    }

    IEnumerator StartAgain(){

        yield return new WaitForSeconds(1f);
        complete = false;
    }
}
