using UnityEngine;
using System.Collections;

public class weaponController : MonoBehaviour {

	public float damage;
	private bool attacking;

	void OnTriggerEnter2D(Collider2D coll)
	{

			Debug.Log ("Hit!");
			if (coll.gameObject.tag == "Enemy")
					coll.gameObject.SendMessage ("ApplyDamage", damage);
	}

	void Attacking(){
		attacking = true;
	}
	
	void Idle(){
		attacking = false;
	}

}
