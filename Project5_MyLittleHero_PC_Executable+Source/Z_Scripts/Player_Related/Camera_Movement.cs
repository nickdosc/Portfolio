using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] public Transform player;
    Vector3 offset;

    [SerializeField] public float camSpeed;

    // Start is called before the first frame update
    void Start()
    {

        offset = player.position - transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, player.position - offset, Time.deltaTime * camSpeed);
        
    }
}
