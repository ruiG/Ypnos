using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour {

	GameObject platforms;
	public AudioClip platformClip;

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
					StartCoroutine("PlatformSpawn");
				}
			}
		}
	}

	IEnumerator PlatformSpawn(){
		AudioSource.PlayClipAtPoint(platformClip, transform.position, 1f);
		yield return null;
	}
}
