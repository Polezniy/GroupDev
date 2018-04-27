using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour {

	public Transform spawnlevelPrefab;
	public Vector3 levelPos =  new Vector3 (0, 0, 0);
	bool hasLoaded;

	// Use this for initialization
	void Start ()
	{
		hasLoaded = false;
	}

	void OnTriggerEnter(Collider col)
	{
							// change so if collider is player!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

		if (hasLoaded == false)
		{
			Debug.Log ("IN");

			Instantiate (spawnlevelPrefab, levelPos, Quaternion.identity);
			hasLoaded = true;
			Destroy (this.gameObject);
		}
	}
}
