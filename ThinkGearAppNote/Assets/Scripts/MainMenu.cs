using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject startgame;
	/*public GameObject storymode;
	public GameObject beginner;
	public GameObject advanced;
	public GameObject expert;*/
	public GameObject pressEnter;

	public int calmThreshold;
	private bool startingNow;
	// Use this for initialization
	void Start () {
		startgame.SetActive (true);
		/*storymode.SetActive (false);
		beginner.SetActive (false);
		advanced.SetActive (false);
		expert.SetActive (false);
		*/
		pressEnter.SetActive (true);
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			startgame.SetActive(false);
			/*storymode.SetActive(true);
			beginner.SetActive(true);
			advanced.SetActive(true);
			expert.SetActive(true);*/
			pressEnter.SetActive(false);
			startingNow = true;

				}

		if (Input.GetKeyDown (KeyCode.Alpha1)){
			calmThreshold = 0;
			startingNow = true;
		}else if (Input.GetKeyDown(KeyCode.Alpha2)){

			calmThreshold = 20;
			startingNow = true;

		}else if (Input.GetKeyDown(KeyCode.Alpha3)){

			calmThreshold = 70;
			startingNow = true;

		}else if (Input.GetKeyDown(KeyCode.Alpha4)){
			calmThreshold = 100;
			startingNow = true;
		}

		if (startingNow){

			Application.LoadLevel("IntroScreen");

		}
	}
}
