using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public GameObject thresh;
	void Awake(){
		
		DontDestroyOnLoad (thresh);
		
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
