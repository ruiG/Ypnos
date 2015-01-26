using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			//Add to Player Inv
			coll.SendMessage(this.name);

			//Play Sound

			//Destroy Game Obj
			Destroy(gameObject);
		}
	}

}
