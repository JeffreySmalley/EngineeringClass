using UnityEngine;
using System.Collections;
enum EnemyState{Idle, Stand, Dead};
public class PantherKing : Actor {
	public Rigidbody pantherProjectile;
	public GameObject finalForm;
	public Transform pantherSpawn;
	GameObject currForm;
	EnemyState state = EnemyState.Idle;
	float coolDown = 0;
	int pantherCount = 0;
	Player player;
	// Use this for initialization
	void Start () {
		Health = 50;
		currForm = transform.Find("PantherBody").gameObject;
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

		switch(state){
			case EnemyState.Idle:
				if(transform.position.x - player.transform.position.x < 20){
					Destroy(currForm);
					currForm = Instantiate(finalForm, transform.position, Quaternion.identity)as GameObject;
					currForm.transform.parent = transform;
					BoxCollider bc = gameObject.GetComponent<BoxCollider>();
					bc.size = new Vector3(1,4,2);
					bc.center = new Vector3(0.8f,0.5f,0);
					state = EnemyState.Stand;
				}
				if(pantherCount < 3){
					if(coolDown >= 15){
						Rigidbody panther;
						panther = Instantiate(pantherProjectile, pantherSpawn.position, pantherSpawn.rotation) as Rigidbody;
						panther.GetComponent<MovePlayerInRange>().detectRange = 1000;
						coolDown = 0;
						pantherCount+=1;
					}
				}
			coolDown+=5*Time.deltaTime;
			break;
			case EnemyState.Stand:
				MovePlayerInRange mpir = gameObject.AddComponent<MovePlayerInRange>();
				mpir.speed = -15; 
				mpir.detectRange = 20;
				
			if(Health <= 0){
					state = EnemyState.Dead;
				}
			break;
			case EnemyState.Dead:
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
