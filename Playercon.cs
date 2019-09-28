using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercon : MonoBehaviour {
	private Vector3 tmpPos;
	private float speed;
	private bool movefront;
	private bool moveback;
	private bool moveleft;
	private bool moveright;
	private int state;
	private Animator PlayerAnimator;
	// Use this for initialization
	void Start () {
		this.speed = 0.5f;
		this.state = 0;
		this.PlayerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.tmpPos = transform.position;
		this.state = 0;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			this.moveback = true;
		} 
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			this.movefront = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.moveright = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.moveleft = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			this.moveback = false;
		} 
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			this.movefront = false;
		} 
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			this.moveright = false;
		} 
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			this.moveleft = false;
		} 
		TransForm ();
		this.PlayerAnimator.SetInteger ("PlayerState", this.state);
		transform.position = this.tmpPos;

		if (Input.GetKey (KeyCode.T)) {
			transform.Rotate (new Vector3 (0, 10f, 0));
		}
		if (Input.GetKey (KeyCode.Y)) {
			transform.Rotate (new Vector3 (0, -10f, 0));
		}
	}

	void TransForm(){
		if (moveback) {
			this.tmpPos += transform.forward * speed;
			this.state = 3;
		} 
		if (movefront) {
			this.tmpPos -= transform.forward * speed;
			this.state = 1;
		}
		if (moveright) {
			this.tmpPos += transform.right * speed;
			this.state = 7;
		}
		if (moveleft) {
			this.tmpPos -= transform.right * speed;
			this.state = 5;
		}
	}

}



