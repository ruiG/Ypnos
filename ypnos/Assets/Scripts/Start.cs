using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {	
	// Update is called once per frame
	void onMouseEnter () {
		renderer.guiText.material.color = Color.yellow;
	}

	void onMouseExit () {
		renderer.guiText.material.color = Color.white;
	}
}
