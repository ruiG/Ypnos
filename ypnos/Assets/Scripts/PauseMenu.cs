using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GameObject pause;
	public bool isPause;

	protected Animator animationResume;
	protected Animator animationOptions;
	protected Animator animationMainMenu;
	protected Animator animationExit;


	// Use this for initialization
	void Start () {
		isPause = false;

		pause.SetActive (false);
		/*
		animationResume = GameObject.Find("Resume").GetComponent<Animator >();
		animationOptions = GameObject.Find("Options").GetComponent<Animator >();
		animationMainMenu = GameObject.Find("MainMenu").GetComponent<Animator >();
		animationExit = GameObject.Find("Exit").GetComponent<Animator >();

		animationResume.SetBool ("selectResume", true);*/

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Cancel")){
			Debug.Log ("Res");
			isPause = !isPause;
			if(isPause){
				pause.SetActive (true);
				Time.timeScale = 0;
			}
			else{
				pause.SetActive (false);
				Time.timeScale = 1;
			}

		}

		if (isPause) {
			if (GameObject.Find("Resume").GetComponent<Animator >().GetBool ("selectResume")) {
				Debug.Log ("Resume Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					GameObject.Find("Resume").GetComponent<Animator >().SetBool ("selectResume", false);
					GameObject.Find("Exit").GetComponent<Animator >().SetBool ("selectExit", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					Debug.Log ("Res");
					GameObject.Find("Resume").GetComponent<Animator >().SetBool ("selectResume", false);
					GameObject.Find("Options").GetComponent<Animator >().SetBool ("selectOptions", true);
				} else if(Input.GetButton("Attack"))
				{
					//Time.timeScale = 1;
					//pause.SetActive (false);
				}
			} else if (GameObject.Find("Options").GetComponent<Animator >().GetBool ("selectOptions")) {
				Debug.Log ("Options Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					GameObject.Find("Options").GetComponent<Animator >().SetBool ("selectOptions", false);
					GameObject.Find("Resume").GetComponent<Animator >().SetBool ("selectResume", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					GameObject.Find("Options").GetComponent<Animator >().SetBool ("selectOptions", false);
					GameObject.Find("MainMenu").GetComponent<Animator >().SetBool ("selectMainMenu", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("OptionsMenu");
				}
				
			} else if (GameObject.Find("MainMenu").GetComponent<Animator >().GetBool ("selectMainMenu")) {
				Debug.Log ("Main Menu Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					GameObject.Find("MainMenu").GetComponent<Animator >().SetBool ("selectMainMenu", false);
					GameObject.Find("Options").GetComponent<Animator >().SetBool ("selectOptions", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					GameObject.Find("MainMenu").GetComponent<Animator >().SetBool ("selectMainMenu", false);
					GameObject.Find("Exit").GetComponent<Animator >().SetBool ("selectExit", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("MainMenu");
				}
			} else if (GameObject.Find("Exit").GetComponent<Animator >().GetBool ("selectExit")) {
				Debug.Log ("Exit Selected");
				if (Input.GetAxis ("Vertical") > 0) {
					GameObject.Find("Exit").GetComponent<Animator >().SetBool ("selectExit", false);
					GameObject.Find("MainMenu").GetComponent<Animator >().SetBool ("selectMainMenu", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
					GameObject.Find("Exit").GetComponent<Animator >().SetBool ("selectExit", false);
					GameObject.Find("Resume").GetComponent<Animator >().SetBool ("selectResume", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("ExitMenu");
				}
			}
		}
	}
	
}
