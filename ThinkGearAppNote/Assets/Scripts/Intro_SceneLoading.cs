using UnityEngine;
using System.Collections;

public class Intro_SceneLoading : MonoBehaviour {

	//public KeyCode loadLevel;

	public void StartGame() {

		Application.LoadLevel("Pixelles_MostRecent");
	}
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKey (loadLevel)) {
			
			Example (); 
			
		} */	


	}
}
