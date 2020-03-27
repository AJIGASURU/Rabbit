using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manholeCon : MonoBehaviour {
	private GameObject player;
	private float playerDistance;
	private float degree; //マンホールの回転度合い
	private int degreeInt;
	private Color black;
	private GameObject[] rabbits;
	private SceneDir sceneDirSC;

	// Use this for initialization
	void Start () {
		this.degree = 0f;
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.player = GameObject.Find("front01");
		this.black = new Color(0.0f,0.0f,0.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.playerDistance = Mathf.Abs((player.transform.position - transform.position).magnitude); //プレイヤー方向？
		if (this.playerDistance < 5f){//マンホールに近づいている
			if (Input.GetKey (KeyCode.J)) {
				this.degree += 0.5f; //マンホール回る速さ
			}
			sceneDirSC.ManholePanelSet (true);
			if (this.degree < 100f) {
				this.degreeInt = (int)degree;
				sceneDirSC.ManholeTextSet (degreeInt.ToString () + "%", 50);
			} else {　//近づいていて空いている
				sceneDirSC.ManholeTextSet ("マンホールは空いている", 20);
                player.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position)*5f); //マンホール上に立てないように
				GetComponent<SpriteRenderer> ().material.color = this.black;
			}
		}else if(playerDistance < 10f){ //マンホールの周りをプレイヤーは一度通ることを利用
			sceneDirSC.ManholeTextSet ("", 20);
			sceneDirSC.ManholePanelSet (false);
		}
		transform.rotation = Quaternion.Euler (new Vector3 (90f, 0, degree*30f)); //見える回転
		if (this.degree >= 100f) {
			rabbits = GameObject.FindGameObjectsWithTag("rabbit"); //タグで検索している、マンホールにコライダをつけない設計->重そう
			foreach (GameObject rabbit in rabbits) {
				if (Mathf.Abs ((rabbit.transform.position - transform.position).magnitude) < 3f) {
					Destroy (rabbit.GetComponent<RabbitCon>().rabbitPos); //先にマップアイコンを消す。
					Destroy (rabbit);
					this.sceneDirSC.DropRabbit ();
				}
			}
		}
	}
}
