using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCon : MonoBehaviour {
	public GameObject rabbitPosPrefab;
	public GameObject rabbitPos; //箱
	public Vector3 toPlayerDirection;
	private GameObject player;
	private Vector3 idleDirection;//プレイヤを追ってない時の進行方向
	private float speed;
	private float theta;
	private SceneDir sceneDirSC;
	private float timer;
	private Material material;
	// Use this for initialization
	void Start () {
		this.speed = 0.1f;
		this.theta = 0f;
		this.timer = 0f;
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.player = GameObject.Find ("front01");
		this.rabbitPos = Instantiate (rabbitPosPrefab);
		this.rabbitPos.transform.SetParent (GameObject.Find("UICanvas/Map").transform, false);
		this.material = transform.GetChild (1).gameObject.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		this.toPlayerDirection = player.transform.position - transform.position;
		this.toPlayerDirection.y = 0; //グラウンドの法線方向

		if (timer < 5f) { //出現時
			this.timer += Time.deltaTime;
			this.material.SetFloat ("_Alpha", timer / 5f);
		} else {
			this.theta = this.theta + 0.08f;
			move ();
		}

        if(gameObject.GetComponent<Rigidbody>().velocity.y > 1f){//飛んじゃうバグの修正？怪しい。
            gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up);
        }
	}

	void OnCollisionEnter (Collision other){//ゲームオーバー
		if (other.gameObject.tag == "Player" && timer >= 4.9f) {
			this.sceneDirSC.gameOver = true;
		}
	}

	void move(){
		Vector3 tmpPos;

		if (this.toPlayerDirection.magnitude < 100f) { //プレイヤとの距離が近い場合->プレイヤを追う
			transform.forward = -this.toPlayerDirection; //z軸が尻尾の方
		} else {//プレイヤーとの距離が遠い場合
			this.idleDirection = new Vector3(Mathf.Cos(theta),0f,Mathf.Sin(theta));
			transform.forward = -this.idleDirection;
		}

		tmpPos = transform.position;
		tmpPos -= transform.forward * speed;
		transform.position = tmpPos;
	}
}
