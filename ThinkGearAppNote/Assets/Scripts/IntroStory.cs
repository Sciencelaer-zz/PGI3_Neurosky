using UnityEngine;
using System.Collections;

public class IntroStory : MonoBehaviour {

	public GameObject textOne;
	public GameObject textTwo;
	public GameObject textThree;
	public GameObject textFour;
	public GameObject textFive;
	public GameObject character;

	private int textCount = 0; 

	// Use this for initialization
	void Start () {
		textTwo.SetActive (false);
		textThree.SetActive (false);
		textFour.SetActive (false);
		textFive.SetActive (false);
		character.SetActive (false);


	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			textCount ++;

				}

		//print (textCount);

		if (textCount == 1) {

			textTwo.SetActive(true);

				}
		if (textCount == 2){

			textOne.SetActive(false);
			textTwo.SetActive(false);
			textThree.SetActive(true);

		}

		if (textCount == 3) {

			textThree.SetActive(false);
			textFour.SetActive(true);

				}

		if (textCount == 4) {
			
			textFour.SetActive(false);
			textFive.SetActive(true);
			character.SetActive(true);
			
		}

		if (textCount == 5) {

			Application.LoadLevel("TutorialLevel");
				}
	}
}
