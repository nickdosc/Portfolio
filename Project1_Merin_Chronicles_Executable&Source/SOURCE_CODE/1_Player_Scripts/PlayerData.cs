using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int coins; //Player Current Coins.
    public int health; //Player current Health.
    public float[] position; // Player current possition in the world.
    public bool hasSkill1; //If player has unlocked the first skill.
    public string objectiveText; //Current objective text.


    //Stores the player's information in variables that will be used for saving.
    public PlayerData(PlayerCharacter player)
    {
        if(player.Mirror_Projectile){
            hasSkill1 = true;
        }
        coins = player.currency;
        health = player.maxhealth;
        objectiveText = player.objective.ToString();
        

        //Player location
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;


    }
    

    
}
