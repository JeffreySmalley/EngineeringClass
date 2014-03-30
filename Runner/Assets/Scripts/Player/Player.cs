using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool jumping;
	public float acceleration;
	public static int lives;
	public static int score;

	private float gravity = 10.0f;

	private Vector3 motion = Vector3.zero;

	// Use this for initialization
	private CharacterController controller
	{
		get
		{
			return GetComponent<CharacterController>();
		}
	}
	void Start () 
	{		
	
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if(jumping == false && acceleration <= 8)

		transform.rigidbody.AddForce (800*Time.deltaTime, 0, 0, ForceMode.Acceleration);
		acceleration = rigidbody.velocity.x;
		if (Input.GetKeyDown ("s") && jumping == false) {
			transform.localScale = new Vector3(1f,0.5f,1f);
		}
		if (Input.GetKeyUp ("s") && jumping == false) {
			transform.localScale = new Vector3(1f,1f,1f);
		}
		*/
		motion.x = 800.0f*Time.deltaTime;
		motion.y -= gravity * Time.deltaTime;
		controller.Move (motion * Time.deltaTime);
	}
	void FixedUpdate(){

		if(Input.GetKeyDown("w") && /*jumping == false*/ controller.isGrounded){
			motion.y = 10.0f;
			/*
			 transform.rigidbody.AddForce(Vector3.up*320*Time.deltaTime,ForceMode.VelocityChange);
			jumping = true;
			*/
		}
	}
	void OnCollisionEnter(Collision C){
		/*
		jumping = false;
		if (C.gameObject.tag == "Obstacle" && transform.localPosition.y < 2){
			Application.LoadLevel(Application.loadedLevel);
		}
		if(C.gameObject.tag == "Exit"){
			Application.LoadLevel(Application.loadedLevel+1);
		}*/
	}
}
