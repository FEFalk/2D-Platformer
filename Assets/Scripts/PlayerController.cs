using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace UnityStandardAssets.CrossPlatformInput
{

    public class PlayerController : MonoBehaviour
    {
    public float currentMovement;
	public float moveSpeed;
	public float jumpHeight;
    public float maxMoveSpeed;
    //hejhej
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded;
    public bool isMoving;

	private bool doubleJumped;
	private Vector2 groundCheckDiag1;
	private Vector2 groundCheckDiag2;

	private Vector2 spawn;

	private float someScale;
	private bool hasKey=false;
	public Animator anim;
    public GameObject ChildObject;
    public GameObject Laser;

    private bool jumpButtonPressed;
    private bool prev, current, inAir, jumping;

	// Use this for initialization
	void Start () 
    {
		spawn=transform.position;
		someScale = transform.localScale.x;
	}

	void FixedUpdate(){

        Movement();

        if (currentMovement == 0)
            applyStopForce();


        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 3)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -20));
        }
	}


	// Update is called once per frame
	void Update () {

        if (Input.GetButtonUp("Horizontal"))
        {
            currentMovement = 0;
            isMoving = false;
        }


		//Ground-checking
		groundCheckDiag1.x = groundCheck.position.x-0.49f;
		groundCheckDiag1.y = groundCheck.position.y-0.1f;
		groundCheckDiag2.x = groundCheck.position.x+0.49f;
		groundCheckDiag2.y = groundCheck.position.y+0.1f;

		grounded = Physics2D.OverlapArea (groundCheckDiag1, groundCheckDiag2, whatIsGround);

		if (grounded)
			doubleJumped = false;

        if (prev == true && jumping == false && GetComponent<Rigidbody2D>().velocity.y > 8.2f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpHeight / 2), ForceMode2D.Impulse);
        }

        if (jumping == false)
        {
            inAir = false;
            prev = false;
        }

        //Jumping
        if (Input.GetButton("Jump"))
        {
            jumping = true;
        }
        if (jumping && grounded && prev == false)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
            inAir = true;
            prev = true;
        }

        if (jumping && !grounded && inAir == true)
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 3)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, (GetComponent<Rigidbody2D>().velocity.y * 4.5f) / 2));
        }
        if (!Input.GetButton("Jump") && jumpButtonPressed == false)
        {
            jumping = false;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            currentMovement = 0;
            isMoving = false;
        }

    }
	

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "Enemy")
		{
			Die();
		}
	}
	void Die(){
		transform.position = spawn;
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.tag == "Goal" && hasKey == true)
		{
			GameManagerScript.CompleteLevel();
		}
	
		else if (other.transform.tag == "Key") 
		{
            GameObject.Find("Unity_Door").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/Unity_DoorOpen");
            GameObject.Find("GoalLight").GetComponent<Light>().color = Color.green;
			hasKey = true;
			Destroy (other.gameObject);
		}
	}

    public void Movement()
    {
            //currentMovement = Mathf.RoundToInt(CrossPlatformInput.CrossPlatformInputManager.GetAxisRaw("Horizontal"));

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
            {
                currentMovement = Input.GetAxisRaw("Horizontal");
                isMoving = true;
            }


            if (gameObject.GetComponent<Rigidbody2D>().velocity.x < maxMoveSpeed && currentMovement > 0)
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentMovement * moveSpeed, 0f));

            if (gameObject.GetComponent<Rigidbody2D>().velocity.x > -maxMoveSpeed && currentMovement < 0)
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentMovement * moveSpeed, 0f));


            //Turning/facing new direction

            if (Input.GetAxisRaw("Horizontal") == 1 || currentMovement == 1)
            {
                transform.Find("Body").localScale = new Vector3(someScale, transform.localScale.y, 1);
            }
            if (Input.GetAxisRaw("Horizontal") == -1 || currentMovement == -1)
            {
                transform.Find("Body").localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            }

            anim.SetFloat("Walking", Mathf.Abs(currentMovement * moveSpeed));
        }

    public void startMoving(float moveDirection)
    {
        currentMovement=moveDirection;
        if (moveDirection < 0 || moveDirection > 0)
            isMoving = true;
        else
            isMoving = false;

    }


    public void startJumping(bool jumped)
    {
        jumping = jumped;
        if(jumped)
            jumpButtonPressed = true;
        else
            jumpButtonPressed = false;
    }

    public void resetLevel()
    {
        transform.position = spawn;
    }

    void applyStopForce()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 1)
        {
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0f));
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < -1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0f));
        }
    }
}

}