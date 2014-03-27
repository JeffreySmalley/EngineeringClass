using UnityEngine;
using System.Collections;

public class MovePlayerInRange : MonoBehaviour {
	public Player player;
	public float speed = -1000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x - player.transform.position.x < 40){
			transform.rigidbody.AddForce (speed*Time.deltaTime, 0, 0, ForceMode.Acceleration);
		}
	}
}
