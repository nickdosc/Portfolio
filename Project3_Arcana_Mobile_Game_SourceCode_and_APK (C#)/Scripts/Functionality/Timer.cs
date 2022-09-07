using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    bool activated;
    public float chronos;
    public Text timer;
    public GameObject timerUI;
    Animator anim;


    void Start()
    {
       anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if(activated){
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        timerUI.SetActive(true);
        anim.SetBool("TimerOn", true);
        chronos = chronos - Time.deltaTime;
        timer.text = ((int)chronos).ToString();
        if (chronos <= 0)
        {
            timer.text = "0";
            GameObject.Find("Player").GetComponent<Player_Script>().gameover = true;
            Time.timeScale = 0;
        }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            activated = true;
        }
        
    }
}
