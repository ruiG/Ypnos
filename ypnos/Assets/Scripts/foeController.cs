using UnityEngine;
using System.Collections;

public class foeController : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = false;			// For determining which way the player is currently facing.

	public AudioClip hitClip;
	public AudioClip deathClip;
	public int life = 100;
	public int force = 200;
	public float maxSpeed;
	public float patrolTime;
	public int heading = -1;
	private float timeBackup;
	private Animator anim;	


	void Start(){
		timeBackup = patrolTime;
		anim = transform.GetComponentInChildren<Animator> ();
		rigidbody2D.AddForce(Vector2.right * heading * force);
	}

	void FixedUpdate (){

		patrolTime -= Time.fixedDeltaTime;

		if (patrolTime <= 0 && life > 0) {
			Flip ();
			rigidbody2D.velocity = new Vector2(0, 0);
			if(rigidbody2D.velocity.x < maxSpeed)
				// ... add a force to the player.
				rigidbody2D.AddForce(Vector2.right * heading * force);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		

			patrolTime = timeBackup;
		}
	}

	void ApplyDamage(int damage){
		life -= damage;
		if (life <= 0) {
			StartCoroutine ("Die");
			return;
		}
		StartCoroutine("HitClip");
	}

	IEnumerator Die(){
		Destroy(GetComponent("Remover"));
		StartCoroutine("DeathClip");
		anim.SetTrigger("Dead");
		yield return new WaitForSeconds(1);
		Destroy (gameObject);
	}

	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		heading *= -1;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator DeathClip(){
		AudioSource.PlayClipAtPoint(deathClip, transform.position, 0.5f);
		yield return null;
	}

	IEnumerator HitClip(){
		AudioSource.PlayClipAtPoint(hitClip, transform.position);
		yield return null;
	}


}
