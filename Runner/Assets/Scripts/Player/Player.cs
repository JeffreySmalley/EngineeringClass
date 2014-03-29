using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool jumping;
	public float acceleration;
	public static int lives;
	public static int score;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
		if(jumping == false && acceleration <= 8)

		transform.rigidbody.AddForce (800*Time.deltaTime, 0, 0, ForceMode.Acceleration);
		acceleration = rigidbody.velocity.x;
		if (Input.GetKeyDown ("s") && jumping == false) {
			transform.localScale = new Vector3(1f,0.5f,1f);
		}
		if (Input.GetKeyUp ("s") && jumping == false) {
			transform.localScale = new Vector3(1f,1f,1f);
		}
	}
	void FixedUpdate(){
		if(Input.GetKeyDown("w") && jumping == false){
			transform.rigidbody.AddForce(Vector3.up*320*Time.deltaTime,ForceMode.VelocityChange);
			jumping = true;
		}

	}
	void OnCollisionEnter(Collision C){
		jumping = false;
		if (C.gameObject.name == "Log" || C.gameObject.name == ("Door") || C.gameObject.name == "MineshaftExit" 
		    || C.gameObject.name == "Car" && transform.position.y < 2){
			Application.LoadLevel("Level1");
		}
	}
}
