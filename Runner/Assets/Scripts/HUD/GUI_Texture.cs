using UnityEngine;
using System.Collections;

public class GUI_Texture : MonoBehaviour {
	
	public Texture2D normalTex = null;
	public Texture2D overTex = null;
	public string level = "";

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
		if(overTex)
			guiTexture.texture = overTex;
		else
			Debug.Log("overTex not loaded");
	}
	
	void OnMouseExit()
	{
		if(normalTex)
			guiTexture.texture = normalTex;
		else
			Debug.Log("normalTex not loaded");
	}
	
	void OnMouseDown()
	{
		if(level.Equals("Quit"))
		{
			Application.Quit();
			Debug.Log("Quitting...");
			return;
		}
		
		Application.LoadLevel(level);
	}
}









