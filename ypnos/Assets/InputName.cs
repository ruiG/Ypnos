using UnityEngine;
using System.Collections;

public class InputName : MonoBehaviour {


	public UnityEngine.UI.InputField inputField;
	public string name;
	public UnityEngine.UI.Text text;


	// Update is called once per frame
	void Update () {
		name = inputField.text;

		if(inputField.isFocused && inputField.text != "" && Input.GetKey(KeyCode.Return)) {
			//store name forever
			Application.LoadLevel("Level");
		}
	}
}
