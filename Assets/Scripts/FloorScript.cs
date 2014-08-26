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
	
	void OnCollisionEnter(Collision collisionInfo)
	{
		Debug.Log ("floor");
	}
	
	void OnTriggerEnter (Collider other)
	{
		
		Debug.Log ("floor OnTriggerEnter");
	}
}
