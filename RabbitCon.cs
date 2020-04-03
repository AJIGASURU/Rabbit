using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitCon : MonoBehaviour {
	public GameObject rabbitPosPrefab;
	public GameObject rabbitPos; //箱
	public Vector3 toPlayerDirection;

	private GameObject player;
	private float speed;
	private float theta;
	private SceneDir sceneDirSC;
	private float timer;
	private Material material;
	// Use this for initialization
	void Start () {
		this.speed = 0.1f;
		this.theta = 0f;
		this.timer = 0f;
		this.sceneDirSC = GameObject.Find ("SceneDirector").GetComponent<SceneDir> ();
		this.player = GameObject.Find ("front01");
		this.rabbitPos = Instantiate (rabbitPosPrefab);
		this.material = transform.GetChild (1).gameObject.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		this.toPlayerDirection = player.transform.position - transform.position;
		this.toPlayerDirection.y = 0; //グラウンドの法線方向

		if (timer < 5f) { //出現時
			this.timer += Time.deltaTime;
			this.material.SetFloat ("_Alpha", timer / 5f);
            //一度しか通る必要はないが・・・初期化で削除されるようにこの位置
            this.rabbitPos.transform.SetParent(GameObject.Find("UICanvas/Map").transform, false);
        } else {
			this.theta = this.theta + 0.08f;
			Move ();
		}

        RabbitIconControl();

        if (gameObject.GetComponent<Rigidbody>().velocity.y > 1f){//飛んじゃうバグの修正？怪しい。
            gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up);
        }
	}

	void OnCollisionEnter (Collision other){//ゲームオーバー
		if (other.gameObject.tag == "Player" && timer >= 4.9f) {
			this.sceneDirSC.gameOver = true;
		}
	}

	void Move(){
		Vector3 tmpPos;
		transform.forward = -this.toPlayerDirection; //z軸が尻尾の方

		tmpPos = transform.position;
		tmpPos -= transform.forward * speed;
		transform.position = tmpPos;
	}

    void RabbitIconControl() //マッピング
    {
        rabbitPos.GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RabbitCon>().toPlayerDirection.x*2.0f, GetComponent<RabbitCon>().toPlayerDirection.z*2.0f);
        float Alpha = Mathf.Max(255f - GetComponent<RabbitCon>().toPlayerDirection.magnitude, 1f);
        rabbitPos.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, Alpha / 255f);
    }
}
