using UnityEngine;
using System.Collections;

public class EndScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("ReturnToMenu");
	}

	IEnumerator ReturnToMenu(){
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("MainMenu");
	}
}
