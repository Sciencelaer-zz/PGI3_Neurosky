using UnityEngine;
using System.Collections;

public class MovePlayer_Tutorial : MonoBehaviour {

		enum AppState {
			Disconnected = 0,
			Connecting,
			Connected
		}
		
		
		public GameObject player;
		public GameObject hexbot; 
		public Camera camera;
		public Animator powerup;
		public bool saved = false;
		private bool reachedRobot = false;
		private bool isCalm = false;
		private bool hacking = false;

		public int calmThresholdFollowing;
		public int calmThresholdHacking;
		private int calmLevel;
		private float rDistance;

		//Colours to indicate calm
		private Color calm0;

		// Variables for handling movements
		
		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
		public float speed= 3.0f;

		//public GUIText successText;
		
		// Code for handling the NEUROSKY headset. Find more info on the Neurosky website
		//private int handleID = -1;
		//private int baudRate = ThinkGear.BAUD_9600;
		//private int packetType = ThinkGear.STREAM_PACKETS;
		private Hashtable headsetValues; 
		private AppState state = AppState.Disconnected;
		public bool actualData = false;
		private float meditation = 0;
		
		//Handling the game GUI
		//private Rect windowRect = new Rect (20, 20, 1000, 500);
		public bool endTrue = false;
		//public GameObject exitSign;
		//public AudioSource robotSounds; 
		//private bool paused = false;
		
		//Listening for Data...whatever that means  (this is just ported from the ThinkGearGui js code)
		void OnHeadsetDataReceived(Hashtable values){
			headsetValues = values;
			actualData = true;
		}
		
		void OnHeadsetConnected(){
			state = AppState.Connected;
		}
		
		//My Actual Game Code
		void Awake(){
		calm0.r = 0;
		calm0.g = 0;
		calm0.b = 0;
		calm0.a = 1;
			//exitSign.SetActive (false);
		}
		
	private int n = 1;

		void Update()
		{

		//Debug.Log (meditation);
			robotDistance ();

			//Debug.Log (rDistance);
			ControlAnimation ();
			isRobotCalm ();
			isRobotFollowing ();
			
			if (state == AppState.Connected && actualData) {
				
						meditation = (float)headsetValues ["meditation"];
		
		}

	}
	
		
		
		void FixedUpdate ()
		{

		camera.backgroundColor = calm0;

		if (Input.GetKey(KeyCode.RightArrow)){

			player.transform.Translate (new Vector2 (5f, 0.0f));
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			
			player.transform.Translate (new Vector2 (-5f, 0.0f));
		}

			
			if (saved) {

				if (Input.GetKey(KeyCode.RightArrow)){
				
					hexbot.transform.Translate (new Vector2 (5f, 0.0f));
				}
				if (Input.GetKey(KeyCode.LeftArrow)){
				
					hexbot.transform.Translate (new Vector2 (-5f, 0.0f));
				}
			}

		}
		
		
		void OnCollisionEnter2D(Collision2D collision2d)
		{
			
		}
		
		
		void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "DoorCircuit") {
						if (saved) {
								hacking = true;
								Debug.Log ("door");
						}
				}

		}


		
		void robotDistance(){
			rDistance = Mathf.Abs(player.rigidbody2D.position.x - hexbot.rigidbody2D.position.x);

		}

		void isRobotCalm(){
			if (meditation > calmThresholdFollowing && rDistance < 220) {
				isCalm = true;
			} else {
				isCalm = false;
				
			}
		}
		
		void isRobotFollowing(){
			if (isCalm) {
				
				saved = true;
			} 
			else {
				saved = false;
			}
			
		}
		
		void ControlAnimation(){
		calm0.r = (100F - meditation) * 0.01F;
		calm0.b = (meditation) * 0.01F;
			//Debug.Log(hexbot.audio.volume);

			if (meditation > calmThresholdFollowing) {
				powerup.speed = 0.01F;
				hexbot.audio.volume = 0.01F;
				
				
				
			} else {
				powerup.speed = (100F - meditation) * 0.05F;//meditation;
				
				if (meditation != 0.0F){
					hexbot.audio.volume = (100F - meditation) * 0.01F;
				}
			}
			
		}
		
		
		
	}

