using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate_Script : MonoBehaviour
{
    public int red;
    public Text red_text;
    // Start is called before the first frame update
    void Start()
    {
        red_text.text = red.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
