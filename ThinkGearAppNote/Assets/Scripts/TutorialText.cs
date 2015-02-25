using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {

	public GameObject imHere;
	public GameObject needHelp;
	public GameObject binary;
	public GameObject understood;
	public GameObject initiateLinkText;
	public GameObject linkEstablishedText;
	public GameObject exclamation;
	public GameObject exclamationHacking;
	public GameObject enterToContinue;

	public GameObject p;
	public MovePlayer_Tutorial mp;
	//public Pause_Tutorial pauseFunctions;
	private bool actualMed = false;
	public int calmThreshold;

	int count = -1;
	//public GameObject linkEstablisedText;

	// Use this for initialization
	void Start () {

		imHere.SetActive (false);
		needHelp.SetActive (false);
		binary.SetActive (false);
		understood.SetActive (false);
		initiateLinkText.SetActive (false);
		linkEstablishedText.SetActive (false);
		exclamation.SetActive(true);
		exclamationHacking.SetActive (false);
		enterToContinue.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		p = GameObject.Find ("Player");
		mp = p.GetComponent <MovePlayer_Tutorial> ();
		actualMed = mp.actualMed;

		//pauseFunctions = p.GetComponent <Pause_Tutorial> ();



		if (Input.GetKeyDown (KeyCode.Return) && count == 1) {
						imHere.SetActive (false);
						needHelp.SetActive (true);
						count++;
				} else if (Input.GetKeyDown (KeyCode.Return) && count == 2) {
						needHelp.SetActive (false);
						binary.SetActive (true);
						count++;
				} else if (Input.GetKeyDown (KeyCode.Return) && count == 3) {
						binary.SetActive (false);
						understood.SetActive (true);
						count++;
				} else if (Input.GetKeyDown (KeyCode.Return) && count == 4) {
						understood.SetActive (false);
						initiateLinkText.SetActive (true);
				} 

		if (Input.GetKey (KeyCode.F1)) {
			initiateLinkText.SetActive(false);
			}


		if (actualMed) {
				linkEstablishedText.SetActive (true);
				exclamationHacking.SetActive (true);
			}

	}


	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "followMe" && count == 0) {
			imHere.SetActive(true);
			exclamation.SetActive(false);
			count++;

			}

		if (other.gameObject.tag == "DoorCircuit") {
			DestroyObject (exclamationHacking);

				}
		if (other.gameObject.tag == "KillAllText" && count == 4) {

			DestroyObject(linkEstablishedText);

				}

		
	}
}
