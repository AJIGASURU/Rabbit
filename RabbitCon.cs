using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCon : MonoBehaviour {
	public GameObject Player;
	private Vector3 direction;
	private Vector3 tmpPos;
	private float speed;
	private SceneDir sceneDirSC;
	// Use this for initialization
	void Start () {
		this.speed = 0.2f;
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.direction = Player.transform.position - transform.position;
		this.direction.y = 0;
		transform.forward = -this.direction;

		this.tmpPos = transform.position;
		this.tmpPos -= transform.forward * speed;
		transform.position = this.tmpPos;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Player") {
			this.sceneDirSC.GameOver = true;
		}
	}
}
