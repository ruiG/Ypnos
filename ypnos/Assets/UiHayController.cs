using UnityEngine;
using System.Collections;

public class UiHayController : MonoBehaviour {

	private Texture2D texture;
	// Use this for initialization
	void Start () {
		texture = Resources.Load("palha") as Texture2D;
	}
	
	void Captured(){		 
		guiTexture.texture = texture;
	}
}
