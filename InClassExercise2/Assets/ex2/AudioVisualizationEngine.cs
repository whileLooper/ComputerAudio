using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))] //adds an AudioSource automatically when this script is added to a GameObject
public class AudioVisualizationEngine : MonoBehaviour {
	
	public GameObject vizLeft;
	public GameObject vizRight;
	
	Transform leftTransform;
	Transform rightTransform;
	
	public int bufferSize = 1024; //values must be a power of 2
	public FFTWindow windowingFunction = FFTWindow.Blackman;
	
	float[] spectrumData;
	AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		//getting the transforms so we can manipulate their localScale in Update()
		leftTransform = vizLeft.transform;
		rightTransform = vizRight.transform;

		audioSrc = GetComponent<AudioSource> ();
		//initialize your spectrumData array and obtain the frequency range of the current audio.clip here
		//(hint: recall the Nyquist Frequency)
		spectrumData = new float[bufferSize];
	}
	
	// Update is called once per frame
	void Update () {
		audioSrc.GetSpectrumData(spectrumData, 0, windowingFunction);

		float bassY = 0;
		float snareY = 0;

		for (int i = 0; i < 15; i++) {
			bassY += spectrumData[i];
		}
		snareY = spectrumData[55]-spectrumData[70];

		float bassYScale = bassY * 15; //change this to respond to the frequencies from the bass drum
		float snareYScale = snareY * 300; //change this to respond to the frequencies from the snare drum

		leftTransform.localScale = new Vector3(1, bassYScale, 1);
		rightTransform.localScale = new Vector3(1, snareYScale, 1);

	}

}
