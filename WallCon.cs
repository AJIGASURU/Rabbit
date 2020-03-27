using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCon : MonoBehaviour { //壁の制御、シェーダとのやりとり
	private Material material;
	private GameObject cam;
	private float dist;

	// Use this for initialization
	void Start () {
		this.material = gameObject.GetComponent<Renderer> ().material;
		this.cam = GameObject.Find ("Main Camera");
	}

	// Update is called once per frame
	void Update () {
		this.dist = Mathf.Abs((cam.transform.position - transform.position).magnitude);
		if (this.dist < 30f) {
			this.material.SetColor ("_inColor", new Color (1.0f, 1.0f, 1.0f, this.dist/30f));
			this.material.SetColor ("_outColor", new Color (0f, 0f, 0f, this.dist/30f));
		}
	}
}
