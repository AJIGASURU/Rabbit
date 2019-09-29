using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class MenuDir : MonoBehaviour {
	private GameManager GameManagerSC;
	private Text CatchText; 
	private GameObject AsobikataPanel;

	//public GameObject RabbitPrefab;

	// Use this for initialization
	void Start () {
		this.GameManagerSC = GameObject.Find("GameManager").GetComponent<GameManager>();//Scene01から実行するとエラー！
		this.CatchText = GameObject.Find ("Canvas/CatchText").GetComponent<Text>();
		this.AsobikataPanel = GameObject.Find ("Canvas/AsobikataPanel");
		this.AsobikataPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		this.CatchText.text = "つかまえたうさぎ: " + GameManagerSC.CatchRabbit.ToString () + "ひき";
		if (this.AsobikataPanel.activeSelf) {
			if (Input.anyKey || Input.GetMouseButtonDown (0)) {
				this.AsobikataPanel.SetActive (false);
			}
		}
	}
	public void OnClickStart(){ 
		SceneManager.LoadScene ("Scene01");
	}
	public void OnClickAsobikata(){ 
		this.AsobikataPanel.SetActive (true);
	}
}
