using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    public float maxMoveSpeed;
    private float currentMovement;
	public float jumpHeight;

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
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -15));
        }



	}


	// Update is called once per frame
	void Update () {

		//Ground-checking
		groundCheckDiag1.x = groundCheck.position.x-0.5f;
		groundCheckDiag1.y = groundCheck.position.y-0.1f;
		groundCheckDiag2.x = groundCheck.position.x+0.5f;
		groundCheckDiag2.y = groundCheck.position.y+0.1f;

		grounded = Physics2D.OverlapArea (groundCheckDiag1, groundCheckDiag2, whatIsGround);

		if (grounded)
			doubleJumped = false;

		//Jumping
		if (Input.GetButtonDown("Jump") && grounded) 
		{
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
		}
		
		if (Input.GetButtonDown("Jump") && !grounded && !doubleJumped) 
		{
			doubleJumped=true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
		}


		//Turning/facing new direction
		if(Input.GetAxisRaw("Horizontal")==1)
			transform.localScale = new Vector2(someScale, transform.localScale.y);
		if(Input.GetAxisRaw("Horizontal")==-1)
			transform.localScale = new Vector2(-someScale, transform.localScale.y);
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

    void Movement()
    {
        currentMovement = Input.GetAxisRaw("Horizontal");

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < maxMoveSpeed && currentMovement > 0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentMovement * moveSpeed, 0f));

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > -maxMoveSpeed && currentMovement < 0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentMovement * moveSpeed, 0f));

        anim.SetFloat("Walking", Mathf.Abs(currentMovement * moveSpeed));
    }

    void applyStopForce()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 1)
        {
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15, 0f));
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < -1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 0f));
        }
    }
}