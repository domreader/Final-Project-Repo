using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunction : MonoBehaviour
{


    bool isGrounded;
    bool isWalking;
    bool isPaused = false;
    bool vendingMachineFound;
    bool vendingUsed;
    bool isAbleJump;

    float vendingCooldown = 3f;


    int gameCredit;


    GameObject player;

    [SerializeField]
    int movementSpeed;
    int doubleJumpValue;


    [SerializeField]
    int jumpPower;

    float x;
    float y;

    Rigidbody2D rb2D;
    Animator anim;

    public Collider2D[] colliders;

    BoxCollider2D onGround;
    public GameObject pauseMenu;


    



    // Floats

    float jumpCounter;
    float jumpCooldown;
    

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        player = this.gameObject;



    }

    void Update()
    {
        playerWalking();
        playerTeleport();
        playerInteractions();

        if (vendingUsed == true)
        {
            vendingMachineFound = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        

    }


    void playerWalking()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Horizontal");




        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {

            rb2D.velocity =  Vector2.right;

            GetComponent<Animator>().SetBool("isWalking", true);
            transform.rotation = Quaternion.Euler(0, 180f, 0);


        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);

        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {

            rb2D.velocity = Vector2.left;


            GetComponent<Animator>().SetBool("isWalking", true);
            transform.rotation = Quaternion.Euler(0, 0f, 0);


        }

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }




    }

    void playerInteractions()
    {

        //if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        //{
        //    Debug.Log("Pause Game");

        //    Time.timeScale = 0f;

        //    isPaused = true;

        //    pauseMenu.GetComponent<Canvas>().enabled = true;

        //}
        //else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == !false)
        //{
        //    Debug.Log("Resume Game");

        //    Time.timeScale = 1f;

        //    isPaused = false;

        //    pauseMenu.GetComponent<Canvas>().enabled = false;

        //}


        if (vendingMachineFound == true && Input.GetKey(KeyCode.E))
        {
            vendingUsed = true;

            Debug.Log("Can Dispensed " + vendingUsed);

        }
        else
        {
            vendingUsed = false;
        }

        
    }

    void playerTeleport()
    {
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Vending")
        {
            Debug.Log("Vending Machine Found");

            vendingMachineFound = true;
           
        }

  

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        vendingMachineFound = false;

    }


    private void Jump()
    {
        //if (!onGround)
        //    doubleJumpValue--;



        rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
        rb2D.AddForce(Vector2.up * jumpPower);
        //   _hangTimeCounter = 0f;
        //   _jumpBufferCounter = 0f;

        /*
        //Animation
        _anim.SetBool("isJumping", true);
        _anim.SetBool("isFalling", false);
        */

        Debug.Log("Jumping");



        }


}

