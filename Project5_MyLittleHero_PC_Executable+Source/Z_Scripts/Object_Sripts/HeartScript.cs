using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<PlayerCharacter>().hearts == 3) {
                if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth < 3)
                {
                    if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth == 2)
                    {
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heart1.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heartempty1.SetActive(false);

                    }
                    else if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth == 1)
                    {

                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heart2.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heartempty2.SetActive(false);
                    }


                    GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth = GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth + 1;
                    Destroy(gameObject);
                }
            }
            if (GameObject.Find("Player").GetComponent<PlayerCharacter>().hearts == 4)
            {
                if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth < 4)
                {
                    if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth == 3)
                    {
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heart4.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heartempty4.SetActive(false);

                    }

                    if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth == 2)
                    {
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heart1.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heartempty1.SetActive(false);

                    }
                    else if (GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth == 1)
                    {

                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heart2.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerCharacter>().heartempty2.SetActive(false);
                    }


                    GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth = GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth + 1;
                    Destroy(gameObject);
                }
            }



        }
    }

}
