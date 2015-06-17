using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventControl : MonoBehaviour {


	public Slider heartRateSlider, respPitchSlider, heartVolumeSlider, respVolumeSlider, GSRSlider, truthSlider, lieSlider;
	public AudioSource[] clip;
	AudioSource heartBeat, respiration, gsrAlert, truthAlert, lieAlert;

	float currentTime, lastHeartTime, lastRespTime;

	float heartRate = 1.5f;
	float respRate = 1f;

	bool isGsr = false;
	bool gsrCount = false;
	bool truthCount = false;
	bool lieCount = false;
	bool isTruth = false;
	bool isLie = false;

	// Use this for initialization
	void Start () {
		//start my sound playback based on initial values
	
		currentTime = 0;
		lastHeartTime = 0;
		lastRespTime = 0;

		heartBeat = clip [0];
		respiration = clip [1];
		gsrAlert = clip [2];
		truthAlert = clip [3];
		lieAlert = clip [4];
	}
	
	// Update is called once per frame
	void Update () {

		currentTime = currentTime + Time.deltaTime;
		float timeSinceLastSoundPlayback = currentTime - lastHeartTime;
		float timeSinceLastSoundPlayback2 = currentTime - lastRespTime;

		if (timeSinceLastSoundPlayback > heartRate)
		{
			//Debug.Log ("Played sound at " + timeSinceLastSoundPlayback + " second(s).");
			lastHeartTime = currentTime;
			heartBeat.Play();
		}
		if (timeSinceLastSoundPlayback2 > respRate) {
			Debug.Log ("Played sound at " + timeSinceLastSoundPlayback2 + " second(s).");

			lastRespTime = currentTime;
			respiration.Play();
		}

		if (Mathf.Abs (respPitchSlider.value - heartRateSlider.value*2.5f) > 1f 
		    	&& !gsrCount) {
			isGsr = true;
			gsrCount = true;
		}		
		if (Mathf.Abs (respPitchSlider.value - heartRateSlider.value * 2.5f) < 0.5f) {
			gsrCount = false;
		}		
		if (Mathf.Abs (respPitchSlider.value - heartRateSlider.value * 2.5f) <= 0.1f 
		    && !truthCount && respPitchSlider.value >= 1.3f) {
			isTruth = true;
			truthCount = true;
		}

		if (Mathf.Abs (respPitchSlider.value - heartRateSlider.value * 2.5f) > 0.1f 
		    || respPitchSlider.value < 2f) {
			truthCount = false;
		}
		
		if (Mathf.Abs (respPitchSlider.value - heartRateSlider.value * 2.5f) >= 1.3f 
		    && !lieCount && heartRateSlider.value < 0.4f 
		    && respPitchSlider.value > 2.5f) {
			isLie = true;
			lieCount = true;
		}
		if (Mathf.Abs (respPitchSlider.value - heartRateSlider.value * 2.5f) < 1.2f 
		    && !lieCount || heartRateSlider.value > 0.5f 
		    || respPitchSlider.value < 2.5f) {
			lieCount = false;
		}
		if (isGsr) {
			gsrAlert.Play ();
			isGsr = false;
		}
		if (isTruth) {
			truthAlert.Play ();
			isTruth = false;
		}
		if (isLie) {
			lieAlert.Play ();
			isLie = false;
		}
	}

	public void heartBeatVolume(float sliderValue){
		heartBeat.volume = sliderValue;
	}
	public void heartRatePitch(float sliderValue){
		heartBeat.pitch = sliderValue;
	}
	public void respVolume(float sliderValue){
		respiration.volume = sliderValue;
	}
	public void respPicth(float sliderValue){
		respiration.pitch = sliderValue;
	}
	public void gsrAlertVolume(float sliderValue){
		gsrAlert.volume = sliderValue;
	}
	public void truthAlertVolume(float sliderValue){
		truthAlert.volume = sliderValue;
	}
	public void lieAlertVolume(float sliderValue){
		lieAlert.volume = sliderValue;
	}

	//calm
	public void calmButton() {
		heartRateSlider.value = Random.Range (0.2f, 0.5f);
		respPitchSlider.value = Random.Range (0.6f, 1.6f);
	}

	public void  ExcitedTrue() {
		heartRateSlider.value =  Random.Range (0.5f, 0.8f);
		float random = Random.Range (0.0f, 1.0f);
		if (random <= 0.5f) {
			respPitchSlider.value = Random.Range (heartRateSlider.value * 3f, heartRateSlider.value * 3f + 0.01f);
		} else {
			respPitchSlider.value = Random.Range (heartRateSlider.value * 3f - 0.1f, heartRateSlider.value * 3f);
		}
		truthSlider.value = 0.4f;
	}

	public void ExcitedLie() {
		heartRateSlider.value = Random.Range (0.1f, 0.3f);
		respPitchSlider.value = Random.Range (2.8f, 3.0f);
		lieSlider.value = 0.8f;
	}

	public void Moderate() {
		heartRateSlider.value = Random.Range (0.2f, 0.4f);
		float random = Random.Range (0.0f, 1.0f);
		if (random <= 0.5f) {
			respPitchSlider.value = Random.Range (1.5f, 3f);
		} else {
			respPitchSlider.value = Random.Range (0.11f, 1.4f);
		}
		GSRSlider.value = 0.6f;
	}
}
