using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour {
	public GameObject Player;
	private Vector3 CameraPos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.CameraPos = Player.transform.position - Player.transform.forward*10f;
		transform.position = this.CameraPos;
		transform.rotation = Player.transform.rotation;
	}
}
