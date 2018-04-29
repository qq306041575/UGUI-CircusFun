using UnityEngine;
using System.Collections;

/*
 * 	This script is used to move the background towards left and then to destroy the background once it reaches a certain point.
 */ 

public class MoveBG : MonoBehaviour 
{
	//	we move the background gameobject left along the negative x axis with speed of 4.
	// Use this for initialization
	void Start () 
	{	
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-4.0f, 0.0f);	
	}

	//	we check the background's position against a point such that we are sure that this background is outside the camera and then destroy the background
	// Update is called once per frame
	void Update ()
	{	
		if (transform.position.x < -20.0f)	 
		{
			Destroy(gameObject);		
		}
	}
}