using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public CharacterController2D controller;
	private int health = 100;
	public float runSpeed = 40f;
	float HorizontalMove = 0f;
	bool jump = false;
	
	void Start () {
		
	}
	void Update () {
			HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			if(Input.GetButtonDown("Jump")){
				jump = true;
			}
		
	}
	void FixedUpdate () {
			controller.Move(HorizontalMove * Time.deltaTime, false, jump);
			jump = false;
		
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if(col.collider.tag == "Enemy"){
			Debug.Log("Enemy hit");
			if(this.health > 0) {this.health -= 20; Debug.Log("Health: " + this.health);}
			else{this.enabled = false; Debug.Log("Player died !");}
			
		}
		
	}
		
	
}
