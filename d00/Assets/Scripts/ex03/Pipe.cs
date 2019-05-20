using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	public GameObject bird;
	public GameObject[] pipes;
	private float time;
    public float speed = 0.1f;
    public int score = 0;
    private bool gameOn = true;

    // Use this for initialization
    void Start () {
        
    }

    void GameOver() {
        gameOn = false;

    }
    
    // Update is called once per frame
    void Update () {
        if (gameOn)
        {
            foreach (GameObject pipe in pipes)
            {
                pipe.transform.Translate(-speed, 0, 0);
                if (pipe.transform.position.x < -10)
                {
                    pipe.transform.position = new Vector3(10, 0.8f, -1);
                    if (bird.transform.position.x >= pipe.transform.position.x 
                        && bird.transform.position.x <= pipe.transform.position.x)
                    {
                        speed += 0.01f;
                        score += 5;
                    }
                }
                if ((bird.transform.position.y < -0.8 || bird.transform.position.y > 2)
                    && bird.transform.position.x > pipe.transform.position.x - 0.5 
                    && bird.transform.position.x < pipe.transform.position.x + 0.5)
                {
                    GameOver();
                }

            }
        }
    }
}
