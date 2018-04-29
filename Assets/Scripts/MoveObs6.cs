using UnityEngine;
using System.Collections;

/*
 * 	This script is used to move the Obstacle towards left and then to destroy the Obstacle once it reaches a certain point.
 */ 

public class MoveObs6 : MonoBehaviour 
{
	//	we move the obstacle left along the negative x axis with speed of 6.
	// Use this for initialization
	void Start ()
	{
        GetComponent<Rigidbody2D>().velocity = new Vector2 (-6.0f ,0.0f);		
	}

	//	we check the obstacle's position against a point such that we are sure that this obstacle is outside the camera and then destroy the obstacle
	// Update is called once per frame
	void Update ()
	{		
		if( transform.position.x < -20.0f )
		{
			Destroy(gameObject);
		}		
	}
}