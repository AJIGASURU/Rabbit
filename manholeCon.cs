using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class manholeCon : MonoBehaviour {
	private GameObject Player;
	private float playerdistance;
	private float degree;
	private int degreeInt;
	private Text manholeText; //表示、ここのテキストはマンホールがやんのかい。
	private GameObject manholePanel; //テキスト表示用のパネル
	private Color Black;
	private GameObject[] rabbits;
	private SceneDir sceneDirSC;

	// Use this for initialization
	void Start () {
		this.degree = 0f;
		this.manholeText = GameObject.Find ("UICanvas/ManholeText").GetComponent<Text>();
		this.manholePanel = GameObject.Find ("UICanvas/ManholePanel");
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.Player = GameObject.Find("front01");
		this.Black = new Color(0.0f,0.0f,0.0f,1.0f);

		this.manholePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		this.playerdistance = Mathf.Abs((Player.transform.position - transform.position).magnitude);
		if (this.playerdistance < 5f){//マンホールに近づいている
			this.manholePanel.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				this.degree += 0.2f;
			}
			if (this.degree < 100f) {
				this.degreeInt = (int)degree;
				this.manholeText.text = degreeInt.ToString () + "%"; //fontsize=50
			} else {
				this.manholeText.fontSize = 20;
				this.manholeText.text = "マンホールは開いている";
				GetComponent<SpriteRenderer> ().material.color = this.Black;
			}
		}else if(playerdistance < 10f){ //マンホールの周りをプレイヤーは一度通ることを利用
			this.manholeText.text = "";
			this.manholePanel.SetActive (false);
		}

		transform.rotation = Quaternion.Euler (new Vector3 (90f, 0, degree*30f));
		if (this.degree >= 100f) {
			rabbits = GameObject.FindGameObjectsWithTag("rabbit"); //タグで検索している、マンホールにコライダをつけない設計が・・・。
			foreach (GameObject rabbit in rabbits) {
				if (Mathf.Abs ((rabbit.transform.position - transform.position).magnitude) < 5f) {
					Destroy (rabbit);
					this.sceneDirSC.DropRabbit ();
				}
			}
		}
	}
}
