using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

	public bool isFloor = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		PlayerScript player = col.gameObject.GetComponent<PlayerScript>();
		if (player != null)
		{
			//player.onFloor = true;
		}
	}
	
	void OnCollisionExit2D (Collision2D col)
	{
		PlayerScript player = col.gameObject.GetComponent<PlayerScript>();
		if (player != null)
		{
			//player.onFloor = false;
		}
	}
}
