using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	//public KeyCode pause;
	private bool paused = false;
	//private Rect windowRect = new Rect(100,100,100,100);
	public Rect windowRect = new Rect(20, 20, 800, 500);
	public KeyCode showMenu;
	private bool menuTrue = false;

	// Use this for initialization
	void Start () {
	
		Time.timeScale = 1;
	}

	void doPause(){
		Time.timeScale = 0;
		paused = true;

	}

	void dontPause(){

		Time.timeScale = 1;
		paused = false;
		menuTrue = false;
	}

	void restart(){
		Application.LoadLevel("Pixelles_MostRecent");

		}

	void quit(){
		Application.LoadLevel("MainMenu");
		
	}
	
	void OnGUI() {

		if (Input.GetKey (showMenu)) {
			doPause ();
			menuTrue = true;
				} 

		if (menuTrue) {
			windowRect = GUI.Window (0, windowRect, DoMyWindow, "Menu");

				}
	}
	

	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (70, 20, 100, 20), "Resume")) {
				dontPause ();

				} 
		if (GUI.Button (new Rect (70, 50, 100, 20), "Restart")) {
			restart ();
			
		} 

		if (GUI.Button (new Rect (70, 80, 100, 20), "Menu")) {
			quit ();
			
		} 
	}

	void FixedUpdate(){


	
		}



		}



