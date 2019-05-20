using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public float flapForce = 0.05f;
    public float deceleration = 0.1f;
    public float time = 0;
    public Pipe pipe;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (pipe.gameOn)
        {
            time -= Time.deltaTime;
            if (time > 0)
                transform.Translate(0, flapForce, 0);
            else if (Input.GetKeyDown(KeyCode.Space))
                time = 0.5f;
            else
                transform.Translate(0, -deceleration, 0);
        }
	}
}
