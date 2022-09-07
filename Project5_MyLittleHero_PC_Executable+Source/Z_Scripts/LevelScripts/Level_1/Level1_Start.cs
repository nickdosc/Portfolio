using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1_Start : MonoBehaviour
{
    public Text ObjectiveText;
    public Animator TipAnim;
    public Text TipText;

    // Start is called before the first frame update
    void Start()
    {
        ObjectiveText.text = "Learn more about your location.";
        TipAnim.SetBool("IsOpen", true);
        TipText.text = "Scattered across the land are Yorls, gather them to buy Skills by pressing the R button!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
