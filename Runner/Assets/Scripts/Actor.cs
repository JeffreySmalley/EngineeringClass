using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	public float Health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void DeathCheck(){
		if(Health <= 0){
			if(this.name == "Player")
				Application.LoadLevel(Application.loadedLevel);

		}
	}
	void takeDamage(float num){
		Health -=  num;

	}

}
