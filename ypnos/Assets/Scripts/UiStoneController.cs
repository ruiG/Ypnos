using UnityEngine;
using System.Collections;

public class UiStoneController : MonoBehaviour {

	private Texture2D texture;
	// Use this for initialization
	void Start () {
		texture = Resources.Load("pedrabrilhante") as Texture2D;
	}
	
	void Captured(){		 
		guiTexture.texture = texture;
	}
}
