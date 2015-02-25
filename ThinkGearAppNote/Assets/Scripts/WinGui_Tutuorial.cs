using UnityEngine;
using System.Collections;

public class WinGui_Tutuorial : MonoBehaviour {

	private bool won = false;
	private bool menuTrue = false;
	public GameObject winText;

	public GameObject p;
	public MovePlayer_Tutorial mp;
	
	public GameObject tg_script;
	public ThinkGearController tg_headset;
	
	// Use this for initialization
	void Start () {
		
		winText.SetActive (false);
		Time.timeScale = 1;
	}
	
	void doPause(){
		Time.timeScale = 0;

	}
	
	void dontPause(){
		
		Time.timeScale = 1;
		menuTrue = false;
	}
	
	void restart(){
		tg_headset.SendMessage("OnHeadsetDisconnectionRequest");
		Application.LoadLevel("TutorialLevel");
		
	}
	
	void quit(){
		tg_headset.SendMessage("OnHeadsetDisconnectionRequest");
		Application.LoadLevel("MainMenu");
		
	}
	
	
	void Update(){
		p = GameObject.Find ("Player");
		mp = p.GetComponent <MovePlayer_Tutorial> ();
		won = mp.endTrue;

		if (won) {
			winText.SetActive (true);
			doPause ();
			menuTrue = true;
			//paused = true;
		} 
			
		if (won && Input.GetKeyDown (KeyCode.R)) {
			restart ();
			
		} else if (won && Input.GetKeyDown (KeyCode.Q)) {
			
			quit ();
		}
		
	}


	
}
