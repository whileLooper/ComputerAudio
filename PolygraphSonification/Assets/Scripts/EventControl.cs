using UnityEngine;
using System.Collections;

public class EventControl : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;

	AudioSource sound1;
	AudioSource sound2;
	
	float radiationPlaybackRate = 0;
	float proximityPlaybackRate = 0;
	
	float currentSlider;
	float lastSlider;
	
	float currentTimeInSeconds;
	
	float lastSoundPlaybackTime;
	float playbackInterval = 1.5f;
	
	// Use this for initialization
	void Start () {
		//start my sound playback based on initial values

		sound1 = gameObject.GetComponent<AudioSource> ();
		sound2 = gameObject.GetComponent<AudioSource> ();

		currentTimeInSeconds = 0;
		lastSoundPlaybackTime = 0;
		sound1.clip = clip1;
		sound2.clip = clip2;
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeInSeconds = currentTimeInSeconds + Time.deltaTime;
		//Debug.Log ("Current time: " + currentTimeInSeconds);
		float timeSinceLastSoundPlayback = currentTimeInSeconds - lastSoundPlaybackTime;
		if (timeSinceLastSoundPlayback > playbackInterval) {
			Debug.Log ("Play back interval: " + playbackInterval);
			Debug.Log ("Played sound at " + timeSinceLastSoundPlayback + " second(s).");
			lastSoundPlaybackTime = currentTimeInSeconds;
			sound1.Play ();
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
		sound1.pitch = sliderValue;
	}
}
