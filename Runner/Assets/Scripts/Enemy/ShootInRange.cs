using UnityEngine;
using System.Collections;

public class ShootInRange : MonoBehaviour {
	private float timer = 2.0f;
	public GameObject shot;
	public Player player;
	private Vector3 loc;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		loc = transform.position;
		loc.x -= 0.5f;
		if (player.transform.position.x > transform.position.x+40 && player.transform.position.x < transform.position.x -40) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				Instantiate (shot, loc, transform.rotation);
				timer = 2f;
			}
		}
	}
}
