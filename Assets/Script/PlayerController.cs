using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public int rotation = 1;
    public Animator animator;
    private void Start()
    {
        
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A) && rotation > 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            rotation = -1;
        }
        if (Input.GetKeyDown(KeyCode.D) && rotation < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            rotation = 1;
        }

        if (Input.GetKey(KeyCode.J))
        {
            animator.SetFloat("Player_speed", 0);
            animator.SetBool("Fight", true);

        }
        else
        {
            animator.SetBool("Fight", false);
            transform.position += new Vector3(movement, 0, 0);// * Time.deltaTime * MovementSpeed;
            animator.SetFloat("Player_speed", Mathf.Abs(movement));

        }
    }
}
