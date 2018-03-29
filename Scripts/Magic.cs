using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour 
{

	protected class baseMagic
	{
		public virtual void interact (GameObject obj)
		{
			
		}
	}

	class windMagic : baseMagic
	{
		public override void interact (GameObject obj)
		{
			obj.SendMessage ("windMagicInteract");
		}
	}
	class waterMagic : baseMagic
	{
		public override void interact (GameObject obj)
		{

		}
	}
	class earthMagic : baseMagic
	{
		public override void interact (GameObject obj)
		{

		}
	}
	class fireMagic : baseMagic
	{
		public override void interact (GameObject obj)
		{

		}
	}

	List<baseMagic> currentMagic = new List<baseMagic>();

	// Use this for initialization
	void Start ()
	{
		currentMagic.Add (new windMagic());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			//Vector3 point = new Vector3 (camera.pixelWidth / 2, camera.pixelHeight / 2);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) 
			{
				Debug.Log ("Hit: " + hit.collider.gameObject.name);
				GameObject hitTarget = hit.transform.gameObject;

				currentMagic [0].interact (hitTarget);

				//React target = hitTarget.GetComponent<React> ();

				//if(target!=null)
				//	Destroy(hitTarget);

			}
		}
	}
}
