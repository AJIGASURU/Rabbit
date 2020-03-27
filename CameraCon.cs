using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour {
	public GameObject player;
	private Vector3 cameraPos;
    private float offset;

	// Use this for initialization
	void Start () {
        this.offset = 80f;
	}
	
	// Update is called once per frame
	void Update () {
        if(offset>12f){
            offset = offset - 1.0f;
        }
		this.cameraPos = player.transform.position - player.transform.forward*offset;
		transform.position = this.cameraPos;
		transform.rotation = player.transform.rotation;
	}
}