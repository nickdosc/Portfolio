using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area1_Trigger : MonoBehaviour
{
    public Animator areaAnimator;
    public string AreaName;
    public Text AreaText;
    public GameObject particlesToDisable;
    public GameObject particlesToEnable;

    public GameObject enemiesToEnable;
    public GameObject enemiesToDisable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AreaText.text = AreaName;
            areaAnimator.SetBool("IsOpen", true);
            if(particlesToDisable != null || particlesToEnable !=null || enemiesToEnable != null || enemiesToDisable !=null){
                if(particlesToDisable != null || enemiesToDisable != null){
                    if (particlesToDisable != null)
                    particlesToDisable.SetActive(false);
                    if (enemiesToDisable !=null)
                    enemiesToDisable.SetActive(false);
                }
                if (particlesToEnable != null || enemiesToEnable != null){
                    if (particlesToEnable !=null)
                    particlesToEnable.SetActive(true);
                    if (enemiesToEnable != null)
                    enemiesToEnable.SetActive(true);
                }
            
         
            }
            StartCoroutine(WaitToKill(5f));
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {

       
    }

    IEnumerator WaitToKill(float time)
    {
        yield return new WaitForSeconds(time);
        areaAnimator.SetBool("IsOpen", false);
        AreaText.text = "";
    }
}
