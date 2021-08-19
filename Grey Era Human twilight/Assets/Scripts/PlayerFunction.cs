using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFunction : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    bool inventoryEnabled;
    bool isGrounded;
    bool isWalking;
    bool isPaused;
    bool vendingMachineFound;
    bool vendingUsed;
    bool isAbleJump;

    bool firstCollider;
    bool secondCollider;
    bool thirdCollider;

    GameObject currentCollision;
    bool inCollider;

    public Canvas textCanvas;
    public Canvas textCanvas1;
    public Canvas textCanvas2;
    public Canvas loadingScreen;
    public Canvas inventoryCanvas;

    public Text text;
    public Text text1;
    public Text text2;

    bool jumpEnabled;
    bool loadingTimerEnabled;

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

    public Canvas pauseGame;

    public Collider2D[] colliders;

    public BoxCollider2D grounded;
    BoxCollider2D onGround;
    public GameObject pauseMenu;

    public GameObject interactE1;
    public GameObject interactE2;

    public GameObject collider1;
    public GameObject collider2;
    public GameObject collider3;

    public Button inventoryOpenButton;

    // Floats

    float jumpCounter;
    float jumpCooldown;
    float loadingTimer;
    

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        player = this.gameObject;

        currentCollision = null;

        spriteRenderer = GetComponent<SpriteRenderer>();

        inventoryOpenButton.onClick.AddListener(inventory);

    }

    void Update()
    {

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            jumpEnabled = true;
            Jump();
            GetComponent<Animator>().SetBool("isJumping", true);
            isAbleJump = true;
        }

        if (jumpValue == 1)
        {
            isGrounded = false;
            
        }

        playerInteractions();
        timer();
        inventory();


    }

    void FixedUpdate()
    {


        playerTeleport();
        playerWalking();

        textInteractions();


        if (vendingUsed == true)
        {
            vendingMachineFound = false;
        }

        if (isGrounded == false)
        {
            isAbleJump = true;
        }

        if (isAbleJump == true)
        {
            GetComponent<Animator>().SetBool("isJumping", false);

        }
    }

    void playerWalking()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);


        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(moveDirection * movementSpeed * Time.fixedDeltaTime);

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

            spriteRenderer.flipX = false;

            transform.Translate(moveDirection * movementSpeed * Time.fixedDeltaTime);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * 2;
        }

       

    }

    void playerInteractions()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Debug.Log("Pause Game");

            Time.timeScale = 0f;

            isPaused = true;

            pauseGame.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == !false)
        {
            Debug.Log("Resume Game");

            Time.timeScale = 1f;

            isPaused = false;

            pauseGame.enabled = false;
        }


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
        if (inCollider == true) // In collider
        {

            interactE1.SetActive(true);
            interactE2.SetActive(true);

            Debug.Log(currentCollision.name.ToString());

            if (currentCollision.name == "ToBathroom" & Input.GetKey(KeyCode.E))
            {
                loadingTimerEnabled = true;

                transform.position = new Vector3(-39.43f, -49.09f);
                Debug.Log("in collider");
            }


            if (currentCollision.name == "ToMainStreet" & Input.GetKey(KeyCode.E))
            {
                loadingTimerEnabled = true;

                transform.position = new Vector3(21.17f, -0.14f);
                Debug.Log("in collider");
            }

            if (currentCollision.name == "ToGarbage" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(80.04f, 33.41f);

            }

            if (currentCollision.name == "FromGarbage" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(70.28f, -23.68f);

            }

            if (currentCollision.name == "ToScene1" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(-97.73f, 27.08f);

            }

            if (currentCollision.name == "FromScene1" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(-12.02f, 19.99f);

            }

            if (currentCollision.name == "ToScene2" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(82.95f, 43.9f);

            }

            if (currentCollision.name == "FromScene2" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(7.6f, 19.95f);

            }

            if (currentCollision.name == "ToScene3" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(4.04f, 49.57f);

            }

            if (currentCollision.name == "FromScene3" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(81.1f, 61.33f);

            }
            if (currentCollision.name == "ToScene4" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(4.04f, 49.57f);

            }

            if (currentCollision.name == "FromScene4" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(81.1f, 61.33f);

            }
            if (currentCollision.name == "ToScene5" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(4.04f, 49.57f);

            }

            if (currentCollision.name == "FromScene5" & Input.GetKeyDown(KeyCode.E))
            {
                transform.position = new Vector3(81.1f, 61.33f);

            }
        }
        else if(inCollider == false)
        {
            interactE1.SetActive(false);
            interactE2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Vending")
        {
            Debug.Log("Vending Machine Found");

            vendingMachineFound = true;
            isGrounded = true;
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

        if (collision.tag == "firstCollider")
        {
            Debug.Log("collision confirmed");

            firstCollider = true;
        }

        if (collision.tag == "secondCollider")
        {
            Debug.Log("collision confirmed");

            secondCollider = true;
        }


        if (collision.tag == "thirdCollider")
        {
            Debug.Log("collision confirmed");

            thirdCollider = true;
        }

        if (collision.tag == "Teleport")
        {

            currentCollision = collision.gameObject;
            Debug.Log(currentCollision);

            inCollider = true;


        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
        vendingMachineFound = false;
        firstCollider = false;
        secondCollider = false;
        thirdCollider = false;

        if (collision.tag == "floor")
        {
            jumpEnabled = false;

        }

        if (collision.tag == "firstCollider")
        {
            isGrounded = true;
            firstCollider = false;
            Destroy(collider1);
        }

        if (collision.tag == "secondCollider")
        {
            isGrounded = true;
            secondCollider = false;
            Destroy(collider2);
        }

        if (collision.tag == "thirdCollider")
        {
            isGrounded = true;
            thirdCollider = false;
            Destroy(collider3);

        }


    }

    void textInteractions()
    {

        if (firstCollider == true)
        {
            textCanvas.enabled = true;
            text.text = "Another day… here we go, I should probably get up and move around. Press A or D to move!";

            
        }
        else
        {
            textCanvas.enabled = false;
            text.text = null;
        }

        if (secondCollider == true)
        {
            textCanvas1.enabled = true;
            text1.text = " Eugh I didnt want to be this active this morning … gotta get going though (Press Spacebar to jump)";


        }
        else
        {
            textCanvas1.enabled = false;
            text1.text = null;
        }

        if (thirdCollider == true)
        {
            textCanvas2.enabled = true;
            text2.text = " What are these? Father always told me about these old clippings ... let's look (Press E to interact)";


        }
        else
        {
            textCanvas2.enabled = false;
            text2.text = null;
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
        else
        {
        }



        Debug.Log("Jumping");



        }

    void inventory()
    {
        inventoryEnabled = true; 

        inventoryCanvas.enabled = true;
        Debug.Log("Am i working");

        //if (Input.GetKeyDown(KeyCode.I) && inventoryEnabled != true)
        //{
        //    inventoryCanvas.enabled = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.I) && inventoryEnabled == true) 
        //{
        //    inventoryCanvas.enabled = false;

        //}

    }

    private void timer()
    {
        if (loadingTimerEnabled == true)
        {
            loadingTimer += Time.deltaTime;
            loadingScreen.enabled = true;
            Debug.Log(loadingTimer);
        }

        if (loadingTimer > 3)
        {
           loadingTimerEnabled = false;
            loadingTimer = 0;

            loadingScreen.enabled = false;
        }
    }
}

