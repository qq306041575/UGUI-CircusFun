using UnityEngine;
using System.Collections;

/*
 * 	This script is used to control the player.
 */ 

public class Player : MonoBehaviour 
{
	public Animator animator;
	bool isGrounded = true;
	bool isDead = false;
	int score = 0;

	AudioSource[] a;
	bool playbool;

	public GUIStyle gameoverstyle;
	public GUIStyle scorestyle;
	public GUIStyle homestyle;
	public GUIStyle restartstyle;

	// Use this for initialization
	void Awake () 
	{
		a = GameObject.Find("sound").GetComponents<AudioSource> ();
		if( PlayerPrefs.GetInt("sound") == 1 )
		{
			a [3].Play ();
		}
		Time.timeScale = 1;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( a[3].time >= 4 )
		{
			a[3].Play();
		}

		// used for getting input from the player so that player can jump.
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true && isDead == false || Input.GetMouseButtonDown (0) && isGrounded == true && isDead == false) 
		{
			a [2].Play ();
			isGrounded = false;
			animator.SetBool ("jump", true);
            GetComponent<Rigidbody2D>().AddForce (new Vector2 (0.0f, 150.0f));
		}
		else
		{
			animator.SetBool("jump", false);		
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		// checking if the player is on the ground.
		if( col.gameObject.tag == "ground" && animator.GetBool("jump") == false)
		{
			isGrounded = true;
		}

		// checking if the player has collided with any obstacles
		if (col.gameObject.tag == "obs") 
		{
			a [1].Play ();
			isDead = true;
			Time.timeScale = 0;
		}
	}

	// Collects the coin and adds 100 to the player score as well as plays the sound for coin collection.
	void OnTriggerEnter2D( Collider2D other )
	{
		if (other.gameObject.tag == "coin") 
		{
			a [0].Play ();
			score += 100;
			Destroy(other.gameObject);
		}
	}

	// Creates the UI for GameOver.
	void OnGUI()
	{
		if(isDead == true)
		{
			scorestyle.fontSize = Screen.height/10;
			GUI.Box(new Rect( Screen.width*0.2f, Screen.height*0.1f, Screen.width*0.6f, Screen.height*0.45f ),"",gameoverstyle);
			GUI.Box( new Rect( Screen.width*0.2f, Screen.height*0.4f, Screen.width *0.6f, Screen.height*0.1f ), " "+score.ToString() , scorestyle );
			if( GUI.Button( new Rect( Screen.width * 0.25f , Screen.height*0.6f, Screen.width * 0.23f , Screen.height *0.15f ), "" , homestyle ) )
			{
				Application.LoadLevel("MainMenu");
			}
			if(GUI.Button(new Rect(Screen.width*0.52f, Screen.height*0.6f, Screen.width*0.23f, Screen.height*0.15f), "", restartstyle))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}