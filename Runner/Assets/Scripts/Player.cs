using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool jumping;
	public float acceleration;
	// Use this for initialization

	void Start () {
		//This is for the slopes.
		//Because of how we move, this will only do slopes within reason.
		//Anything around 45 degrees will need it's friction reduced to about 0 to reduce slowing.
		//I have created a physics material, "Ramp Material", just for this purpose!
		//Add it to the slope and everything should run smoothly up to around 60 degrees!

		collider.material.dynamicFriction = 0;
		collider.material.staticFriction = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if( acceleration <= 8)
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
		if (C.gameObject.tag == "Obstacle" && transform.localPosition.y < 2){
			Application.LoadLevel(Application.loadedLevel);
		}
		if(C.gameObject.tag == "Exit"){
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
