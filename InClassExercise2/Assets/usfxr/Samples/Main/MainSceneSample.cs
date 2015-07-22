using UnityEngine;
using System.Collections;

public class MainSceneSample : MonoBehaviour {

	private SfxrSynth synthA;
	private SfxrSynth synthB;
	private SfxrSynth synthC;
	private SfxrSynth synthD;
	private SfxrSynth synthE;

	void Start () {
	    Debug.Log("Initialized");
    }
	
	void Update () {
		if (Input.GetKeyDown("a")) {
			Debug.Log("Key: A (Unsafe)");

			if (synthA == null) {
				// Coin
				synthA = new SfxrSynth();
				synthA.parameters.SetSettingsString(",0.5,0.605,0.605,,0.52,0.3,0.61,,0.3437,,0.515,,,,,,,,,0.19,-0.625,0.105,,,1,-1,,,-1,,-0.99,masterVolume");
				synthA.CacheSound();
			}

			synthA.Play();
		}
		if (Input.GetKeyDown("b")) {
			Debug.Log("Key: B (It is a stop sign alert)");

			if (synthB == null) {
				// Coin
				synthB = new SfxrSynth();
				synthB.parameters.SetSettingsString("1,0.5,0.61,0.695,0.3668,0.82,0.8439,0.1851,,,-0.0016,0.0031,0.6771,0.0782,0.8993,0.6537,0.1491,0.3793,0.3631,0.8622,0.1126,0.353,0.795,-0.8718,-0.7203,0.9798,-0.9682,0.6723,0.8075,0.912,0.0101,-0.9999,masterVolume");
			}

			synthB.Play();
		}
		if (Input.GetKeyDown("c")) {
			Debug.Log("Key: C (It is a counting alert )");

			if (synthC == null) {
				// Laser
				synthC = new SfxrSynth();
				synthC.parameters.SetSettingsString(",0.5,0.1326,0.0473,0.51,0.105,0.3,0.4364,,,,,,,,,,,,,,,,,,1,,,,,,,masterVolume");
				synthC.SetParentTransform(Camera.main.transform);

			}

			synthC.PlayMutated();
		}
	}

	public void PressA() {
		Debug.Log("Key: A (Unsafe)");

		if (synthA == null) {
			// Coin
			synthA = new SfxrSynth();
			synthA.parameters.SetSettingsString(",0.5,0.605,0.605,,0.52,0.3,0.61,,0.3437,,0.515,,,,,,,,,0.19,-0.625,0.105,,,1,-1,,,-1,,-0.99,masterVolume");
			synthA.CacheSound();
		}
		
		synthA.Play();
	}

	public void PressB() {
		Debug.Log("Key: B (It is a stop sign alert)");

		if (synthB == null) {
			// Coin
			synthB = new SfxrSynth();
			synthB.parameters.SetSettingsString("1,0.5,0.61,0.695,0.3668,0.82,0.8439,0.1851,,,-0.0016,0.0031,0.6771,0.0782,0.8993,0.6537,0.1491,0.3793,0.3631,0.8622,0.1126,0.353,0.795,-0.8718,-0.7203,0.9798,-0.9682,0.6723,0.8075,0.912,0.0101,-0.9999,masterVolume");
		}
		
		synthB.Play();
	}

	public void PressC(){
		Debug.Log("Key: C (It is a counting alert )");
		
		if (synthC == null) {
			// Laser
			synthC = new SfxrSynth();
			synthC.parameters.SetSettingsString(",0.5,0.1326,0.0473,0.51,0.105,0.3,0.4364,,,,,,,,,,,,,,,,,,1,,,,,,,masterVolume");
			synthC.SetParentTransform(Camera.main.transform);
			
		}
		
		synthC.PlayMutated();
	}

}