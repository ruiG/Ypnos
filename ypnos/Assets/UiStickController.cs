using UnityEngine;
using System.Collections;

public class UiStickController : MonoBehaviour {
	private Texture2D texture;
	// Use this for initialization
	void Start () {
		texture = Resources.Load("pau") as Texture2D;
	}

	void Captured(){		 
		guiTexture.texture = texture;
	}

}