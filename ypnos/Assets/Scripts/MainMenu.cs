using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	protected Animator animationStart;
	protected Animator animationOptions;
	protected Animator animationExit;

	private float timer = 0.2f;

	void Start()
	{
		animationStart = GameObject.Find("Start").GetComponent<Animator >();
		animationOptions = GameObject.Find("Options").GetComponent<Animator >();
		animationExit = GameObject.Find("Exit").GetComponent<Animator >();
		animationStart.SetBool("selectStart", true);
		if (PlayerPrefs.GetInt("fullscreen")==0) {
			Screen.fullScreen = false;
		} else {
			Screen.fullScreen = true;
		}
	}


	void Update()
	{
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			if (animationStart.GetBool ("selectStart")) {
				Debug.Log ("Start Selected");
				if (Input.GetAxis ("Vertical") > 0) {
						animationStart.SetBool ("selectStart", false);
						animationExit.SetBool ("selectExit", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
						animationStart.SetBool ("selectStart", false);
						animationOptions.SetBool ("selectOptions", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("ChangeNameMenu");
				}
			} else if (animationOptions.GetBool ("selectOptions")) {
				Debug.Log ("Options Selected");
				if (Input.GetAxis ("Vertical") > 0) {
						animationOptions.SetBool ("selectOptions", false);
						animationStart.SetBool ("selectStart", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
						animationOptions.SetBool ("selectOptions", false);
						animationExit.SetBool ("selectExit", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("OptionsMenu");
				}

			} else if (animationExit.GetBool ("selectExit")) {
				Debug.Log ("Exit Selected");
				if (Input.GetAxis ("Vertical") > 0) {
						animationExit.SetBool ("selectExit", false);
						animationOptions.SetBool ("selectOptions", true);
				} else if (Input.GetAxis ("Vertical") < 0) {
						animationExit.SetBool ("selectExit", false);
						animationStart.SetBool ("selectStart", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("ExitMenu");
				}
			}
			timer = 0.2f;
		}
	}
}
