using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills_Script_UI : MonoBehaviour
{
    //Activated TextSkill
    public GameObject activated_skill_01;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skill_01()
    {
        if (GameObject.Find("Player").GetComponent<PlayerCharacter>().currency >= 15 && !GameObject.Find("Player").GetComponent<PlayerCharacter>().Skill_01)
        {
            GameObject.Find("Player").GetComponent<PlayerCharacter>().currency = GameObject.Find("Player").GetComponent<PlayerCharacter>().currency - 15;
            GameObject.Find("Player").GetComponent<PlayerCharacter>().Skill_01 = true;
            activated_skill_01.SetActive(true);
        }
        else
        {
            //Play an error sound
            return;
        }
       
    }
}
