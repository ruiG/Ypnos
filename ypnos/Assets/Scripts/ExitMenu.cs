using UnityEngine;
using System.Collections;

public class ExitMenu : MonoBehaviour {

	protected Animator animationYesExit;
	protected Animator animationNoExit;

	private float timer = 0.2f;

	// Use this for initialization
	void Start () {
		animationYesExit = GameObject.Find("Exit_Yes").GetComponent<Animator >();
		animationNoExit = GameObject.Find("Exit_No").GetComponent<Animator >();
		animationYesExit.SetBool ("selectedYes", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			if (animationYesExit.GetBool ("selectedYes")) {
				if (Input.GetAxis ("Horizontal") < 0) {
					animationNoExit.SetBool ("selectedNo", true);
					animationYesExit.SetBool ("selectedYes", false);
				} else if (Input.GetAxis ("Horizontal") > 0) {
					animationNoExit.SetBool ("selectedNo", true);
					animationYesExit.SetBool ("selectedYes", false);
				} else if(Input.GetButton("Attack")){
					Application.Quit();
				};
			} else if (animationNoExit.GetBool ("selectedNo")) {
				if (Input.GetAxis ("Horizontal") < 0) {
					animationNoExit.SetBool ("selectedNo", false);
					animationYesExit.SetBool ("selectedYes", true);
				} else if (Input.GetAxis ("Horizontal") > 0) {
					animationNoExit.SetBool ("selectedNo", false);
					animationYesExit.SetBool ("selectedYes", true);
				} else if(Input.GetButton("Attack")){
					Application.LoadLevel("MainMenu");
				};
			}
			timer = 0.2f;
		}
	}
}
