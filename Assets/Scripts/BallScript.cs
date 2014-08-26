using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate ()
	{
		//Debug.Log ("BallScript FixedUpdate v="+rigidbody2D.velocity);
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		Vector2 oldV = rigidbody2D.velocity;
		//Debug.Log ("BallScript OnCollisionEnter2D oldV=" + oldV);
		//rigidbody2D.velocity = new Vector2 (oldV.x, -3 * oldV.y);
		
	}
	
}
