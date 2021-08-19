using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunction : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    bool isWalking;
    bool isPaused = false;
    bool vendingMachineFound;
    bool vendingUsed;
    bool isAbleJump;

    bool jumpEnabled;

    float vendingCooldown = 3f;
    float movementAdjustment = 1f;

    int gameCredit;
    int jumpValue = 0;

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

    public BoxCollider2D grounded;
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


        spriteRenderer = GetComponent<SpriteRenderer>();

    }

     void Update()
    {
        playerWalking();

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            jumpEnabled = true;
            Jump();
        }

        if (jumpValue == 1)
        {
            isGrounded = false;
        }
        

    }

    void FixedUpdate()
    {


        playerTeleport();
        playerInteractions();

       

        if (vendingUsed == true)
        {
            vendingMachineFound = false;
        }
    }

    void playerWalking()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);


        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0, 360, 0);
            spriteRenderer.flipX = true;


            GetComponent<Animator>().SetBool("isWalking", true);

        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);

        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {

            GetComponent<Animator>().SetBool("isWalking", true);

            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
            spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * (int)movementAdjustment;
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

        if (collision.tag == "floor")
        {
            isGrounded = true;
            Debug.Log("collision floor");
            jumpValue = 0;

        }
        else if(collision.tag != "floor")
        {
            isGrounded = false;
        }


        if (collision.name == "Enemy")
        {
            Debug.Log("Enemy Detected");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        vendingMachineFound = false;

        if (collision.tag == "floor")
        {
            jumpEnabled = false;
        }


    }


    private void Jump()
    {
        //if (!onGround)
        //    doubleJumpValue--;

        if (jumpEnabled == true)
        {
            rb2D.AddForce((Vector2.up * jumpPower) * 5);

            jumpValue += 1;

        }



        //   _hangTimeCounter = 0f;
        //   _jumpBufferCounter = 0f;

        /*
        //Animation
        _anim.SetBool("isJumping", true);
        _anim.SetBool("isFalling", false);
        */

        Debug.Log("Jumping");



        }

    void groundCollisionCheck()
    {

    }


}

