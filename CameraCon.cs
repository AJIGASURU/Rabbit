using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour {
	public GameObject player;
	private Vector3 cameraPos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.cameraPos = player.transform.position - player.transform.forward*10f;
		transform.position = this.cameraPos;
		transform.rotation = player.transform.rotation;
	}
}