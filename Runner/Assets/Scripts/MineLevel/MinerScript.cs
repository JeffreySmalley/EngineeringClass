using UnityEngine;
using System.Collections;

public class MinerScript : MonoBehaviour {
	public Player player;
	bool animationComplete = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x - player.transform.position.x < 10 && animationComplete == false){
			transform.Rotate(-90,0,0);
			animationComplete = true;
		}
	}
}
