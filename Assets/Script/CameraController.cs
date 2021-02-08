using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothing;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        //check player if alive
        if(player != null)
        {
            //check camera position and player position if they are not same
            if (transform.position != player.position)
            {
                //move camera to the player
                Vector3 playerPos = player.position;
                transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
            }
        }
    }

    private void Update()
    {
        
    }
}

