using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public GameObject pipe1;
    public GameObject pipe2;
    public float flapForce = 3;
    public float deceleration = 0.005f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, flapForce, 0);
        }
        transform.Translate(0, -deceleration, 0);
	}
}
