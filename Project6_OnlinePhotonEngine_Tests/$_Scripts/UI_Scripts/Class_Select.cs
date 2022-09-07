using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Class_Select : MonoBehaviour
{

    [SerializeField] private GameObject WarriorIMG;
    [SerializeField] private GameObject WizzardIMG;

    int classPage;
    public int selection;


    // Start is called before the first frame update
    void Start()
    {
        classPage = 0;
        selection = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }


    public void nextArrow(){
        if (classPage >= 0 && classPage <1)
            classPage++;
        if(classPage == 0){
            WizzardIMG.SetActive(false);
            WarriorIMG.SetActive(true); 
            selection = 1; //Warrior
        }
        if(classPage == 1){
            WarriorIMG.SetActive(false); 
            WizzardIMG.SetActive(true);
            selection = 2; //Wizzard
        }       
    }

    public void backArrow(){
        if (classPage > 0 && classPage <=1)
            classPage--;
        if(classPage == 0){
            WizzardIMG.SetActive(false);
            WarriorIMG.SetActive(true); 
            selection = 1; //Warrior
        }
        if(classPage == 1){
            WarriorIMG.SetActive(false); 
            WizzardIMG.SetActive(true);
            selection = 2; //Wizzard
        }

    }
    
}
