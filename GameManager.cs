using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private Scene NowScene;
	public int CatchRabbit;
	public AudioSource[] sources;

	// 手書き風フォント「こども丸ゴシック細め」
	void Start () {
		DontDestroyOnLoad( gameObject );
		CatchRabbit = 0; //捕まえたうさぎの数
		sources = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		NowScene = SceneManager.GetActiveScene ();
		if (NowScene.name == "StartScene") {
			if (Input.anyKey || Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene("MenuScene");
			}
		}
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

	public void LoadMenuWithClear(){
		CatchRabbit++;
		SceneManager.LoadScene("MenuScene");
	}

	public void LoadMenuWithOver(){
		SceneManager.LoadScene("MenuScene");
	}
}
