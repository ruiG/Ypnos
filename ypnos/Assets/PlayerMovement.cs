using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public bool gamepad;

	void Update() {
		PlayerMove ();
		if (Input.GetKey (KeyCode.Space)) {
				}
	}

	void PlayerMove(){
		if(gamepad){
			if(Input.GetAxis("Vertical")>0) {
				rigidbody2D.AddForce(Vector2.up * speed);
			}
			if(Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0){
				rigidbody2D.velocity=Vector2.zero;
			}
			
			if(Input.GetAxis("Horizontal")<0) {
				rigidbody2D.AddForce(-Vector2.right * speed);
			}
			if(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0){
				rigidbody2D.velocity=Vector2.zero;
			}
			
			if(Input.GetAxis("Vertical")<0) {
				rigidbody2D.AddForce(-Vector2.up * speed);
			}
			if(Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0){
				rigidbody2D.velocity=Vector2.zero;
			}
			
			if(Input.GetAxis("Horizontal")>0) {
				rigidbody2D.AddForce(Vector2.right * speed);
			}
			if (Input.GetAxis ("Horizontal") == 0 && Input.GetAxis("Vertical")==0) {
				rigidbody2D.velocity = Vector2.zero;
			}
		}
		else if(!gamepad){
			if (Input.GetKey (KeyCode.W)) {
					rigidbody2D.AddForce (Vector2.up * speed);
			}
			if (Input.GetKeyUp (KeyCode.W)) {
					rigidbody2D.velocity = Vector2.zero;
			}

			if (Input.GetKey (KeyCode.A)) {
					rigidbody2D.AddForce (-Vector2.right * speed);
			}
			if (Input.GetKeyUp (KeyCode.A)) {
					rigidbody2D.velocity = Vector2.zero;
			}

			if (Input.GetKey (KeyCode.S)) {
					rigidbody2D.AddForce (-Vector2.up * speed);
			}
			if (Input.GetKeyUp (KeyCode.S)) {
					rigidbody2D.velocity = Vector2.zero;
			}

			if (Input.GetKey (KeyCode.D)) {
					rigidbody2D.AddForce (Vector2.right * speed);
			}
			if (Input.GetKeyUp (KeyCode.D)) {
					rigidbody2D.velocity = Vector2.zero;
			}
		}
	}
}
