using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

	public GameObject player;
	public GameObject hexbot; 
	private bool saved = false;


	// Variables for handling movements
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float speed= 3.0f;

	// Variables for handling jumping
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	private int jumpCount = 0;
	public float jumpForce_one = 500f;			// Amount of force added when the player jumps.
	public float jumpForce_two = 250f;
	private bool grounded = true;			// Whether or not the player is grounded.
	//public GUIText successText;

	// Code for handling the NEUROSKY headset. Find more info on the Neurosky website
	// generate a handle to a ThinkGear connection
	/*int handleID = ThinkGear.TG_GetNewConnectionId();
	
	// perform the actual connection
	int connectStatus = ThinkGear.TG_Connect(handleID,
	                                         "/dev/tty.MindSet", 
	                                         ThinkGear.BAUD_9600, 
	                                      ThinkGear.STREAM_PACKETS); */
	void Awake()
	{
		/* // Setting up references.
		//groundCheck = transform.Find("groundCheck");
		//anim = GetComponent<Animator>();

		// More NeuroSky setup directly from the website
		if(connectStatus >= 0){
			// sleep for 1.5 seconds
			yield return new WaitForSeconds(1.5f);
			
			// read all of the data in the buffer
			int packetCount = ThinkGear.TG_ReadPackets(handleID, -1);
			
			// we've received some data, thus we've connected to a valid headset
			if(packetCount > 0){
				// implement some behavior here
			}
			// no valid headset data received, so close the connection
			else {

					
					ThinkGear.TG_FreeConnection(handleID);
			}
		}
		else {
			// the connection attempt was unsuccessful
			ThinkGear.TG_FreeConnection(handleID);
		}
	
	*/
	}

	
	void Update()
	{
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
				//grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));  
		
				// If the jump button is pressed and the player is grounded then the player should jump.
				if (Input.GetButtonDown ("Jump") && grounded && jumpCount <2) {
						jump = true; 

				}


		else if (Input.GetButtonDown ("Jump") && (jumpCount < 2)) {
				
				jump = true;
			grounded = false;
			}

		}
	
	
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(h));
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		Vector3 x = Input.GetAxis("Horizontal")* transform.right * Time.deltaTime * speed;

		if (saved) {
			//Vector2 direction = (player.transform.position - hexbot.transform.position).normalized;

			hexbot.transform.position=new Vector2(player.transform.position.x - 45f,player.transform.position.y - 20f);

		}

	

		// If the player should jump...
		if (jump) {
			Debug.Log("jump requested");

						if (jumpCount == 0) {
								// Add a vertical force to the player.
								rigidbody2D.AddForce (new Vector2 (0f, jumpForce_one));
			
								// Make sure the player can't jump again until the jump conditions from Update are satisfied.
								jumpCount++;
								jump = false;

						} else if (jumpCount == 1){


						rigidbody2D.AddForce (new Vector2 (0f, jumpForce_two));
			
						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jumpCount++;
						jump = false;

				}
		}
	}


	void OnCollisionEnter2D(Collision2D collision2d)
	{
		if (collision2d.gameObject.tag == "Ground") {
						
						grounded = true;
						jumpCount = 0;
						// check message upon collition for functionality working of code.
						Debug.Log ("I am colliding with the ground");

				} else if (collision2d.gameObject.tag == "Wall") {

					grounded = false; 
					jumpCount = 2;
					Debug.Log ("I am colliding with a wall");
				}

	}
	

	void OnTriggerEnter2D(Collider2D other){
		//Destroy (other.gameObject);
		
		if (other.gameObject.tag == "powerUp") {
			Debug.Log ("You reached the level end");
			other.gameObject.SetActive(false);
			//successText.text = "You Escaped the First Level!";
		}

		if (other.gameObject.tag == "followMe") {
			Debug.Log ("You picked up the robot!");
			other.gameObject.SetActive(false);

			saved=true;
			//successText.text = "You Escaped the First Level!";
		}
		
	}


	/*public IEnumerator Taunt()
	{
		// Check the random chance of taunting.
		float tauntChance = Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			// Wait for tauntDelay number of seconds.
			yield return new WaitForSeconds(tauntDelay);
			
			// If there is no clip currently playing.
			if(!audio.isPlaying)
			{
				// Choose a random, but different taunt.
				tauntIndex = TauntRandom();
				
				// Play the new taunt.
				audio.clip = taunts[tauntIndex];
				audio.Play();
			}
		}
	}
	
	
	int TauntRandom()
	{
		// Choose a random index of the taunts array.
		int i = Random.Range(0, taunts.Length);
		
		// If it's the same as the previous taunt...
		if(i == tauntIndex)
			// ... try another random taunt.
			return TauntRandom();
		else
			// Otherwise return this index.
			return i;
	}*/
}
