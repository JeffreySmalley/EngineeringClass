using UnityEngine;
using System.Collections;

public class KidScript : MonoBehaviour {
	public Player player;
	bool rotated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x - player.transform.position.x < -1 && rotated == false){
			transform.Rotate(90,0,0);
			transform.Translate(0,0,0.4f);
			rotated = true;
		}
	}
}
