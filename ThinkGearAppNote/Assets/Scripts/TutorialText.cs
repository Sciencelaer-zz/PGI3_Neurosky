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
	private bool actualMed = false;

	int count = 0;
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
		actualMed = mp.actualData;


		if (Input.GetKey (KeyCode.F1)) {

			initiateLinkText.SetActive(false);
			count = 1;

				}

		if (actualMed) {
				linkEstablishedText.SetActive (true);

				}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "followMe" && count == 0) {
			initiateLinkText.SetActive (true);
			exclamation.SetActive(false);

			}
		
	}
}
