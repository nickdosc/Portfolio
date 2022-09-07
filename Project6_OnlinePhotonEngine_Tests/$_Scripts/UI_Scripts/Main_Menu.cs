using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";


    //User Inputs
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    //UI Elements
    [SerializeField] private GameObject ConnectToServer_Button;
    [SerializeField] private Text ConnectionStatus;


    public Animator Main_Menu_Anim;


    private void Awake() {
        PhotonNetwork.ConnectUsingSettings(VersionName);

    }


    private void Start()
    {
        
    }

    private void Update()
    {
        ChangeUserNameInput();
    }

    //Display Connection Status to Photon Network
    private void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
        ConnectionStatus.text = "Connected";
    }



    //When player Hits play

    public void Play(){
        Main_Menu_Anim.SetBool("play", true);


    }

    //When player joins/creates server 
    public void JoinToUser(){
        SetUsername();
        Main_Menu_Anim.SetBool("join", true);
    }


    //Make sure Usernanme is >2 characters
    public void ChangeUserNameInput(){
        if(UsernameInput.text.Length >= 2){
            ConnectToServer_Button.SetActive(true);
        }
        else{
            ConnectToServer_Button.SetActive(false);
        }
    }

    //Set the Username of the connecting player
    public void SetUsername(){
        PhotonNetwork.playerName = UsernameInput.text;
    }

    /*
    //User Creates Server
    public void CreateGame(){
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() {MaxPlayers = 5}, null);

    }*/

    //User Joins Server:
    public void JoinIris(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom("Iris", roomOptions, TypedLobby.Default);
    }

    public void JoinJox(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom("Jox", roomOptions, TypedLobby.Default);
    }    

    public void JoinMechaterk(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom("Mechaterk", roomOptions, TypedLobby.Default);
    }   
    //User joins room
    private void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("_Overworld");
    }
}
