﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, new Vector3(desiredPosition.x, desiredPosition.y, offset.z), smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
