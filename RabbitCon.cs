using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCon : MonoBehaviour {
	private GameObject player;
	private Vector3 toPlayerDirection;
	private Vector3 tmpPos;
	private Vector3 idleDirection;
	private float speed;
	private float theta;
	private SceneDir sceneDirSC;
	// Use this for initialization
	void Start () {
		this.speed = 0.2f;
		this.theta = 0f;
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.player = GameObject.Find ("front01");
	}
	
	// Update is called once per frame
	void Update () {
		this.theta = this.theta + 0.08f;
		move ();
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Player") {
			this.sceneDirSC.gameOver = true;
		}
	}

	void move(){
		this.toPlayerDirection = player.transform.position - transform.position;
		this.toPlayerDirection.y = 0; //グラウンドの法線方向

		if (this.toPlayerDirection.magnitude < 40f) { //プレイヤとの距離が近い場合->プレイヤを追う
			transform.forward = -this.toPlayerDirection; //z軸が尻尾の方
		} else {
			this.idleDirection = new Vector3(Mathf.Cos(theta),0f,Mathf.Sin(theta));
			transform.forward = -this.idleDirection;
		}

		this.tmpPos = transform.position;
		this.tmpPos -= transform.forward * speed;
		transform.position = this.tmpPos;
	}
}
