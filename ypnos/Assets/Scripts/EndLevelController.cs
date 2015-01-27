using UnityEngine;
using System.Collections;

public class EndLevelController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "Player") {
			StartCoroutine("GoTobeCont");		
		}
	}

	IEnumerator GoTobeCont(){
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("ToBeContinued");
	}

}
