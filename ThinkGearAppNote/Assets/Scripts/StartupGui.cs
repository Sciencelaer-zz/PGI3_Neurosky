using UnityEngine;
using System.Collections;

public class StartupGui : MonoBehaviour {

	enum AppState {
		Disconnected = 0,
		Connecting,
		Connected
	}
	
	public bool menuTrue = true;
	private bool connectionRequest = false;
	public Rect windowRect = new Rect(20, 20, 1000, 500);

	// Neurosky headset data
	private Hashtable headsetValues; 
	private AppState state = AppState.Disconnected;
	private bool actualData = false;
	private float meditation = 0;
	

	void doPause(){
		Time.timeScale = 0;
	}
	
	void dontPause(){
		Time.timeScale = 1;
		menuTrue = false;
	}

	void OnGUI() {


		if (menuTrue) {
			windowRect = GUI.Window (0, windowRect, DoStartupWindow, "Startup");
		}
	
	
	}
	
	
	void DoStartupWindow(int windowID) {

		doPause ();
				
		GUI.Label(new Rect (20, 20, 500, 80), "To begin brain sensing... \n" +
			"\t 1. Ensure the Neurosky headset is placed on your head\n" +
			"\t 2. Press the \"Connect\" button on the top left of the screen");

				if (GUI.Button (new Rect (80, 100, 50, 20), "Got it")) {
						dontPause ();
				}


		}
	


}
