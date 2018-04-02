using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWindInteractScript : MonoBehaviour {
	
	public virtual void windMagicInteract()
	{
		Renderer rend = gameObject.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find ("Albedo");
		rend.material.color = Color.green;
	}
}
