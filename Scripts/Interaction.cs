using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

	public Transform trans; //Stone spawn position
	public bool carying; //flag to indicate if object is picked up
	public Rigidbody rockPrefab; 
	public Rigidbody rockInst;
	private GameObject player; 
	private Camera view;

	// Use this for initialization
	void Start () 
	{
		view = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		carying = false;
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 point = Input.mousePosition;

		Ray ray = view.ScreenPointToRay (point);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) 
		{
			float dist = Vector3.Distance (hit.transform.gameObject.GetComponent<Transform>().position, player.GetComponent<Transform>().position);//distance between player and stone

			if (hit.collider.gameObject.tag == "Rock")
			{
				Debug.Log ("STONE"); //DEBUG PURPOSES

				if (Input.GetKeyDown(KeyCode.E)&& dist < 1.4f) 
				{
					Destroy (hit.collider.gameObject);

					carying = true;//flag
				}

			}

			///WORK IN PROGRESS//
			if (hit.collider.gameObject.tag == "RockPile") 
			{
				Debug.Log ("RockPile");

				if (Input.GetKeyDown (KeyCode.E))
				{
					Debug.Log ("Spawned a rock");
				}
			}
			///WORK IN PROGRESS//
		}

		if (Input.GetMouseButtonDown (1)&&carying != false) 
		{
			//FINAL//
			rockInst = Instantiate (rockPrefab, trans.position, trans.rotation) as Rigidbody;
			rockInst.AddForce (trans.forward * 150);//THROWING

			carying = false;

		}


	}
}
