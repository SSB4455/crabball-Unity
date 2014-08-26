using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public bool onFloor = false;
	public Vector2 speed = new Vector2 (10, 5);
	public float jumpForce = 1000f;
	private Vector2 movement;

	private Animator anim;
	bool jump;
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.



	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find ("groundCheck");
		anim = GetComponent<Animator> ();
	}
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		
		movement = new Vector2 (0, 0);
		if (grounded)
		{
			float inputX = Input.GetAxis ("Horizontal");
			jump = Input.GetKeyDown ("up");
			
			movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);
			rigidbody2D.velocity = movement;
			//Debug.Log ("PlayerScript rigidbody2D.velocity=" + rigidbody2D.velocity);
		}

	}
	
	void FixedUpdate ()
	{
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			//anim.SetTrigger("Jump");
			
			// Play a random jump audio clip.
			//int i = Random.Range(0, jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
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
