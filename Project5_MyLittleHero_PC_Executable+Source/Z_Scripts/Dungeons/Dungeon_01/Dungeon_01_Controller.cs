using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_01_Controller : MonoBehaviour
{
    public int satchels;

    public GameObject gateway;
    public GameObject exitGateway;
    public GameObject treasureHeart;

    public bool bossdead;

    public int counter;
 
    // Start is called before the first frame update
    void Start()
    {
        satchels = 0;
        counter = 0;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 4)
        {
            gateway.SetActive(true);
        }
      
       if (bossdead)
        {
            exitGateway.SetActive(true);
            treasureHeart.SetActive(true);
        }

    }
}
