using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
    public float speed = 0.1f;
    public bool passedBird = false;
	public GameObject bird;
    public GameObject[] pipes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject pipe in pipes)
        {
            pipe.transform.Translate(-speed, 0, 0);
            if (pipe.transform.position.x < -10) 
            {
                pipe.transform.position = new Vector3(10, 0.8f, -1);
                if (!passedBird && bird.transform.position.x >= pipe.transform.position.x)
                {
                    speed += 0.01f;
                    passedBird = true;
                }
                else if (bird.transform.position.x <= pipe.transform.position.x)
                    passedBird = false;
            }
        }
	}
}
