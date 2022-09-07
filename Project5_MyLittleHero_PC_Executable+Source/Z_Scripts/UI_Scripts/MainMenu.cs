using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BayatGames.SaveGameFree;
public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public Text objectiveText;
    public Text FPS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FPS.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();

    }

    public class PlayerData
    {
        public Vector2 playertransform;
        public int health;
        public int currency;
        public string ObjectiveText;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<PlayerCharacter>().enabled = true;
        anim.SetBool("IsOpen", false);
        
    }

    public void Save()
    {
        PlayerData data = new PlayerData();
        data.playertransform = GameObject.Find("Player").transform.localPosition;
        data.health = GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth;
        data.ObjectiveText = objectiveText.text;
        data.currency = GameObject.Find("Player").GetComponent<PlayerCharacter>().currency;
        SaveGame.Save<PlayerData>("playerData", data);
        print("Saved!");
        print(data.playertransform);
        print(data.health);
        print(data.ObjectiveText);
    }

    public void Load()
    {
        PlayerData savedData = SaveGame.Load<PlayerData>("playerData");
        Vector2 newplayertransform = savedData.playertransform;
        int newhealth = savedData.health;
        string newObjectiveText = savedData.ObjectiveText;
        int newCurrency = savedData.currency;


        GameObject.Find("Player").transform.localPosition = newplayertransform;
        GameObject.Find("Player").GetComponent<PlayerCharacter>().maxhealth = newhealth;
        objectiveText.text = newObjectiveText;
        GameObject.Find("Player").GetComponent<PlayerCharacter>().currency = newCurrency;
        print("Loaded!");
        //Transform newplayertransform = SaveGame.Load<Transform>("playertransform");
        // int newhealth = SaveGame.Load<int>("health");
        //Text newObjectiveText = SaveGame.Load<Text>("ObjectiveText");



    }


    public void Quit()
    {
        Application.Quit();
    }


}
