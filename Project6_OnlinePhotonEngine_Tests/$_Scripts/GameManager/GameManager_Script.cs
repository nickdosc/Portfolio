using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Script : MonoBehaviour
{
    public GameObject WarrPrefab;
    public GameObject WizzPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public GameObject SceneVcam;
    public Text PingText;


    private void Awake()
    {
        GameCanvas.SetActive(true);
    }


    public void update(){
        PingText.text = PhotonNetwork.GetPing().ToString();
    }


    [PunRPC]
    public void SpawnPlayer(){
        int tempSelect = GameObject.Find("Class_Select_UI").GetComponent<Class_Select>().selection;


        if(tempSelect == 1) {
            float randomValue = Random.Range(-1f,1f);

            PhotonNetwork.Instantiate(WarrPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
            GameCanvas.SetActive(false);
            SceneCamera.SetActive(false);
            SceneVcam.SetActive(false);
        }
        if(tempSelect == 2) {
            float randomValue = Random.Range(-1f,1f);

            PhotonNetwork.Instantiate(WizzPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
            GameCanvas.SetActive(false);
            SceneCamera.SetActive(false);
            SceneVcam.SetActive(false);
        }
    




    }



}
