using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private Scene nowScene;

	public int catchRabbit;
	public int prepareRabbit; //用意するうさぎの数
	public AudioSource[] sources;

	// 手書き風フォント「こども丸ゴシック細め」
	void Start () { //コンストラクタ
		DontDestroyOnLoad( gameObject );
		catchRabbit = 0; //捕まえたうさぎの数
		prepareRabbit = 1;
		sources = gameObject.GetComponents<AudioSource>(); //音楽
	}
	
	// Update is called once per frame
	void Update () {
		nowScene = SceneManager.GetActiveScene ();
		if (nowScene.name == "StartScene") {
			if (Input.anyKey || Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene("MenuScene");
			}
		}
		BGMPlay ();
	}
	public void LoadMenu(){ //シーン管理ここだけでやりたい
		SceneManager.LoadScene("MenuScene");
	}
	public void LoadScene01(){ //シーン管理ここだけでやりたい
		SceneManager.LoadScene("Scene01");
	}
	private void BGMPlay(){
		if (nowScene.name == "Scene01") {
			if (sources [1].isPlaying == false) {
				sources [1].Play ();
			}
			if (sources [0].isPlaying == true) {
				sources [0].Stop ();
			}
		}
		if (nowScene.name == "MenuScene") {
			if (sources [0].isPlaying == false) {
				sources [0].Play ();
			}
			if (sources [1].isPlaying == true) {
				sources [1].Stop ();
			}
		}
	}
}
