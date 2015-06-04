using UnityEngine;
using System.Collections;

public class BotControlScript : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", v);
		anim.SetFloat ("Direction", h);
	}
}
