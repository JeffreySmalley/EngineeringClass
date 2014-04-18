using UnityEngine;
using System.Collections;

public class MovePlayerInRange : MonoBehaviour {
	public Player player;
	public float speed = -1000;
	public float detectRange = 40;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x - player.transform.position.x < detectRange){
			transform.rigidbody.AddForce (speed*Time.deltaTime, 0, 0, ForceMode.Acceleration);
		}
	}
}
