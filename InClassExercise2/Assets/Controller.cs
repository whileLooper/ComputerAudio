using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public AudioSource[] sources;
	public Slider HeartRateSlider, RespirationRateSlider, HeartVolumeSlider, RespirationVolumeSlider, GSRSlider, TruthfulSlider, LyingSlider;
	AudioSource heartBeat, respirationIn, respirationOut, gsrAlert, truthAlert, lieAlert;
	
	float currentTimeInSeconds;
	
	float lastHeartPlayTime;
	float lastRespirationPlayTime;

	float heartRate = 1.5f;
	float respirationRate = 3f;

	bool first = true, gsrOneAlert = false, gsrCount = false, truthCount = false, lieCount = false, truthOneAlert = false, lieOneAlert = false;
	
	// Use this for initialization
	void Start () {
		//start my sound playback based on initial values
		
		currentTimeInSeconds = 0;
		lastHeartPlayTime = 0;
		lastRespirationPlayTime = 0;
		heartBeat = sources [0];
		respirationIn = sources [1];
		respirationOut = sources [2];
		gsrAlert = sources [3];
		truthAlert = sources [4];
		lieAlert = sources [5];
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeInSeconds = currentTimeInSeconds + Time.deltaTime;
		//Debug.Log ("Current time: " + currentTimeInSeconds);
		float heartTimeSinceLastSoundPlayback = currentTimeInSeconds - lastHeartPlayTime;
		float respirationTimeSinceLastSoundPlayback = currentTimeInSeconds - lastRespirationPlayTime;
		if (heartTimeSinceLastSoundPlayback > heartRate) {
			lastHeartPlayTime = currentTimeInSeconds;
			heartBeat.Play ();
		}
		if (respirationTimeSinceLastSoundPlayback > respirationRate/2) {
			lastRespirationPlayTime = currentTimeInSeconds;
			if (first) {
				respirationIn.Play();
			} else {
				respirationOut.Play();
			}
			first = !first;
		}

		// GSR
		if (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value*3) >= 0.5f && !gsrCount) {
			gsrOneAlert = true;
			gsrCount = true;
		}
		if (gsrOneAlert) {
			gsrAlert.Play ();
			gsrOneAlert = false;
		}

		if (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) < 0.5f) {
			gsrCount = false;
		}

		// Truth
		if (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) <= 0.1f && !truthCount && RespirationRateSlider.value >= 2f) {
			truthOneAlert = true;
			truthCount = true;
		}
		if (truthOneAlert) {
			truthAlert.Play ();
			truthOneAlert = false;
		}
		if (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) > 0.1f || RespirationRateSlider.value < 2f) {
			truthCount = false;
		}

		if (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) >= 1.3f && !lieCount && HeartRateSlider.value < 0.4f && RespirationRateSlider.value > 2.5f) {
			lieOneAlert = true;
			lieCount = true;
		}
		if (lieOneAlert) {
			lieAlert.Play ();
			lieOneAlert = false;
		}
		if (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) < 1.3f && !lieCount || HeartRateSlider.value > 0.4f || RespirationRateSlider.value < 2.5f) {
			lieCount = false;
		}
	}
	
	public void OnHeartRateChange()
	{
		heartRate = HeartRateSlider.value;
		Debug.Log (HeartRateSlider.value);
	}
	
	public void OnRespirationRateChange()
	{
		respirationRate = RespirationRateSlider.value;
	}

	public void OnHeartVolumeChange() {
		heartBeat.volume = HeartVolumeSlider.value;
	}

	public void OnRespirationVolumeChange() {
		respirationIn.volume = RespirationVolumeSlider.value;
		respirationOut.volume = RespirationVolumeSlider.value;
	}

	public void OnGSRChange() {
		gsrAlert.volume = GSRSlider.value;
	}

	public void ActivateGSR() {
		HeartRateSlider.value = Random.Range (0.2f, 0.48f);
		float random = Random.Range (0.0f, 1.0f);
		OnHeartRateChange ();
		if (random <= 0.5f) {
			RespirationRateSlider.value = Random.Range (HeartRateSlider.value * 3 + 0.500001f, 3f);
		} else {
			RespirationRateSlider.value = Random.Range (0.11f, HeartRateSlider.value * 3 - 0.500001f);
		}
		OnRespirationRateChange ();
		GSRSlider.value = (Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value) / 2.7f);
		Debug.Log ("ActivateGSR " + RespirationRateSlider.value);
		Debug.Log ("ActivateGSR " + HeartRateSlider.value);
		Debug.Log ("ActivateGSR " + Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value) / 2.7f);
	}

	public void OnTruthfulChange() {
		truthAlert.volume = TruthfulSlider.value;
	}

	public void ActivateCalm() {
		HeartRateSlider.value = Random.Range (0.9f, 1f);
		OnHeartRateChange ();
		RespirationRateSlider.value = Random.Range (2.6f, 3f);
		OnRespirationRateChange ();
	}

	public void OnExcitedTrue() {
		HeartRateSlider.value = Random.Range (0.6f, 0.9f);
		OnHeartRateChange ();
		float random = Random.Range (0.0f, 1.0f);
		if (random <= 0.5f) {
			RespirationRateSlider.value = Random.Range (HeartRateSlider.value * 3, HeartRateSlider.value * 3 + 0.09999f);
		} else {
			RespirationRateSlider.value = Random.Range (HeartRateSlider.value * 3 - 0.09999f, HeartRateSlider.value * 3);
		}
		OnRespirationRateChange ();
		TruthfulSlider.value = 1f - Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) * 10;

	}

	public void OnExcitedLie() {
		HeartRateSlider.value = Random.Range (0.1f, 0.4f);
		OnHeartRateChange ();
		RespirationRateSlider.value = Random.Range (2.5f, 3.0f);
		OnRespirationRateChange ();
		LyingSlider.value = Mathf.Abs (RespirationRateSlider.value - HeartRateSlider.value * 3) / 1.4f - (1.3f / 1.4f);
		Debug.Log ("Respiration: " + RespirationRateSlider.value);
		Debug.Log ("Heart Rate: " + HeartRateSlider.value * 3);
		Debug.Log (LyingSlider.value);
	}

	public void OnLieChange() {
		lieAlert.volume = LyingSlider.value;
	}
}
