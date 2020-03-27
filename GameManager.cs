using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private Scene nowScene;

	public int maxCatchRabbit;
	public AudioSource[] sources;

	// 手書き風フォント「こども丸ゴシック細め」
	void Start () {
		DontDestroyOnLoad( gameObject );
		maxCatchRabbit = 0; //最高記録
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

	public void LoadScene(string sceneName){ //シーン管理ここだけでやりたい
		SceneManager.LoadScene(sceneName);
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
