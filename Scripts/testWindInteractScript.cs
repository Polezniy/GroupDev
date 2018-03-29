using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWindInteractScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		
	}

	public void windMagicInteract()
	{
		Renderer rend = gameObject.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find ("Albedo");
		rend.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
