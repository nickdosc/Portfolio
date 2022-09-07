using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    public GameObject level_complete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            level_complete.SetActive(true);
            StartCoroutine(levelfinish(0.5f));
        }
    }

    IEnumerator levelfinish(float time){
        yield return new WaitForSeconds(time);
        GameObject.Find("Player").SetActive(false);
        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}
