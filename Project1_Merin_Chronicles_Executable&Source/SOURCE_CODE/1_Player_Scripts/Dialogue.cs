using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name; // Name of the talking character

    [TextArea(3,10)]    
    public string[] sentences; //Used to display the sentences in order.
}
