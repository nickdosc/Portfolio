using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Script : Photon.MonoBehaviour
{

    [SerializeField] private PhotonView photonView;
    private Material StartMaterial;

    public GameObject sword;
    private Material swordPowerup;
    private double timeLeft;
    private double timeLeftSword;
    private Color targetColor;
    private Color targetColorSword;
    


    //Player Variables
    private bool glowed;



    // Start is called before the first frame update
    public void Awake()
    {
        StartMaterial = this.GetComponent<Renderer>().material;
        swordPowerup = sword.GetComponent<Renderer>().material;

    }


   
    void Update(){
        if(photonView.isMine){
            if(Input.GetKeyDown(KeyCode.Z)){
                if(!glowed){
                glowed = true;
                }
                else
                {
                glowed = false;
                }
            } 

            if(glowed)
            {
                Glowup();
                GlowupSword();
            //photonView.RPC("Glowup", PhotonTargets.AllBuffered);
            //photonView.RPC("GlowupSword", PhotonTargets.AllBuffered);
            }
            else
            {
                GlowDown();
                GlowDownSword();
            //photonView.RPC("GlowDown", PhotonTargets.AllBuffered);
            //photonView.RPC("GlowDownSword", PhotonTargets.AllBuffered);
            }


        }//My photonview.
    }





    ///GlowUps && GlowDowns
    ////////
    [PunRPC]
     private void Glowup(){
     //   var intensity = (StartMaterial.color.r + StartMaterial.color.g + StartMaterial.color.b) / 3f;
     //   var factor = 5f / intensity;
          var factor = 8f;
       if (timeLeft <= (float)PhotonNetwork.ServerTimestamp)
        { 
  
        // transition complete
        // assign the target color
        StartMaterial.color = targetColor;
        // start a new transition
        targetColor = new Color(50f, 50f, 50f);
        targetColor = new Color(targetColor.r*factor,targetColor.g*factor, targetColor.b*factor);
        timeLeft = 2.0f;
    }
     else
        {
        // transition in progress
        // calculate interpolated color
        StartMaterial.color = Color.Lerp(StartMaterial.color, targetColor, (float)(PhotonNetwork.ServerTimestamp / timeLeft));    
        // update the timer
        timeLeft -= (float) PhotonNetwork.ServerTimestamp;
    }
    }

    [PunRPC]
    public void GlowDown(){
      
        if (timeLeft <= (float) PhotonNetwork.ServerTimestamp)
        { 
        // transition complete
        // assign the target color
        StartMaterial.color = targetColor;
         // start a new transition
        targetColor = new Color(0.01f, 0.01f, 0.01f);
        timeLeft = 2.0f;
        }
     else
        {
        // transition in progress
        // calculate interpolated color
        StartMaterial.color = Color.Lerp(StartMaterial.color, targetColor, (float)(PhotonNetwork.ServerTimestamp / timeLeft));
        // update the timer
        timeLeft -= (float)PhotonNetwork.ServerTimestamp;
    }  
    }
    [PunRPC]
    public void GlowupSword(){
      //var intensity = (swordPowerup.color.r + swordPowerup.color.g + swordPowerup.color.b) / 3f;
      // var factor = 5f / intensity;
        var factoret = 0.5f;
       if (timeLeftSword <= (float)PhotonNetwork.ServerTimestamp)
        { 
        // transition complete
        // assign the target color
        swordPowerup.color = targetColorSword;
 
         // start a new transition
        targetColorSword = new Color(50f, 50f, 50f);
        targetColorSword = new Color(targetColorSword.r*factoret,targetColorSword.g*factoret, targetColorSword.b*factoret);
        timeLeftSword = 2.0f;
    }
     else
        {
        // transition in progress
        // calculate interpolated color
        swordPowerup.color = Color.Lerp(swordPowerup.color, targetColorSword, (float)(PhotonNetwork.ServerTimestamp / timeLeftSword));
    
        // update the timer
        timeLeftSword -= (float) PhotonNetwork.ServerTimestamp;
    }
    }

    [PunRPC]
    public void GlowDownSword(){
      
        if (timeLeftSword <= (float)PhotonNetwork.ServerTimestamp)
        { 
        // transition complete
        // assign the target color
        swordPowerup.color = targetColorSword;
         // start a new transition
        targetColorSword = new Color(0.01f, 0.01f, 0.01f);
        timeLeftSword = 2.0f;
        }
     else
        {
        // transition in progress
        // calculate interpolated color
        swordPowerup.color = Color.Lerp(swordPowerup.color, targetColorSword, (float)(PhotonNetwork.ServerTimestamp / timeLeftSword));
        // update the timer
        timeLeftSword -= (float)PhotonNetwork.ServerTimestamp;
    }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //I am doing it or I am seeing it
        if(stream.isWriting){
            stream.SendNext(this.glowed);
        }
        else if (stream.isReading)
        {
            this.glowed = (bool) stream.ReceiveNext();

            

        }




    }
}
