using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour {

    private GameObject _umbrella;
    private bool _equiped;

	// Use this for initialization
	void Start ()
    {
        _umbrella = GameObject.FindGameObjectWithTag("Umbrella");
        _equiped = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float _dist = Vector3.Distance(_umbrella.GetComponent<Transform>().position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);

        if (Input.GetKeyDown(KeyCode.E) && _equiped == true)
        {
            Debug.Log("Unequiped");
            _umbrella.GetComponent<Transform>().SetParent(null);
            _umbrella.AddComponent<Rigidbody>();


        }

        if (Input.GetKeyUp(KeyCode.E) && _equiped == true)
        {
            Debug.Log("Flag true");
            _equiped = false;

        }

        if (Input.GetKeyDown(KeyCode.E) && _dist < 1.2f && _equiped == false)
        {
            Debug.Log("Equiped");
            _umbrella.GetComponent<Transform>().SetParent(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
            _umbrella.GetComponent<Transform>().localPosition = new Vector3(0.5f, 1.0f, 0.0f);
            Destroy(_umbrella.GetComponent<Rigidbody>());
        }

        if (Input.GetKeyUp(KeyCode.E) && _equiped == false)
        {
            Debug.Log("Flag false");
            _equiped = true;
        }

    }
}
