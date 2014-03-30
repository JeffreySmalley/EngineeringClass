using UnityEngine;
using System.Collections;

public class FallingBoulder : MonoBehaviour {
	public Player player;
	bool animationComplete = false;
	// Use this for initialization
	void Start () {
		rigidbody.Sleep();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x - player.transform.position.x < 5 && animationComplete == false){
			rigidbody.WakeUp();
			animationComplete = true;
		}
	}
}
