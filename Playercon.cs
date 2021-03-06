﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercon : MonoBehaviour {
	private float speed;
	private bool movefront; //前に進んでいる
	private bool moveback;
	private bool moveleft;
	private bool moveright;
	private Animator playerAnimator;
    private GameObject playerPos; //マップアイコン

    public bool openingManhole;
	// Use this for initialization
	void Start () {
		this.speed = 0.2f;
		this.playerAnimator = GetComponent<Animator> ();
        this.playerPos = GameObject.Find("UICanvas/Map/playerPos");
        this.openingManhole = false;
        this.moveback = false;
        this.moveleft = false;
        this.movefront = false;
        this.moveright = false;
    }
	
	// Update is called once per frame
	void Update () {
		TransForm ();
		this.playerAnimator.SetInteger ("PlayerState", AnimationState());
        PlayerIconControl();

		//回転
		if (Input.GetKey (KeyCode.L)) {
			transform.Rotate (new Vector3 (0, 3f, 0));
		}
		if (Input.GetKey (KeyCode.K)) {
			transform.Rotate (new Vector3 (0, -3f, 0));
		}
    }

	void TransForm(){
		Vector3 tmpDir = Vector3.zero;
		Vector3 tmpPos = transform.position;
		//KeyDown
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
		//KeyUp
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
		//SetDir
		if (moveback) {
			tmpDir += transform.forward;
		} 
		if (movefront) {
			tmpDir -= transform.forward;
		}
		if (moveright) {
			tmpDir += transform.right;
		}
		if (moveleft) {
			tmpDir -= transform.right;
		}
		tmpPos += tmpDir.normalized * speed;
		transform.position = tmpPos;
	}

	int AnimationState(){ //しかるべきアニメーションの状態を返す関数。
        if (openingManhole)
        {
            return 9;
        }
        if (moveback) {
			return 3;
		} 
		if (movefront) {
			return 1;
		}
		if (moveright) {
			return 7;
		}
        if (moveleft)
        {
            return 5;
        }
        return 0; //静止
	}

    void PlayerIconControl()
    {
        Vector3 playerPosAngle = this.playerPos.transform.localEulerAngles;
        playerPosAngle.z = -transform.localEulerAngles.y;
        this.playerPos.transform.localEulerAngles = playerPosAngle;
    }


}