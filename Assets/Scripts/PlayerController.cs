using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private static float currentMovement;
	public float moveSpeed;
	public float jumpHeight;
    public float maxMoveSpeed;
    //hejhej
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;
	private Vector2 groundCheckDiag1;
	private Vector2 groundCheckDiag2;

	private Vector2 spawn;

	private float someScale;
	private bool hasKey=false;
	public Animator anim;
    public GameObject ChildObject;
    public GameObject Laser;

    private bool prev, current, inAir, jumping;

	// Use this for initialization
	void Start () {
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

		//Ground-checking
		groundCheckDiag1.x = groundCheck.position.x-0.49f;
		groundCheckDiag1.y = groundCheck.position.y-0.1f;
		groundCheckDiag2.x = groundCheck.position.x+0.49f;
		groundCheckDiag2.y = groundCheck.position.y+0.1f;

		grounded = Physics2D.OverlapArea (groundCheckDiag1, groundCheckDiag2, whatIsGround);

		if (grounded)
			doubleJumped = false;

        if (prev == true && jumping == false && GetComponent<Rigidbody2D>().velocity.y>8.2f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpHeight/2), ForceMode2D.Impulse);
        }

        if (jumping == false)
        {
            inAir = false;
            prev = false;
        }

		//Jumping
		if (jumping && grounded && prev==false) 
		{
            GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
            inAir = true;
            prev = true;
		}
		
		if (jumping && !grounded && inAir == true)
		{
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 3)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, (GetComponent<Rigidbody2D>().velocity.y*4.5f)/2));

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
			hasKey = true;
			Destroy (other.gameObject);
		}
	}

    public void Movement()
    {
        currentMovement = Input.GetAxisRaw("Horizontal");

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < maxMoveSpeed && currentMovement > 0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentMovement * moveSpeed, 0f));

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > -maxMoveSpeed && currentMovement < 0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentMovement * moveSpeed, 0f));


        //Turning/facing new direction
        if (Input.GetAxisRaw("Horizontal") == 1 || currentMovement == 1)
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            ChildObject.transform.localScale = new Vector2(someScale, ChildObject.transform.localScale.y);
        }
        if (Input.GetAxisRaw("Horizontal") == -1 || currentMovement == -1){
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            ChildObject.transform.localScale = new Vector2(-someScale, ChildObject.transform.localScale.y);
            Laser.transform.localScale = new Vector2(someScale, transform.localScale.y);
        }

        anim.SetFloat("Walking", Mathf.Abs(currentMovement * moveSpeed));

    }

    public void startMoving(float moveDirection)
    {
        currentMovement=moveDirection;

    }


    public void startJumping(bool jumped)
    {
        jumping = jumped;
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

