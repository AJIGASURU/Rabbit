using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MenuDir : MonoBehaviour {
	private GameManager gameManager;
    //private Text catchText; 
	private GameObject asobikataPanel;
    private GameObject stageButtons;
    private GameObject menuButtons;

	// Use this for initialization
	void Start () {
		this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();//MenuSceneから実行するとエラー！
		//this.catchText = GameObject.Find ("Canvas/CatchText").GetComponent<Text>();//最高記録の表示
		this.asobikataPanel = GameObject.Find ("Canvas/AsobikataPanel");
		this.asobikataPanel.SetActive (false);
        this.stageButtons = GameObject.Find("Canvas/StageButtons");
        this.stageButtons.SetActive(false);
        this.menuButtons = GameObject.Find("Canvas/MenuButtons");
	}
	
	// Update is called once per frame
	void Update () {
		//this.catchText.text = "さいこうきろく: " + gameManagerSC.maxCatchRabbit.ToString () + "ひき";
		if (this.asobikataPanel.activeSelf) {
			if (Input.anyKey || Input.GetMouseButtonDown (0)) {
				this.asobikataPanel.SetActive (false);
			}
		}
	}
	public void OnClickStart(){
        this.stageButtons.SetActive(true);
        this.menuButtons.SetActive(false);
    }
	public void OnClickAsobikata(){ 
		this.asobikataPanel.SetActive (true);
	}

    public void OnClickStage(int stageNum) //引数入るぞ!!神
    {
        gameManager.stageNum = stageNum;
        gameManager.LoadScene("Scene01");
    }

    public void OnClickBack() //戻るボタン
    {
        this.stageButtons.SetActive(false);
        this.menuButtons.SetActive(true);
    }

}
