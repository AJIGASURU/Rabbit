using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private Scene NowScene;

	public int CatchRabbit;
	public int prepareRabbit; //用意するうさぎの数
	public AudioSource[] sources;

	// 手書き風フォント「こども丸ゴシック細め」
	void Start () { //コンストラクタ
		DontDestroyOnLoad( gameObject );
		CatchRabbit = 0; //捕まえたうさぎの数?
		prepareRabbit = 1;
		sources = gameObject.GetComponents<AudioSource>(); //音楽
	}
	
	// Update is called once per frame
	void Update () {
		NowScene = SceneManager.GetActiveScene ();
		if (NowScene.name == "StartScene") {
			if (Input.anyKey || Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene("MenuScene");
			}
		}
		BGMPlay ();
	}

	public void LoadMenu(bool isClear){ //クリアかゲームオーバーか
		/*
		if (isClear == true) {
			CatchRabbit++;
		}
		*/
		SceneManager.LoadScene("MenuScene");
	}

	private void BGMPlay(){
		if (NowScene.name == "Scene01") {
			if (sources [1].isPlaying == false) {
				sources [1].Play ();
			}
			if (sources [0].isPlaying == true) {
				sources [0].Stop ();
			}
		}
		if (NowScene.name == "MenuScene") {
			if (sources [0].isPlaying == false) {
				sources [0].Play ();
			}
			if (sources [1].isPlaying == true) {
				sources [1].Stop ();
			}
		}
	}
}
