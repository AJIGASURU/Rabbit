using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {
    private GameObject player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("front01");
	}
	
	// Update is called once per frame
	void Update () {
        Rot();
	}

    private void Rot(){
        Vector3 tmpAngle = transform.localEulerAngles;
        tmpAngle.y = this.player.transform.localEulerAngles.y;
        transform.localEulerAngles = tmpAngle;
    }
}
