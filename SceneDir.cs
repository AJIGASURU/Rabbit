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

	// Use this for initialization
	void Start () {
		this.RabbitNum = 1; //1ひき
		this.GameOver = false;
		this.GameClear = false;
		this.message = GameObject.Find ("UICanvas/message").GetComponent<Text>();
		this.Panel = GameObject.Find ("UICanvas/Panel");
		this.Panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (RabbitNum == 0) {
			GameClear = true;
			//this.message.text = "うさぎは落ちた";
		}
		if (GameClear) {
			this.message.text = "すべてのうさぎは落ちた";
			this.Panel.SetActive (true);
		}
		if (GameOver) {
			this.message.text = "つかまった";
			this.Panel.SetActive (true);
		}
	}
}
