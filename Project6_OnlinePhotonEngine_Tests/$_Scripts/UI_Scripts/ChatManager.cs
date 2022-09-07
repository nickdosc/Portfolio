using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
   public PlayerCharacter plMove;
   public PlayerCharacter_Warrior plWarr;
   public PhotonView photonView;
   public GameObject BubbleSpeechObject;
   public Text UpdatedText;
   private bool isChatFocused;

   private InputField ChatInputField;
   private bool DisableSend;

   private void Awake(){
       ChatInputField = GameObject.Find("Chat_Inputfield").GetComponent<InputField>();
   }

   private void Update(){
       if(photonView.isMine)
       {


        if(!DisableSend && ChatInputField.isFocused)
           {
             if(ChatInputField.text != "" && ChatInputField.text.Length > 0 && Input.GetKeyDown(KeyCode.Slash))
             {
                photonView.RPC("SendMessage", PhotonTargets.AllBuffered, ChatInputField.text);
                BubbleSpeechObject.SetActive(true);

                ChatInputField.text = "";
                DisableSend = true;
             }
           }

            if(Input.GetKeyDown(KeyCode.Slash) && !isChatFocused)
            {
            isChatFocused = true;
            if(plMove != null)
            plMove.locked = true;
            if(plWarr != null)
            plWarr.locked = true;

            ChatInputField.ActivateInputField();
            }
            else if(Input.GetKeyDown(KeyCode.Slash) && isChatFocused)
            {
                if(plMove != null)
                plMove.locked = false;
                if(plWarr != null)
                plWarr.locked = false;
                isChatFocused = false;
   
            ChatInputField.DeactivateInputField();
            } 

       }
   }

    [PunRPC]
    private void SendMessage(string message){
        UpdatedText.text = message;
        StartCoroutine("Remove");
    }



    IEnumerator Remove(){
        yield return new WaitForSeconds(4f);
        BubbleSpeechObject.SetActive(false);
        DisableSend = false;
    }


    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(BubbleSpeechObject.active);
        }
        else if(stream.isReading)
        {
            BubbleSpeechObject.SetActive((bool)stream.ReceiveNext());
        }

    }


}
