using UnityEngine;
using System.Collections;

public class setCalmThreshold : MonoBehaviour {

	public GameObject calm;
	public MainMenu main;
	public int threshold;
	// Use this for initialization
	void Start () {

		calm = GameObject.Find("MainMenuCode");
		main = calm.GetComponent <MainMenu> ();

		threshold = main.calmThreshold;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
