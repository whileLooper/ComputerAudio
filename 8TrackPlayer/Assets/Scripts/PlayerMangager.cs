using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMangager : MonoBehaviour {
	public Slider timeSlider;
	public Text timer;
	public Button volumeButton;
	public Slider volumeSlider;

	public AudioClip[] songs;
	AudioSource sourcePlayer;

	bool isPlaying = false;
	bool isMuted = false;


	// Use this for initialization
	void Start () {
		sourcePlayer = gameObject.AddComponent<AudioSource> ();
		sourcePlayer.clip = songs[0];	//set default track
		sourcePlayer.volume = 0.5f;
	}

	void Update(){
		timeSlider.value = sourcePlayer.time/sourcePlayer.clip.length*timeSlider.maxValue;
		timer.text = " " + (int)(sourcePlayer.time / 60) + ":" + (int)(sourcePlayer.time % 60);
		sourcePlayer.volume = volumeSlider.value;
	}
	
	//Play: Starts playback of the currently selected track/file from its current playback position.
	public void Play(){
		if (!isPlaying) {
			sourcePlayer.Play ();
			isPlaying = true;
		}
	}

	//Stop: Stops playback of the currently selected track/file. If played again, it should resume where it left off.
	public void Stop(){
		sourcePlayer.Pause ();
		isPlaying = false;

	}

	//Pause: Stops playback of the currently selected track/file, 
	//then resumes where it left off when pressed again.
	public void Pause(){
		if (isPlaying) {
			sourcePlayer.Pause ();
			isPlaying = false;
		}
		else{
			sourcePlayer.Play();
			isPlaying = true;
		}
	}

	//Plays the current track forwards at a fast rate of speed until it 
	//reaches the end of the file or the STOP button is pressed.
	public void Forward(){
		if (isPlaying) {
			if (sourcePlayer.pitch + 1 > 5) {
				sourcePlayer.pitch = 1;
				return;
			}
			sourcePlayer.pitch ++;
		}
	}

	//Switches from the current track/file to the next one
	public void Next(){

	}

	//Resets the playback position of the audio player to the beginning
	public void Reset(){

	}

	// Slider that controls the volume of playback
	public void Mute(){
		if (!isMuted) {
			volumeButton.interactable = false;
		} else {
			volumeButton.interactable = true;
		}
	}

	public void Volume(){
		 
	}
}
