using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 60;
    public int rotation = 1;
    public Animator animator;
    AnimatorStateInfo animatorInfo;

    public int health = 3;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject deathPanel;

    private void Start()
    {
        
    }

    private void Update()
    {
        animator.SetFloat("Health", health);
        checkRunning();
        checkDirection();
        checkFight();
        checkHealth();
    }

    void checkRunning()
    {
        //player running in the game by LeftShift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MovementSpeed = 120;
            animator.SetBool("Run", true);
        }
        else
        {
            MovementSpeed = 60;
            animator.SetBool("Run", false);
        }
    }

    void checkDirection()
    {
        //Press A to face left
        if (Input.GetKeyDown(KeyCode.A) && rotation > 0 && health > 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            rotation = -1;
        }
        //Press D to face right
        if (Input.GetKeyDown(KeyCode.D) && rotation < 0 && health > 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            rotation = 1;
        }
    }

    void checkFight()
    {
        var movement = Input.GetAxis("Horizontal");
        //Player fightting with enemy
        if (Input.GetKey(KeyCode.J))
        {
            animator.SetFloat("Player_speed", 0);
            animator.SetBool("Fight", true);

        }
        //Player move left and right when health is greater than 3
        else if(health > 0)
        {
            animator.SetBool("Fight", false);
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
            animator.SetFloat("Player_speed", Mathf.Abs(movement));
        }
    }

    void checkHealth()
    {
        //Health visualization
        if (health == 3)//3 heart
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (health == 2)//2 heart
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (health == 1)//1 heart
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        //Death
        else if (health <= 0 && animatorInfo.normalizedTime >= 1.0f && animatorInfo.IsName("Player_death"))
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            deathPanel.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            transform.position += new Vector3(-10, 0, 0) * Time.deltaTime * MovementSpeed;


        }
    }

    /*public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Invoke("Damage delay", 2);
            health -= 1;
        }
    }*/
}
