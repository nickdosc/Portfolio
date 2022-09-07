using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_Script : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
