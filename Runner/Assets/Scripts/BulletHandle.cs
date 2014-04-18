using UnityEngine;
using System.Collections;

public class BulletHandle : MonoBehaviour {
	float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time+=5*Time.deltaTime;
		if(time >= 10)Destroy (gameObject);
	}
}
