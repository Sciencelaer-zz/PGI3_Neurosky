using UnityEngine;
using System.Collections;

public class WinGui : MonoBehaviour {

	public GameObject p;
	public MovePlayer mp;
	public bool winstate;

	//Handling the game GUI
	public Rect windowRect = new Rect (20, 20, 1000, 500);
	private bool paused = false;

	public GameObject tg_script;
	public ThinkGearController tg_headset;


	// Use this for initialization
	void Update () {
		p = GameObject.Find ("Player");
		mp = p.GetComponent <MovePlayer> ();
		winstate = mp.endTrue;

		tg_script = GameObject.Find ("ThinkGear");
		tg_headset = tg_script.GetComponent <ThinkGearController> ();
	}


	void OnGUI() {
		
		
		if (winstate) {
			windowRect = GUI.Window (0, windowRect, DoSuccessWindow, "Congratulations! You saved the robot!");
			//GUI.Label(new Rect (20, 20, 500, 80), "You Saved the Robot");
		}
		
	}
	
	void doPause(){
		Time.timeScale = 0;
		paused = true;
		
	}
	void restart(){
		tg_headset.SendMessage("OnHeadsetDisconnectionRequest");

		Application.LoadLevel("Pixelles_MostRecent");
		
	}
	
	void quit(){
		tg_headset.SendMessage("OnHeadsetDisconnectionRequest");
		//yield return new WaitForSeconds(5);
		Application.LoadLevel("MainMenu");
		
	}

	void DoSuccessWindow(int ID){
		
		if (GUI.Button (new Rect (70, 50, 100, 20), "Restart")) {
			restart ();
			
		} 
		
		if (GUI.Button (new Rect (70, 80, 100, 20), "Menu")) {
			quit ();
			
		} 
		
	}

	
}
