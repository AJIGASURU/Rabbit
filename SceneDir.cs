using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SceneDir : MonoBehaviour { //シーンの初期化（オブジェクト生成）やウサギなどの管理を行うクラス。シングルトンにできればする。
	public bool gameOver; //->RabbitCon.csでゲームオーバーを感知
	public GameObject rabbitPrefab; //インスペクタで設定

	private int rabbitNum; //今ステージ上にいるうさぎの数
	private int catchRabbitNum; //今回捕まえたうさぎの数。
	private Text message;
	private Text rnText; //Rabitnumbertext
    private Text manholeText; //マンホールに関してのテキスト
	private GameObject panel; //画面全体のやつ
	private GameObject manholePanel; //中心テキスト表示用のパネル
	private GameManager gameManagerSC;
	private float timer;
	private float overTimer; //ゲームオーバー時用のタイマー
	
	// Use this for initialization
	void Start () {
		this.gameManagerSC = GameObject.Find("GameManager").GetComponent<GameManager>();//Scene01から実行するとエラーになる理由
		this.rabbitNum = 0; //今のフィールドに存在するうさぎの数。
		this.catchRabbitNum = 0;
		this.gameOver = false;
		this.message = GameObject.Find ("UICanvas/message").GetComponent<Text>();
		this.rnText = GameObject.Find ("UICanvas/RabbitNumText").GetComponent<Text> ();
		this.panel = GameObject.Find ("UICanvas/Panel");
		this.panel.SetActive (false);
		this.overTimer = 0f;
		this.timer = 0f;
		this.manholeText = GameObject.Find ("UICanvas/ManholeText").GetComponent<Text>();
		this.manholePanel = GameObject.Find ("UICanvas/ManholePanel");
		this.manholePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		this.rnText.text = "のこりうさぎ" + rabbitNum.ToString() + "ひき   ほかくうさぎ" + catchRabbitNum.ToString() + "ひき";
		this.timer += Time.deltaTime;
		if (this.timer > 3f) {//ratio
			InstallRabbit ();
			this.timer = 0f;
			this.rabbitNum++;
		}

		if (gameOver) {
			overTimer += Time.deltaTime;
            this.message.text = "つかまった・・・。\nきろく:" + catchRabbitNum.ToString() + "ひき";
			this.panel.SetActive (true);
            if (overTimer > 5f)
            {
                if (gameManagerSC.maxCatchRabbit < this.catchRabbitNum)
                {
                    gameManagerSC.maxCatchRabbit = this.catchRabbitNum;
                }
                gameManagerSC.LoadScene("MenuScene");
            }
                }

	}

	private Vector3 SetManholePos(int id){ //idによってマンホールの初期位置を返すメソッド、使ってない
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
			res = new Vector3 (56.0f, 0.5f, 65.0f);
			break;
		case 1:
			res = new Vector3 (56.0f, 0.5f, 5.0f);
			break;
		case 2:
			res = new Vector3 (20.0f, 0.5f, 63.0f);
			break;
		case 3:
			res = new Vector3 (-14.0f, 0.5f, 62.0f);
			break;
		case 4:
			res = new Vector3 (-44.0f, 0.5f, 60.0f);
			break;
		case 5:
			res = new Vector3 (-44.0f, 0.5f, 30.0f);
			break;
		case 6:
			res = new Vector3 (-44.0f, 0.5f, 0f);
			break;
		case 7:
			res = new Vector3 (-40.0f, 0.5f, 50.0f);
			break;
		case 8:
			res = new Vector3 (8.0f, 0.5f, -55.0f);
			break;
		case 9:
			res = new Vector3 (37.0f, 0.5f, -15.0f);
			break;
		default:
			res = new Vector3 (56.0f, 0.5f, 65.0f); //case0と同一
			break;
		}
		return res;
	}

	private void InstallRabbit(){ //ランダム位置にうさぎの設置
			int rabbitPosID = Random.Range (0, 10);
			Instantiate(this.rabbitPrefab, SetRabbitPos(rabbitPosID), Quaternion.Euler(0f,0f,0f));
	}

	public void DropRabbit(){ //->manhole.cs、うさぎが落ちたら呼ばれる。
		rabbitNum--;
		catchRabbitNum++;
		//ManholeTextSet("うさぎが落ちた", 20);
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
