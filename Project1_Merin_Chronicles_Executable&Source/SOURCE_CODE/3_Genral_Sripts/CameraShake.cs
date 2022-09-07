using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{  
    /*
    Scipt that shakes the camera when the player uses the projectile skill.
    */

    //Camera variables creation
  public static CameraShake Instance {get; private set;}
  private CinemachineVirtualCamera  cinemachineVirtualCamera;
  private float shakeTimer;
  private float startingIntensity;
  private float shakeTimerTotal;

  // On awake give the cinemachine camera to the virtual camera
  private void Awake()
  {
      Instance = this;
      cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
  }

    //Apply the shake to the camera with the intensity selected for the time period selected.
  public void ShakeCamera(float intensity, float time){
      CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
      cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

      cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
      startingIntensity = intensity;
      shakeTimerTotal = time;
      shakeTimer = time;
  }
    //During update substract from the remaining shake timer and check if the shake is completed else keep shaking.
    private void Update(){
        if (shakeTimer >0) {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f){
                //Timer Over!!
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                Mathf.Lerp(startingIntensity, 0f, 1-(shakeTimer/shakeTimerTotal));
            }
        }
    }
}
