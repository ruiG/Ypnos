using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

	protected Animator animationOnMusic;
	protected Animator animationOffMusic;
	protected Animator animationNoobDif;
	protected Animator animationNormalDif;
	protected Animator animationWindow;
	protected Animator animationFullscreen;
	protected Animator animationMusic;
	protected Animator animationVolume;
	protected Animator animationDifficulty;
	protected Animator animationMode;
	protected Animator animationApply;
	protected Animator animationCancel;
	protected AudioSource musicAudio;
	protected UnityEngine.UI.Slider volume;
	
	private float timer = 0.2f;

	// Use this for initialization
	void Start () {
		animationOnMusic = GameObject.Find("On_Music").GetComponent<Animator >();
		animationOffMusic = GameObject.Find("Off_Music").GetComponent<Animator >();
		animationNoobDif = GameObject.Find("Noob").GetComponent<Animator >();
		animationNormalDif = GameObject.Find("Normal").GetComponent<Animator >();
		animationWindow = GameObject.Find("Window").GetComponent<Animator >();
		animationFullscreen = GameObject.Find("Fullscreen").GetComponent<Animator >();
		animationMusic = GameObject.Find("Music").GetComponent<Animator >();
		animationVolume = GameObject.Find("Volume").GetComponent<Animator >();
		animationDifficulty = GameObject.Find("Difficulty").GetComponent<Animator >();
		animationMode = GameObject.Find("Mode").GetComponent<Animator >();
		animationApply = GameObject.Find("Apply").GetComponent<Animator >();
		animationCancel = GameObject.Find("Cancel").GetComponent<Animator >();
		musicAudio = GameObject.Find("Main Camera").GetComponent<AudioSource >();
		volume = GameObject.Find("Slider").GetComponent<UnityEngine.UI.Slider >();
		animationMusic.SetBool("selectedMusic", true);
		animationOnMusic.SetBool("selectedOnMusic", true);
		animationNoobDif.SetBool("selectedNoob", true);
		animationWindow.SetBool("selectedWindow", true);

		LoadOptions ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			if (animationMusic.GetBool ("selectedMusic")) {
				Debug.Log ("Music Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					animationMusic.SetBool ("selectedMusic", false);
					animationCancel.SetBool ("selectCancel", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					animationMusic.SetBool ("selectedMusic", false);
					animationVolume.SetBool ("selectedVolume", true);
				} else if(Input.GetAxis ("Horizontal") < 0){
					animationOnMusic.SetBool ("selectedOnMusic", true);
					animationOffMusic.SetBool ("selectedOffMusic", false);
				} else if(Input.GetAxis ("Horizontal") > 0){
					animationOffMusic.SetBool ("selectedOffMusic", true);
					animationOnMusic.SetBool ("selectedOnMusic", false);
				}
				if(animationOnMusic.GetBool("selectedOnMusic"))
				{
					musicAudio.mute = false;
				} else if(animationOffMusic.GetBool("selectedOffMusic"))
				{
					musicAudio.mute = true;
				}

			} else if (animationVolume.GetBool ("selectedVolume")) {
				Debug.Log ("Volume Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					animationVolume.SetBool ("selectedVolume", false);
					animationMusic.SetBool ("selectedMusic", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					animationVolume.SetBool ("selectedVolume", false);
					animationDifficulty.SetBool ("selectedDifficulty", true);
				} else if(Input.GetAxis ("Horizontal") < 0){
					volume.value-=0.05f;
				} else if(Input.GetAxis ("Horizontal") > 0){
					volume.value+=0.05f;
				}		
			} else if (animationDifficulty.GetBool ("selectedDifficulty")) {
				Debug.Log ("Difficulty Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					animationDifficulty.SetBool ("selectedDifficulty", false);
					animationVolume.SetBool ("selectedVolume", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					animationDifficulty.SetBool ("selectedDifficulty", false);
					animationMode.SetBool ("selectedMode", true);
				} else if(Input.GetAxis ("Horizontal") < 0){
					animationNoobDif.SetBool ("selectedNoob", true);
					animationNormalDif.SetBool ("selectedNormal", false);
				} else if(Input.GetAxis ("Horizontal") > 0){
					animationNormalDif.SetBool ("selectedNormal", true);
					animationNoobDif.SetBool ("selectedNoob", false);
				}
			} else if (animationMode.GetBool ("selectedMode")) {
				Debug.Log ("Mode Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					animationMode.SetBool ("selectedMode", false);
					animationDifficulty.SetBool ("selectedDifficulty", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					animationMode.SetBool ("selectedMode", false);
					animationApply.SetBool ("selectApply", true);
				} else if(Input.GetAxis ("Horizontal") < 0){
					animationWindow.SetBool ("selectedWindow", true);
					animationFullscreen.SetBool ("selectedFullscreen", false);
				} else if(Input.GetAxis ("Horizontal") > 0){
					animationFullscreen.SetBool ("selectedFullscreen", true);
					animationWindow.SetBool ("selectedWindow", false);
				}
			} else if (animationApply.GetBool ("selectApply")) {
				Debug.Log ("Apply Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					animationApply.SetBool ("selectApply", false);
					animationMode.SetBool ("selectedMode", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					animationApply.SetBool ("selectApply", false);
					animationCancel.SetBool ("selectCancel", true);
				} else if(Input.GetButton("Attack")){
					SaveOptions();
					Application.LoadLevel("MainMenu");
				}
			} else if (animationCancel.GetBool ("selectCancel")) {
				Debug.Log ("Cancel Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					animationCancel.SetBool ("selectCancel", false);
					animationApply.SetBool ("selectApply", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					animationCancel.SetBool ("animationCancel", false);
					animationMusic.SetBool ("selectedMusic", true);
				} else if(Input.GetButton("Attack")){
					Application.LoadLevel("MainMenu");
				}
			}
			timer = 0.2f;
		}
	
	}

	void SaveOptions(){
		if (musicAudio.mute) {
			PlayerPrefs.SetInt("music", 0);
		} else {
			PlayerPrefs.SetInt("music", 1);
		}
		PlayerPrefs.SetFloat("volume", volume.value);

		if (animationFullscreen.GetBool ("selectedFullscreen")) {
			Screen.fullScreen = true;
			PlayerPrefs.SetInt("fullscreen", 1);
		} else {
			Screen.fullScreen = false;
			PlayerPrefs.SetInt("fullscreen", 0);
		}
	}

	void LoadOptions(){
		if (PlayerPrefs.GetInt("music")==0) {
			animationOffMusic.SetBool ("selectedOffMusic", true);
			animationOnMusic.SetBool ("selectedOnMusic", false);
		} else {
			animationOnMusic.SetBool ("selectedOnMusic", true);
			animationOffMusic.SetBool ("selectedOffMusic", false);
		}
		volume.value=PlayerPrefs.GetFloat("volume");
		if (PlayerPrefs.GetInt("fullscreen")==0) {
			animationFullscreen.SetBool ("selectedFullscreen", false);
			animationWindow.SetBool ("selectedWindow", true);
		} else {
			animationWindow.SetBool ("selectedWindow", false);
			animationFullscreen.SetBool ("selectedFullscreen", true);
		}
	}
}
