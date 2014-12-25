using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other){
		if (Input.GetKey (KeyCode.E) ||  Input.GetKey( KeyCode.Joystick1Button1)) {
			Item cenas = new Item(other.name, other.GetComponent<SpriteRenderer>().sprite);
			GameObject.Find("GUI").GetComponent<GUI>().AddItem(cenas);
			Destroy(other.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Item : MonoBehaviour {

	private string name;
	private Sprite sprite;

	public Item(string _name, Sprite _sprite){
		name = _name;
		sprite = _sprite;
	}

	public void setName(string _name)
	{
		name = _name;
	}

	public void setSprite(Sprite _sprite)
	{
		sprite = _sprite;
	}

	public string getName()
	{
		return name;
	}

	public Sprite getSprite()
	{
		return sprite;
	}
}