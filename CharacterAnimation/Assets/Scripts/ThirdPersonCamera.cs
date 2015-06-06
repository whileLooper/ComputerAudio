using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
	public float smooth = 3f;		// a public variable to adjust smoothing of camera motion
	Transform standardPos;			// the usual position for the camera, specified by a transform in the game

	// Use this for initialization
	void Start () {
		standardPos = GameObject.Find ("CamPos").transform;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, standardPos.position, Time.deltaTime * smooth);	
		transform.forward = Vector3.Lerp(transform.forward, standardPos.forward, Time.deltaTime * smooth);
	}
}
