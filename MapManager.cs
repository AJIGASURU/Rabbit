using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour { //mapにつけよう。簡単だけど遅い設計で。
                                          //public GameObject rabbitPosPrefab; //Map用（RPosPrefab（黒い点））
    private GameObject playerPos;
	private GameObject player;
	private GameObject[] rabbits;
	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("front01");
        this.playerPos = GameObject.Find("UICanvas/Map/playerPos");
	}
	
	// Update is called once per frame
	void Update () {
		rabbits = GameObject.FindGameObjectsWithTag("rabbit");
		foreach (GameObject rabbit in rabbits) {
			GameObject rabbitPos = rabbit.GetComponent<RabbitCon> ().rabbitPos;
			if (rabbitPos != null) {
				rabbitPos.GetComponent<RectTransform> ().localPosition = new Vector2 (rabbit.GetComponent<RabbitCon> ().toPlayerDirection.x, rabbit.GetComponent<RabbitCon> ().toPlayerDirection.z);
                float Alpha = Mathf.Max(255f-rabbit.GetComponent<RabbitCon>().toPlayerDirection.magnitude, 1f);
                rabbitPos.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, Alpha / 255f);
			}
		}
        Vector3 playerPosAngle = this.playerPos.transform.localEulerAngles;
        playerPosAngle.z = -this.player.transform.localEulerAngles.y;
        this.playerPos.transform.localEulerAngles = playerPosAngle;
	}
}


