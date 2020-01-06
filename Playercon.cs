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
	private int state; //アニメーション遷移
	private Animator playerAnimator;
	// Use this for initialization
	void Start () {
		this.speed = 0.3f;
		this.state = 0;
		this.playerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.tmpPos = transform.position;
		this.state = 0;
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
			this.moveback = true;
		} 
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
			this.movefront = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
			this.moveright = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
			this.moveleft = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
			this.moveback = false;
		} 
		if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
			this.movefront = false;
		} 
		if (Input.GetKeyUp (KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.D)) {
			this.moveright = false;
		} 
		if (Input.GetKeyUp (KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.A)) {
			this.moveleft = false;
		} 
		TransForm ();
		this.playerAnimator.SetInteger ("PlayerState", this.state);
		transform.position = this.tmpPos;

		if (Input.GetKey (KeyCode.K)) {
			transform.Rotate (new Vector3 (0, 8f, 0));
		}
		if (Input.GetKey (KeyCode.L)) {
			transform.Rotate (new Vector3 (0, -8f, 0));
		}
	}

	void TransForm(){
		Vector3 tmpDir = Vector3.zero;
		if (moveback) {
			tmpDir += transform.forward;
			this.state = 3;
		} 
		if (movefront) {
			tmpDir -= transform.forward;
			this.state = 1;
		}
		if (moveright) {
			tmpDir += transform.right;
			this.state = 7;
		}
		if (moveleft) {
			tmpDir -= transform.right;
			this.state = 5;
		}
		this.tmpPos += tmpDir.normalized * speed;
	}

}