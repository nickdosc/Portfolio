using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_Merin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeTilDespawn());
    }


    IEnumerator TimeTilDespawn(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
