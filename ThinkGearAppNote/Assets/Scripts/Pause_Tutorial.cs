using UnityEngine;
using System.Collections;

public class Pause_Tutorial : MonoBehaviour {
	
	private bool paused = false;
	private bool menuTrue = false;
	public GameObject pausedText;


	public GameObject tg_script;
	public ThinkGearController tg_headset;

	// Use this for initialization
	void Start () {

		pausedText.SetActive (false);
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
		tg_headset.SendMessage("OnHeadsetDisconnectionRequest");
		Application.LoadLevel("TutorialLevel");

		}

	void quit(){
		tg_headset.SendMessage("OnHeadsetDisconnectionRequest");
		Application.LoadLevel("MainMenu");
		
	}


	void Update(){

			if (Input.GetKeyDown(KeyCode.Escape) && !paused) {
						pausedText.SetActive (true);
						doPause ();
						menuTrue = true;
						//paused = true;
					} else if (Input.GetKeyDown (KeyCode.Escape) && paused) {
						pausedText.SetActive (false);
						dontPause ();
						menuTrue = false;
						//paused = false;
			
		}
		if (paused && Input.GetKeyDown (KeyCode.R)) {
						restart ();

				} else if (paused && Input.GetKeyDown (KeyCode.Q)) {

						quit ();
				}
	
		}



		}



