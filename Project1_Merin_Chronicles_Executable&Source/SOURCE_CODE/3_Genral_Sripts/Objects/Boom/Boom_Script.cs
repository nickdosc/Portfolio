using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_Script : MonoBehaviour
{
    //An effect played when an enemy despawns.
    public float lifetime;
  
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Despawn(lifetime));
    }

      IEnumerator Despawn(float time){

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
