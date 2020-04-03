using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDir : MonoBehaviour { //シーンの初期化（オブジェクト生成）やウサギなどの管理を行うクラス。シングルトンにできればする。
	public bool gameOver; //->RabbitCon.csでゲームオーバーを感知
	public GameObject rabbitPrefab; //インスペクタで設定
    public TextManager textManager;

    private int manholeNum; //残りのマンホール数
    private GameManager gameManager;
	private float overTimer; //ゲームオーバー時用のタイマー
    private float clearTimer; //クリア用タイマー
    private List<Vector3> rabbitFirstPosition = new List<Vector3>(); //リスト
	
	// Use this for initialization
	void Start () {
		this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();//Scene01から実行するとエラーになる理由
        this.textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
		this.gameOver = false;
		this.overTimer = 0f;
        this.clearTimer = 0f;
        manholeNum = 0;
        StageInit(); //こいつの位置大事
    }
	
	// Update is called once per frame
	void Update () {
        textManager.ManholeNumTextSet("のこりのマンホール:" + manholeNum.ToString() + "\n<そうさ> K,L:カメラ回転 J:マンホールを回す", 50);

        if (manholeNum == 0)
        {
            clearTimer += Time.deltaTime;
            if (!gameOver)
            {//先に入った方が優先表示
                textManager.messageSet("クリアー！", 120);
            }
            textManager.panel.SetActive(true);
            if (clearTimer > 5f)
            {
                gameManager.LoadScene("MenuScene");
            }
        }

        if (gameOver) {
			overTimer += Time.deltaTime;
            if (manholeNum > 0)
            {
                textManager.messageSet("つかまった・・・。", 50);
            }
			textManager.panel.SetActive (true);
            if (overTimer > 5f)
            {
                gameManager.LoadScene("MenuScene");
            }
                }

    }

    public void ManholeOpen() //マンホールが開くと呼ばれる。
    {
        this.manholeNum--;
        if (manholeNum != 0)
        {
            foreach (Vector3 p in rabbitFirstPosition)
            {
                Instantiate(this.rabbitPrefab, p, Quaternion.Euler(0f, 0f, 0f));　//うさぎ追加
            }
        }
    }

    void StageInit()
    {
        GameObject stage1;
        stage1 = GameObject.Find("Stage1");
        stage1.SetActive(false);
        GameObject stage2;
        stage2 = GameObject.Find("Stage2");
        stage2.SetActive(false);
        GameObject stage3;
        stage3 = GameObject.Find("Stage3");
        stage3.SetActive(false);
        GameObject stage4;
        stage4 = GameObject.Find("Stage4");
        stage4.SetActive(false);
        GameObject stage5;
        stage5 = GameObject.Find("Stage5");
        stage5.SetActive(false);

        switch (gameManager.stageNum)
        {
            case 1:
                stage1.SetActive(true);
                break;
            case 2:
                stage2.SetActive(true);
                break;
            case 3:
                stage3.SetActive(true);
                break;
            case 4:
                stage4.SetActive(true);
                break;
            case 5:
                stage5.SetActive(true);
                break;
        }

        GameObject[] manholes = GameObject.FindGameObjectsWithTag("manhole");
        foreach (GameObject manhole in manholes)
        {
            manholeNum++;
        }

        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("rabbit");
        foreach (GameObject rabbit in rabbits)
        {
            rabbitFirstPosition.Add(rabbit.transform.position); //リストにうさぎの初期位置を格納しておく
        }

    }
}
