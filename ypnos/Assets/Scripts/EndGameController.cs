using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour {

	GameObject platforms;

	void Start(){
		platforms = GameObject.FindGameObjectWithTag("Finish");
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {					
			if (coll.GetComponent<PlayerControl>()){
				if(coll.GetComponent<PlayerControl>().hasHay && 
				   coll.GetComponent<PlayerControl>().hasStick && 
				   coll.GetComponent<PlayerControl>().hasStone){
					platforms.GetComponent<Animator>().SetTrigger("EndGame");
					this.GetComponent<Animator>().SetTrigger("MakeFire");
				}
			}
		}
	}
}
