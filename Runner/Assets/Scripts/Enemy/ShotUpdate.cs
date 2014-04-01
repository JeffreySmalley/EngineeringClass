using UnityEngine;
using System.Collections;

public class ShotUpdate : MonoBehaviour {
	private Player player;
	Vector3 speed;
	// Use this for initialization
	void Start () {
		speed.x = -200f;
		rigidbody.AddForce (speed);
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,2);
	}
}
