using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SceneDir : MonoBehaviour { //シーンの初期化（オブジェクト生成）やウサギなどの管理を行うクラス。シングルトンな気もしてきた。
	public bool gameOver; //->RabbitCon.cs
	public int rabbitNum; //今のうさぎの数->manholeCon.cs
	public GameObject manholePrefab; //インスペクタで設定
	public GameObject rabbitPrefab; //インスペクタで設定

	private bool gameClear;
	private Text message;
	private Text rnText; //Rabitnumbertext
	private GameObject panel;
	private GameManager gameManagerSC;
	private float clearTimer;
	private float overTimer;
	private int manholePosID; //マンホールの初期位置の指定用->とりあえずマンホールは一つで実装中
	private Text manholeText; //マンホールに関してのテキスト
	private GameObject manholePanel; //テキスト表示用のパネル

	// Use this for initialization
	void Start () {
		this.gameManagerSC = GameObject.Find("GameManager").GetComponent<GameManager>();//Scene01から実行するとエラーになる理由
		this.rabbitNum = this.gameManagerSC.prepareRabbit; //出場させるうさぎの数を現在のうさぎの数に代入
		this.gameOver = false;
		this.gameClear = false;
		this.message = GameObject.Find ("UICanvas/message").GetComponent<Text>();
		this.rnText = GameObject.Find ("UICanvas/RabbitNumText").GetComponent<Text> ();
		this.panel = GameObject.Find ("UICanvas/Panel");
		this.panel.SetActive (false);
		this.clearTimer = 0f;
		this.overTimer = 0f;
		this.manholeText = GameObject.Find ("UICanvas/ManholeText").GetComponent<Text>();
		this.manholePanel = GameObject.Find ("UICanvas/ManholePanel");
		this.manholePanel.SetActive (false);
		//マンホール準備
		this.manholePosID = Random.Range(0, 3); 
		Instantiate(this.manholePrefab, SetManholePos(manholePosID), Quaternion.Euler(90.0f, 0f, 0f)); //マンホール生成
		//うさぎ準備
		int[] rabbitPosID = new int[this.rabbitNum]; //それぞれのうさぎの初期位置を指定
		for (int i = 0; i < rabbitNum; i++) {
			rabbitPosID[i] = Random.Range (0, 10);
			for (int j = 0; j < i; j++) {
				if (rabbitPosID [i] == rabbitPosID [j]) {
					i--; //重複していたらIDの設定をやり直す。
				}
			}
		}
		for (int i = 0; i < rabbitNum; i++) {
			Instantiate(this.rabbitPrefab, SetRabbitPos(rabbitPosID[i]), Quaternion.Euler(0f,0f,0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.rnText.text = "のこり" + rabbitNum.ToString() + "ひき";

		if (rabbitNum == 0) {
			gameClear = true; //クリア
		}
		if (gameClear) {
			clearTimer += Time.deltaTime;
			this.message.text = "すべてのうさぎはおちた！\nくりあー！";
			this.panel.SetActive (true);
			if (clearTimer > 5f) {
				gameManagerSC.LoadMenu ();
			}
		}
		if (gameOver) {
			overTimer += Time.deltaTime;
			this.message.text = "つかまった・・・。";
			this.panel.SetActive (true);
			if (overTimer > 5f) {
				gameManagerSC.LoadMenu();
			}
		}
	}

	private Vector3 SetManholePos(int id){ //idによってマンホールの初期位置を返すメソッド
		Vector3 res;
		switch (id) {
		case 0:
			res = new Vector3 (54.0f, 0.1f, 33.0f);
			break;
		case 1:
			res = new Vector3 (-39.0f, 0.1f, 16.0f);
			break;
		case 2:
			res = new Vector3 (13.0f, 0.1f, -55.0f);
			break;
		default:
			res = new Vector3 (54.0f, 0.1f, 33.0f); //case0と同一
			break;
		}
		return res;
	}

	private Vector3 SetRabbitPos(int id){ //idによってうさぎの初期位置を返すメソッド
		Vector3 res;
		switch(id){
		case 0:
			res = new Vector3 (56.0f, 0f, 65.0f);
			break;
		case 1:
			res = new Vector3 (56.0f, 0f, 20.0f);
			break;
		case 2:
			res = new Vector3 (20.0f, 0f, 63.0f);
			break;
		case 3:
			res = new Vector3 (-14.0f, 0f, 62.0f);
			break;
		case 4:
			res = new Vector3 (-44.0f, 0f, 60.0f);
			break;
		case 5:
			res = new Vector3 (-44.0f, 0f, 30.0f);
			break;
		case 6:
			res = new Vector3 (-44.0f, 0f, 0f);
			break;
		case 7:
			res = new Vector3 (-40.0f, 0f, 50.0f);
			break;
		case 8:
			res = new Vector3 (8.0f, 0f, -55.0f);
			break;
		case 9:
			res = new Vector3 (37.0f, 0f, -15.0f);
			break;
		default:
			res = new Vector3 (56.0f, 0f, 65.0f); //case0と同一
			break;
		}
		return res;
	}

	public void DropRabbit(){ //->manhole.cs、うさぎが落ちた
		rabbitNum--;
		gameManagerSC.catchRabbit++;
	}

	public void ManholePanelSet(bool b){
		if (b) {
			this.manholePanel.SetActive (true);
		} else {
			this.manholePanel.SetActive (false);
		}
	}

	public void ManholeTextSet(string message, int fontSize){
		this.manholeText.text = message;
		this.manholeText.fontSize = fontSize;
	}

}
