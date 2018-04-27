using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour 
{
	static private magicInteractScript anotherScript;	//base interactScript class
	private float magicRange;
    private GameObject _umbrella;
    private GameObject _player;
    public bool _equiped;

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
            if (obj.GetComponent<magicInteractScript>() != null)
            {
                anotherScript = obj.GetComponent<magicInteractScript>();
                anotherScript.windMagicInteract();
            }

           /* if(_umbrella.activeInHierarchy == true)
            {

            }
			// Do stuff if umbrella is equipped
			// Do visual effects*/
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


	void Start ()
	{
		//currentMagic.Add (new fireMagic());
		currentMagic.Add (new windMagic());
		currentMagic.Add (new earthMagic());
		magicRange = 5.0f;
        _umbrella = GameObject.FindGameObjectWithTag("Umbrella");
        _player = GameObject.FindGameObjectWithTag("Player");
        _equiped = false;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			//Debug.Log(currentMagic.FindIndex());
			//Debug.Log(currentMagic[0]);
		}

		if (Input.GetMouseButtonDown (0))
		{
			//Vector3 point = new Vector3 (camera.pixelWidth / 2, camera.pixelHeight / 2);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) 
			{
				Debug.Log ("Hit: " + hit.collider.gameObject.name);
				GameObject hitTarget = hit.transform.gameObject;
				
				float dist = Vector3.Distance(hitTarget.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().position);
				if (dist <= magicRange)
				{
					currentMagic [0].interact (hitTarget);
				}
				//React target = hitTarget.GetComponent<React> ();
			}
		}
	}
}
