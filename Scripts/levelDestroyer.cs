using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelDestroyer : MonoBehaviour {

	public string destroyLevelPrefab;

	void OnTriggerEnter(Collider col)
	{
		Destroy(GameObject.FindGameObjectWithTag(destroyLevelPrefab));
		Destroy (this.gameObject);
	}
}
