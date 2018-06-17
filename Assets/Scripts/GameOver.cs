using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private float delay = 5;
    private float curTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        curTime += Time.deltaTime;

        if (Input.anyKeyDown && curTime >= delay)
            SceneManager.LoadScene("Level1");
	}
}
