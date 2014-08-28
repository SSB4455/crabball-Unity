using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	bool facingRight = false;		// For determining which way the player is currently facing.
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 460f;
	bool jump;
	private bool grounded;

	private Animator anim;
	private Transform groundCheck;			// A position marking where to check if the player is grounded.



	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find ("groundCheck");
		anim = GetComponent<Animator> ();
		//facingRight = false;
	}
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		bool left = Input.GetKeyDown ("left");
	
		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
			
			//Debug.Log ("PlayerScript rigidbody2D.velocity=" + rigidbody2D.velocity);
		}
	}
	
	void FixedUpdate ()
	{
		float inputX = Input.GetAxis ("Horizontal");
		//print ("inputX=" + inputX + "\tfacingRight=" + facingRight);
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat ("Speed", Mathf.Abs(inputX));
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if (inputX * rigidbody2D.velocity.x < maxSpeed)
		{
			// ... add a force to the player.
			rigidbody2D.AddForce (Vector2.right * inputX * moveForce);
		}
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		{
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2 (Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
		
		// If the input is moving the player right and the player is facing left...
		if (inputX > 0 && !facingRight)
		{
			// ... flip the player.
			Flip ();
		} else if (inputX < 0 && facingRight) {	// Otherwise if the input is moving the player left and the player is facing right...
			// ... flip the player.
			Flip ();
		}

		if (jump)
		{
			// Set the Jump animator trigger parameter.
			//anim.SetTrigger("Jump");
			
			// Play a random jump audio clip.
			//int i = Random.Range(0, jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			// Add a vertical force to the player.
			rigidbody2D.AddForce (new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		print ("facingRight=" + facingRight);
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		
	}
	
	void OnCollisionExit2D (Collision2D col)
	{
		/*FloorScript floor = col.gameObject.GetComponent<FloorScript>();
		if (floor != null)
		{
			onFloor = false;
		}*/
	}
	
}
