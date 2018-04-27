using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicInteractScript : MonoBehaviour {
	
	public virtual void windMagicInteract()
	{
		//Renderer rend = gameObject.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find ("Albedo");
		//rend.material.color = Color.green;
	}

	public virtual void waterMagicInteract()
	{
		//Renderer rend = gameObject.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find ("Albedo");
		//rend.material.color = Color.green;
	}

	public virtual void earthMagicInteract()
	{
		Renderer rend = gameObject.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find ("Albedo");
		rend.material.color = Color.green;
	}

	public virtual void fireMagicInteract()
	{
		//Renderer rend = gameObject.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find ("Albedo");
		//rend.material.color = Color.green;
	}

}
