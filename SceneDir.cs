using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SceneDir : MonoBehaviour {
	public bool GameOver;
	public int RabbitNum;
	private bool GameClear;
	private Text message;
	private GameObject Panel;
	private GameManager GameManagerSC;
	private float cleartimer;
	private float overtimer;

	// Use this for initialization
	void Start () {
		this.RabbitNum = 1; //出場させるうさぎの数
		this.GameOver = false;
		this.GameClear = false;
		this.message = GameObject.Find ("UICanvas/message").GetComponent<Text>();
		this.Panel = GameObject.Find ("UICanvas/Panel");
		this.Panel.SetActive (false);

		this.GameManagerSC = GameObject.Find("GameManager").GetComponent<GameManager>();//Scene01から実行するとエラー！
		this.cleartimer = 0f;
		this.overtimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (RabbitNum == 0) {
			GameClear = true;
			//this.message.text = "うさぎは落ちた";
		}
		if (GameClear) {
			cleartimer += Time.deltaTime;
			this.message.text = "すべてのうさぎはおちた！\nくりあー！";
			this.Panel.SetActive (true);
			if (cleartimer > 5f) {
				GameManagerSC.LoadMenuWithClear ();
			}
		}
		if (GameOver) {
			overtimer += Time.deltaTime;
			this.message.text = "つかまった・・・。";
			this.Panel.SetActive (true);
			if (overtimer > 5f) {
				GameManagerSC.LoadMenuWithOver();
			}
		}
	}
}
