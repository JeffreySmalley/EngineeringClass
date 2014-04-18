using UnityEngine;
using System.Collections;
enum PlayerState{Run, Jump, Duck};
public class Player :  Actor {
	public bool jumping;
	public float acceleration;
	public Rigidbody projectile;
	public Transform bulletSpawn;
	// Use this for initialization
	PlayerState state = PlayerState.Run;
	public bool isBossFight=false;
	void Start () {
		//This is for the slopes.
		//Because of how we move, this will only do slopes within reason.
		//Anything around 45 degrees will need it's friction reduced to about 0 to reduce slowing.
		//I have created a physics material, "Ramp Material", just for this purpose!
		//Add it to the slope and everything should run smoothly up to around 60 degrees!
		Health = 50;
		collider.material.dynamicFriction = 0;
		collider.material.staticFriction = 0;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown ("s")) {

			state = PlayerState.Duck;

		}
		if (Input.GetKeyUp ("s")) {

			state = PlayerState.Run;
		}
		switch(state){
			case PlayerState.Run:
				if(isBossFight){
					if( acceleration <= 8){
						float h = Input.GetAxis("Horizontal");
						transform.rigidbody.AddForce (800*h*Time.deltaTime, 0, 0, ForceMode.Acceleration);
					}
					
					transform.localScale = new Vector3(1f,1f,1f);
				}
				if(isBossFight == false){
					if( acceleration <= 8)
						transform.rigidbody.AddForce (800*Time.deltaTime, 0, 0, ForceMode.Acceleration);
					transform.localScale = new Vector3(1f,1f,1f);
				}
				break;
			case PlayerState.Jump:
				if(jumping == false)state = PlayerState.Run;
				break;
			case PlayerState.Duck:
				transform.localScale = new Vector3(1f,0.5f,1f);
				break;

		}
		if(Input.GetKeyDown("space")){
			
			Rigidbody bullet = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody;
			bullet.rigidbody.AddForce(800*Time.deltaTime, 0, 0, ForceMode.Impulse);
			Physics.IgnoreCollision(bullet.collider, collider);
		}
		acceleration = rigidbody.velocity.x;
		DeathCheck();
	}
	void FixedUpdate(){

		if(Input.GetKeyDown("w") && jumping == false && state != PlayerState.Duck){
			transform.rigidbody.AddForce(Vector3.up*320*Time.deltaTime,ForceMode.VelocityChange);
			jumping = true;
			state = PlayerState.Jump;
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
		if (C.gameObject.tag == "Bullet"){
			Health -= 10;
			Destroy(C.gameObject);
		}
	}
}
