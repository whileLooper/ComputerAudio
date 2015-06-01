using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMangager : MonoBehaviour {
	public Slider timeSlider;
	public Text timer;
	public Button PlayButton;
	public Slider volumeSlider;
	public AudioClip[] songs;
	AudioSource sourcePlayer;

	bool isPause = false;
	bool isStop = false;

	int currentClip = 0;
	
	// Use this for initialization
	void Start () {
		sourcePlayer = gameObject.AddComponent<AudioSource> ();
		sourcePlayer.clip = songs[currentClip];	//set default track
		sourcePlayer.volume = 0.5f;
	}

	void Update(){
		timeSlider.value = sourcePlayer.time/sourcePlayer.clip.length*timeSlider.maxValue;
		timer.text = Mathf.Floor(sourcePlayer.time / 60) + ":" + Mathf.Floor (sourcePlayer.time - (Mathf.Floor(sourcePlayer.time / 60)*60)).ToString ("00") + " / " 
			+ Mathf.Floor(sourcePlayer.clip.length / 60) + ":" + Mathf.Floor(sourcePlayer.clip.length - (Mathf.Floor(sourcePlayer.clip.length / 60)*60)).ToString ("00");
		sourcePlayer.volume = volumeSlider.value;
		if (sourcePlayer.isPlaying) {
			PlayButton.enabled = false;
		}
		else {
			PlayButton.enabled = true;
		}
		//auto play next
		if (Mathf.Floor(sourcePlayer.time) == Mathf.Floor(sourcePlayer.clip.length)) {
			if(currentClip != 3) currentClip++;
			else currentClip = 0;
			sourcePlayer.clip = songs[currentClip];
			sourcePlayer.time = 0;
			sourcePlayer.Play();
		}
	}
	
	//Play: Starts playback of the currently selected track/file from its current playback position.
	public void Play(){
		if (!sourcePlayer.isPlaying) {
			sourcePlayer.Play ();
			isStop = false;
			isPause = false;
		}

	}

	//Stop: Stops playback of the currently selected track/file. If played again, it should resume where it left off.
	public void Stop(){
		sourcePlayer.Pause ();
		if(!isPause && sourcePlayer.isPlaying){
			isPause = !isPause;
		}
		isStop = true;
		sourcePlayer.pitch = 1;
	}

	//Pause: Stops playback of the currently selected track/file, 
	//then resumes where it left off when pressed again.
	public void Pause(){
		if (sourcePlayer.isPlaying) {
			sourcePlayer.Pause ();
		}
		else{
			sourcePlayer.UnPause();
		}
		isPause = !isPause;
	}

	//Plays the current track forwards at a fast rate of speed until it 
	//reaches the end of the file or the STOP button is pressed.
	public void Forward(){
		if (sourcePlayer.isPlaying) {
			if (sourcePlayer.pitch + 1 > 5) {
				sourcePlayer.pitch = 1;
				return;
			}
			sourcePlayer.pitch ++;
		}
	}

	//Switches from the current track/file to the next one
	public void Next(){
		if (currentClip != 3)
			currentClip ++;
		else
			currentClip = 0;

		float tempTime = sourcePlayer.time;
		sourcePlayer.clip = songs [currentClip];
		if (tempTime > sourcePlayer.clip.length) {
			tempTime = 0f;
		}
		sourcePlayer.time = tempTime;
		Play ();
	}

	//Switches from the current track to previous one
	public void Previous(){
		if (currentClip == 0)
			currentClip = 3;
		else
			currentClip --;
		float tempTime = sourcePlayer.time;
		sourcePlayer.clip = songs [currentClip];
		if (tempTime > sourcePlayer.clip.length)
			tempTime = 0f;
		sourcePlayer.time = tempTime;
		Play ();
	}

	//Resets the playback position of the audio player to the beginning
	public void Reset(){
		sourcePlayer.Stop ();
		sourcePlayer.time = 0;
		Play ();
	}

}
