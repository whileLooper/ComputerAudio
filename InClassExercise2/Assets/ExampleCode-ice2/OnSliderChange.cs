using UnityEngine;
using System.Collections;

public class OnSliderChange : MonoBehaviour {

	AudioSource sound;

	float radiationPlaybackRate = 0;
	float proximityPlaybackRate = 0;

	float currentSlider;
	float lastSlider;

	float currentTimeInSeconds;

	float lastSoundPlaybackTime;
	public float playbackInterval = 2.0f;

	// Use this for initialization
	void Start () {
		//start my sound playback based on initial values

		currentTimeInSeconds = 0;
		lastSoundPlaybackTime = 0;
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeInSeconds = currentTimeInSeconds + Time.deltaTime;
		//Debug.Log ("Current time: " + currentTimeInSeconds);
		float timeSinceLastSoundPlayback = currentTimeInSeconds - lastSoundPlaybackTime;
		if (timeSinceLastSoundPlayback > playbackInterval)
		{
			Debug.Log ("Played sound at " + timeSinceLastSoundPlayback + " second(s).");
			lastSoundPlaybackTime = currentTimeInSeconds;
			sound.Play();
		}	
	}

	public void OnRadiationCountChange(float sliderValue)
	{
		radiationPlaybackRate = sliderValue;
		Debug.Log ("Radiation: " + radiationPlaybackRate);
		playbackInterval = sliderValue;

	}

	public void OnProximityValueChange(float sliderValue)
	{
		proximityPlaybackRate = sliderValue;
		Debug.Log ("Proximity: " + proximityPlaybackRate);
		sound.pitch = sliderValue;
	}
}
