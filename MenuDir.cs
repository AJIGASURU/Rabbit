using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MenuDir : MonoBehaviour {
	private GameManager gameManagerSC;
	private Text catchText; 
	private Text prepareRabbitText;
	private GameObject asobikataPanel;

	// Use this for initialization
	void Start () {
		this.gameManagerSC = GameObject.Find("GameManager").GetComponent<GameManager>();//MenuSceneから実行するとエラー！
		this.catchText = GameObject.Find ("Canvas/CatchText").GetComponent<Text>();
		this.prepareRabbitText = GameObject.Find ("Canvas/PrepareRabbitText").GetComponent<Text> ();
		this.asobikataPanel = GameObject.Find ("Canvas/AsobikataPanel");
		this.asobikataPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		this.catchText.text = "つかまえたうさぎ: " + gameManagerSC.catchRabbit.ToString () + "ひき";
		this.prepareRabbitText.text = "うさぎのかずをえらぶ:    " + gameManagerSC.prepareRabbit.ToString() + "ひき";
		if (this.asobikataPanel.activeSelf) {
			if (Input.anyKey || Input.GetMouseButtonDown (0)) {
				this.asobikataPanel.SetActive (false);
			}
		}
	}
	public void OnClickStart(){ 
		gameManagerSC.LoadScene01 ();
	}
	public void OnClickAsobikata(){ 
		this.asobikataPanel.SetActive (true);
	}
	public void OnClickPlus(){
		if (this.gameManagerSC.prepareRabbit < 10) { //10匹まで
			this.gameManagerSC.prepareRabbit++;
		}
	}
	public void OnClickMinus(){
		if (this.gameManagerSC.prepareRabbit > 1) { //1匹から
			this.gameManagerSC.prepareRabbit--;
		}
	}
}
