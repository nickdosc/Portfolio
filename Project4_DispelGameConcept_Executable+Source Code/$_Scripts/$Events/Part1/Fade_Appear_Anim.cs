using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Appear_Anim : MonoBehaviour
{
    public SpriteRenderer sp1;
    public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         changeColor();
    }

    public void changeColor(){
        Color tmp = sp1.color;
        tmp.a = alpha;
        sp1.GetComponent<SpriteRenderer>().color = tmp;
       
    }
}
