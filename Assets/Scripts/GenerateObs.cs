using UnityEngine;
using System.Collections;

/*
 * 	This script is used to Generate the different obstacles randomly which will be used in the game.
 * 	We also use a counter so that we can increase the speed of the generated obstacles, making the game more difficult as time progresses.
 */ 

public class GenerateObs : MonoBehaviour 
{
	public GameObject[] obs;	//	array to hold different types of obstacles which will be generated in this script.
	GameObject[] target;

	float t = 0.0f; 	//	 used for keeping track of time so that we can increase the speed of the obstacles 
	float t1 = 0.0f;	//	used for keeping track of time so that we can instantiate new obstacles

	int random;


	// we use this to reset all obstacle prefabs. that is disable script with speed 5,6,7 & 8 and enable the script with speed 4. 
	// Use this for initialization
	void Start () 
	{
		random = Random.Range(0, 4);		
		Instantiate(obs[random]);
		obs[0].GetComponent<MoveObs4>().enabled = true;
		obs[1].GetComponent<MoveObs4>().enabled = true;
		obs[2].GetComponent<MoveObs4>().enabled = true;
		obs[3].GetComponent<MoveObs4>().enabled = true;

		obs[0].GetComponent<MoveObs5>().enabled = false;
		obs[1].GetComponent<MoveObs5>().enabled = false;
		obs[2].GetComponent<MoveObs5>().enabled = false;
		obs[3].GetComponent<MoveObs5>().enabled = false;

		obs[0].GetComponent<MoveObs6>().enabled = false;
		obs[1].GetComponent<MoveObs6>().enabled = false;
		obs[2].GetComponent<MoveObs6>().enabled = false;
		obs[3].GetComponent<MoveObs6>().enabled = false;

		obs[0].GetComponent<MoveObs7>().enabled = false;
		obs[1].GetComponent<MoveObs7>().enabled = false;
		obs[2].GetComponent<MoveObs7>().enabled = false;
		obs[3].GetComponent<MoveObs7>().enabled = false;

		obs[0].GetComponent<MoveObs8>().enabled = false;
		obs[1].GetComponent<MoveObs8>().enabled = false;
		obs[2].GetComponent<MoveObs8>().enabled = false;
		obs[3].GetComponent<MoveObs8>().enabled = false;
	}

	//	used for instantiation of obstacles based on two timer conditions.
	// Update is called once per frame
	void FixedUpdate () 
	{
		t += Time.deltaTime;
		t1 += Time.deltaTime;
		if( t >= 120.0f )
		{
			if(t1 > 1.35f)
			{
				random = Random.Range(0, 4);				
				Instantiate(obs[random]);
				Eight();
				t1 = 0.0f;
			}
		}
		else if( t < 120.0f && t >= 90.0f )
		{
			if(t1 > 1.4f)
			{
				random = Random.Range(0, 4);			
				Instantiate(obs[random]);
				Seven();				
				t1 = 0.0f;			
			}
		}
		else if( t < 90.0f && t >= 60.0f)
		{
			if(t1 > 1.45f)
			{
				random = Random.Range(0, 4);
				Instantiate(obs[random]);
				Six();			
				t1 = 0.0f;
			}
		}
		else if ( t < 60.0f && t >= 30.0f )
		{
			if(t1 > 1.5f)
			{
				random = Random.Range(0, 4);
				Instantiate(obs[random]);			
				Five();
				t1 = 0.0f;
			}
		}
		else if ( t < 30.0f )
		{
			if(t1 > 1.6f )
			{
				random = Random.Range(0, 4);
				Instantiate(obs[random]);
				t1 = 0.0f;
			}
		}
	}


	// This function is used to disable the script on obstacles with speed of 4 and use the script with speed of 5 instead.
	void Five()
	{
		target = GameObject.FindGameObjectsWithTag ("obs0");
		foreach (GameObject go in target)
		{
			go.GetComponent<MoveObs4>().enabled = false;
			go.GetComponent<MoveObs5>().enabled = true;
		}

		target = GameObject.FindGameObjectsWithTag ("obs1");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs4>().enabled = false;
			go.GetComponent<MoveObs5>().enabled = true;
		}

		target = GameObject.FindGameObjectsWithTag ("obs2");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs4>().enabled = false;
			go.GetComponent<MoveObs5>().enabled = true;
		}

		target = GameObject.FindGameObjectsWithTag ("obs3");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs4>().enabled = false;
			go.GetComponent<MoveObs5>().enabled = true;
		}
	}


	// This function is used to disable the script on obstacles with speed of 5 and use the script with speed of 6 instead.
	void Six()
	{
		target = GameObject.FindGameObjectsWithTag ("obs0");
		foreach (GameObject go in target)
		{
			go.GetComponent<MoveObs5>().enabled = false;
			go.GetComponent<MoveObs6>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs1");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs5>().enabled = false;
			go.GetComponent<MoveObs6>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs2");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs5>().enabled = false;
			go.GetComponent<MoveObs6>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs3");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs5>().enabled = false;
			go.GetComponent<MoveObs6>().enabled = true;
		}
	}


	// This function is used to disable the script on obstacles with speed of 6 and use the script with speed of 7 instead.
	void Seven()
	{
		target = GameObject.FindGameObjectsWithTag ("obs0");
		foreach (GameObject go in target)
		{
			go.GetComponent<MoveObs6>().enabled = false;
			go.GetComponent<MoveObs7>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs1");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs6>().enabled = false;
			go.GetComponent<MoveObs7>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs2");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs6>().enabled = false;
			go.GetComponent<MoveObs7>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs3");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs6>().enabled = false;
			go.GetComponent<MoveObs7>().enabled = true;
		}
	}


	// This function is used to disable the script on obstacles with speed of 7 and use the script with speed of 8 instead.
	void Eight()
	{
		target = GameObject.FindGameObjectsWithTag ("obs0");
		foreach (GameObject go in target)
		{
			go.GetComponent<MoveObs7>().enabled = false;
			go.GetComponent<MoveObs8>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs1");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs7>().enabled = false;
			go.GetComponent<MoveObs8>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs2");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs7>().enabled = false;
			go.GetComponent<MoveObs8>().enabled = true;
		}
		
		target = GameObject.FindGameObjectsWithTag ("obs3");
		foreach (GameObject go in target) 
		{
			go.GetComponent<MoveObs7>().enabled = false;
			go.GetComponent<MoveObs8>().enabled = true;
		}
	}
}