using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips_Help : MonoBehaviour
{
    public Text TipText;
    public Animator TipAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void buttonOK()
    {
        TipAnim.SetBool("IsOpen", false);
    }
}

