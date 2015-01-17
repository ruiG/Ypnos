﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUI : MonoBehaviour {

	public List < Item> inventory;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void AddItem(Item item){
		inventory.Add(item);
		GameObject coiso = new GameObject();
		coiso.AddComponent< SpriteRenderer> ();
		coiso.GetComponent< SpriteRenderer>().sprite = item.getSprite();
		coiso.renderer.enabled = true;
	}
}