using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : magicInteractScript {

	private bool hasBeenRotated = false;
	private float rotateAmount = 39.0f;

	public override void windMagicInteract()
	{
		Debug.Log ("TreeScript IN");
		hasBeenRotated = true;
		//gameObject.transform.parent.Rotate (Vector3.forward * -39.0f);	// Rotates TreePivot (the parent)
		// Visual Effects
	}

	private void FixedUpdate()
	{

	}

	private void Update()
	{
		if (hasBeenRotated)
		{
			if (rotateAmount > 0.0f)
			{
				rotateAmount--;
				gameObject.transform.parent.Rotate (Vector3.forward * -1.0f);	// Rotates TreePivot (the parent)
			}
		}
	}
}
