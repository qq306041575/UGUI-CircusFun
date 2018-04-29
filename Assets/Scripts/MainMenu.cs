using UnityEngine;
using System.Collections;

/*
 *	This Script is used to enter the Game Mode. 
 *	In this Script we also display the sound mute and sound unmute button and set our playerprefs accordingly to reflect the player's sound on/off setting.
 */

public class MainMenu : MonoBehaviour 
{
	public GUIStyle bgStyle;		//	used to set the background for the main menu
	public GUIStyle playStyle;		//	used for the play button	
	public GUIStyle soundUnmute;	//  used for the sound button (soundON)
	public GUIStyle soundMute;		// 	used for the sound button (soundOFF)

	public AudioSource menuAS;		// 	Audio source to hold the background sound that will be played while at main menu scene.

	// Use this for initialization
	void Start () 
	{
		if (!PlayerPrefs.HasKey ("sound")) 
		{
			PlayerPrefs.SetInt ("sound", 1);
			menuAS.Play ();
		}
		else if (PlayerPrefs.GetInt ("sound") == 1)
		{
			menuAS.Play ();
		} 
		else 
		{
			menuAS.Stop();		
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt ("sound") == 0) 
		{
			menuAS.Stop ();
		} 
		else if (menuAS.time >= 8)	//	we check the time because our audio clip is longer and has empty space at the end.  
		{
			menuAS.Play ();
		}
	}

	void OnGUI()
	{
		GUI.Box (new Rect( 0.0f ,0.0f , Screen.width , Screen.height ), "" , bgStyle );	// render the background

		if( GUI.Button ( new Rect (Screen.width*0.39f , Screen.height *0.6f , Screen.width *0.3f , Screen.height *0.15f ) , "" , playStyle ))	//	render the play button
		{
			Application.LoadLevel("Game");	//	load the Game scene when the player clicks on play button 
		}

		if (menuAS.isPlaying) 	//	check if the menu audio source is playing so that we can show player the button soundON
		{
			//PlayerPrefs.SetInt("sound",1);

			if(GUI.Button( new Rect( Screen.width*0.85f, Screen.height*0.05f, Screen.width*0.1f, Screen.height*0.1f ), "" , soundUnmute))	//	render the soundON button
			{
				menuAS.Stop();	//	player has clicked on the button so stop the background music that is playing
				PlayerPrefs.SetInt("sound",0);	//	we also save the player choice so that we can access it in game scene.
				PlayerPrefs.Save();
			}
		} 
		else 	//	background music is not playing so we must display the button with soundOFF	
		{
			if(GUI.Button( new Rect( Screen.width*0.85f, Screen.height*0.05f, Screen.width*0.1f, Screen.height*0.1f ), "" , soundMute))		//	render the soundOFF button
			{
				menuAS.Play();	//	player has clicked on the button so now we must start playing the menu background.
				PlayerPrefs.SetInt("sound",1);	//	we also save the player choice so that we can access it in game scene
				PlayerPrefs.Save();
			}
		}
	}
}