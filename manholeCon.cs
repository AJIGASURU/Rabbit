using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manholeCon : MonoBehaviour {
    public float degree; //マンホールの回転度合い

    private GameObject player;
	private float playerDistance;
	private int degreeInt;
	private Color black;
	private GameObject[] rabbits;
	private SceneDir sceneDirSC;

	// Use this for initialization
	void Start () {
		this.degree = 0f;
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.player = GameObject.Find("front01");
		this.black = new Color(0.0f,0.0f,0.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.playerDistance = Mathf.Abs((player.transform.position - transform.position).magnitude); //プレイヤー方向？
		if (this.playerDistance < 5f){//マンホールに近づいている
			if (Input.GetKey (KeyCode.J)) {
				this.degree += 0.3f; //マンホール回る速さ
                player.GetComponent<Playercon>().openingManhole = true; //アニメーション
            }else{
                player.GetComponent<Playercon>().openingManhole = false;
            }
            sceneDirSC.textManager.manholePanel.SetActive(true);
			if (this.degree < 100f) { //近づいていて空いていない。
				this.degreeInt = (int)degree;
				sceneDirSC.textManager.ManholeTextSet (degreeInt.ToString () + "%", 100);
			} else {　//近づいていて空いている
				sceneDirSC.textManager.ManholeTextSet ("マンホールは開いている", 40);
                Vector3 force = (player.transform.position - transform.position).normalized * 30f;
                force.y = 0f;
                player.GetComponent<Rigidbody>().AddForce(force); //マンホール上に立てないように
			}
		}else if(playerDistance < 10f){ //マンホールの周りをプレイヤーは一度通ることを利用
			sceneDirSC.textManager.ManholeTextSet ("", 20);
            sceneDirSC.textManager.manholePanel.SetActive(false);
            player.GetComponent<Playercon>().openingManhole = false;
        }
		transform.rotation = Quaternion.Euler (new Vector3 (90f, 0, degree*10f)); //見える回転

        if(this.degree >= 100f && this.degree < 200f) //空いて、一度しか通らない場所
        {
            GetComponent<SpriteRenderer>().material.color = this.black;
            sceneDirSC.ManholeOpen();
            this.degree += 100f;
        }

        if (this.degree >= 100f) {
			rabbits = GameObject.FindGameObjectsWithTag("rabbit"); //うさぎの数が増えないなら、startにかける。
			foreach (GameObject rabbit in rabbits) {
				if (Mathf.Abs ((rabbit.transform.position - transform.position).magnitude) < 3f) {
					Destroy (rabbit.GetComponent<RabbitCon>().rabbitPos); //先にマップアイコンを消す。
					Destroy (rabbit);
				}
			}
		}

	}
}
