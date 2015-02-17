using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public KeyCode pause;
	private bool paused = false;
	//private Rect windowRect = new Rect(100,100,100,100);
	public Rect windowRect = new Rect(20, 20, 220, 50);



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
	}
	
	// Update is called once per frame
	void OnGUI() {
		windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
	}

	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (10, 20, 100, 20), "Pause") && !paused) {
						doPause ();
				} else if (GUI.Button (new Rect (10,40,100,20), "Un Pause") && paused) {
					dontPause ();

				}
	}

	void FixedUpdate(){

		if (Input.GetKey (pause) && !paused) {
			
			doPause (); 
			
		} else if (Input.GetKey (pause) && paused) {
			
			dontPause ();
			
			
		}


	}



}



