using UnityEngine;
using System.Collections;

/*
 * 	This script is used to generate the background repeatedly. 
 */ 

public class GenerateBG : MonoBehaviour
{
	public GameObject BG;	//	The background prefab which should be generated repeatedly.

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("BGfun",0.03f, 5.0f);
	}

	void BGfun()
	{
		Instantiate (BG);
	}
}