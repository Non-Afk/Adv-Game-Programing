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
        if(player != null)
        {
            if (transform.position != player.position)
            {
                Vector3 playerPos = player.position;
                transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
            }
        }
    }

    private void Update()
    {
        
    }
}

