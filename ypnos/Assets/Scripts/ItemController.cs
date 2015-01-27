using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public AudioClip itemClip;

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			//Add to Player Inv
			coll.SendMessage(this.name);

			//Play Sound
			StartCoroutine("PlayItemSound");
			//Destroy Game Obj
			Destroy(gameObject);
		}
	}

	IEnumerator PlayItemSound(){
		AudioSource.PlayClipAtPoint(itemClip, transform.position);
		yield return null;
	}

}
