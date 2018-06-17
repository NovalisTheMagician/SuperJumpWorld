using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private Vector2 startPos;

	void Start ()
    {
        startPos = this.transform.position;
	}
	
	void Update ()
    {
        this.transform.position = startPos + new Vector2(0, Mathf.Sin(Time.frameCount * 0.05f) * 0.09f);
	}
}
