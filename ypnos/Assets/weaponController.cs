using UnityEngine;
using System.Collections;

public class weaponController : MonoBehaviour {

	public float damage;


	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("Hit!");
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("ApplyDamage", damage);
	}

}
