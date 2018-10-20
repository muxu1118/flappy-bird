using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-0.05f, 0, 0);
		if (transform.position.x < -10f ) {
			transform.position = new Vector3 (13f, -0.5f, 0);
		}
	}
}
