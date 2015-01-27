using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	protected Animator animationRestart;
	protected Animator animationExit;
	public AudioClip wakeupClip;
	private float timer = 0.2f;
	
	void Start()
	{
		animationRestart = GameObject.Find("Restart").GetComponent<Animator >();
		animationExit = GameObject.Find("Exit").GetComponent<Animator >();
		animationRestart.SetBool("selectRestart", true);
		AudioSource.PlayClipAtPoint(wakeupClip, transform.position, 0.7f);
	}
	
	
	void Update()
	{
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			if (animationRestart.GetBool ("selectRestart")) {
				Debug.Log ("Restart Selected");
				if (Input.GetAxis ("Horizontal") > 0) {
					animationRestart.SetBool ("selectRestart", false);
					animationExit.SetBool ("selectExit", true);
				} else if (Input.GetAxis ("Horizontal") < 0) {
					animationRestart.SetBool ("selectRestart", false);
					animationExit.SetBool ("selectExit", true);
				} else if(Input.GetButton("Attack")){
					Application.LoadLevel("Level");
				}
			} else if (animationExit.GetBool ("selectExit")) {
				Debug.Log ("Exit Selected");
				if (Input.GetAxis ("Horizontal") > 0) {
					animationExit.SetBool ("selectExit", false);
					animationRestart.SetBool ("selectRestart", true);
				} else if (Input.GetAxis ("Horizontal") < 0) {
					animationExit.SetBool ("selectExit", false);
					animationRestart.SetBool ("selectRestart", true);
				} else if(Input.GetButton("Attack"))
				{
					Application.LoadLevel("ExitMenu");
				}
				
			}
			timer = 0.2f;
		}
	}
}
