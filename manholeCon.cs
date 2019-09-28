using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class manholeCon : MonoBehaviour {
	public GameObject Player;
	private float playerdistance;
	private float degree;
	private Text ManholeText; //表示
	private Color Black;
	private GameObject[] rabbits;
	private SceneDir sceneDirSC;

	// Use this for initialization
	void Start () {
		this.degree = 0f;
		this.ManholeText = GameObject.Find ("UICanvas/ManholeText").GetComponent<Text>();
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.Black = new Color(0.0f,0.0f,0.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.playerdistance = Mathf.Abs((Player.transform.position - transform.position).magnitude);
		if (this.playerdistance < 5f){
			if (Input.GetKey (KeyCode.Space)) {
				this.degree += 0.5f;
			}
			if (this.degree < 100f) {
				this.ManholeText.text = "スペースキーを長押しでマンホールを回す\n達成度:" + degree.ToString () + "%";
			} else {
				this.ManholeText.text = "マンホールは開いている。";
				GetComponent<SpriteRenderer> ().material.color = this.Black;
			}
		}else if(playerdistance < 10f){
			this.ManholeText.text = "";
		}
		transform.rotation = Quaternion.Euler (new Vector3 (90f, 0, degree));
		if (this.degree >= 100f) {
			rabbits = GameObject.FindGameObjectsWithTag("rabbit");
			foreach (GameObject rabbit in rabbits) {
				if (Mathf.Abs ((rabbit.transform.position - transform.position).magnitude) < 5f) {
					Destroy (rabbit);
					this.sceneDirSC.RabbitNum--;
				}
			}
		}
	}
}
