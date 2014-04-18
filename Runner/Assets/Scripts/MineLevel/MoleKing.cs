using UnityEngine;
using System.Collections;
enum MoleState{Idle, Stand, Dead};
public class MoleKing : Actor {
	public Rigidbody moleProjectile;
	public Transform moleSpawn;
	MoleState state = MoleState.Idle;
	float coolDown = 0;
	int moleCount = 0;
	Player player;
	// Use this for initialization
	void Start () {
		Health = 50;
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
		case MoleState.Idle:
			if(transform.position.x - player.transform.position.x < 20){

				state = MoleState.Stand;
			}
			if(moleCount < 3){
				if(coolDown >= 15){
					Rigidbody mole;
					mole = Instantiate(moleProjectile, moleSpawn.position, moleSpawn.rotation) as Rigidbody;
					mole.GetComponent<MovePlayerInRange>().detectRange = 1000;
					coolDown = 0;
					moleCount+=1;
				}
			}
			coolDown+=5*Time.deltaTime;
			break;
		case MoleState.Stand:
			MovePlayerInRange mpir = gameObject.AddComponent<MovePlayerInRange>();
			mpir.speed = -15; 
			mpir.detectRange = 20;
			
			if(Health <= 0){
				state = MoleState.Dead;
			}
			break;
		case MoleState.Dead:
			transform.Rotate(0,0,90);
			Application.LoadLevel(Application.loadedLevel+1);
			break;
		}
	}
	void OnCollisionEnter(Collision C){
		if (C.gameObject.tag == "Bullet"){
			Health -= 10;
			Destroy(C.gameObject);
		}
	}
}
