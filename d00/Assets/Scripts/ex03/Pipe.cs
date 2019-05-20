using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject bird;
    public GameObject[] pipes;
    public bool[] birdPassed;
	private float time;
    public float speed = 0.1f;
    public int score = 0;
    public bool gameOn = true;

    void GameOver() {
        gameOn = false;
        Debug.Log("Score: " + score + "\nTime: " + Mathf.RoundToInt(time) + "s");
    }

    bool IsInPipe(GameObject pipe)
    {
        return bird.transform.position.x > pipe.transform.position.x - 0.5f
                   && bird.transform.position.x < pipe.transform.position.x + 0.5f;
    }

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (gameOn)
        {
            for (int count = 0; count < 2; count++)
            {
                pipes[count].transform.Translate(-speed, 0, 0);
                if (pipes[count].transform.position.x < -10)
                    pipes[count].transform.position = new Vector3(10, 0.8f, -1);

                if (!birdPassed[count] && bird.transform.position.x >= pipes[count].transform.position.x)
                {
                    speed += 0.01f;
                    score += 5;
                    birdPassed[count] = true;
                }
                if (bird.transform.position.x <= pipes[count].transform.position.x)
                    birdPassed[count] = false;

                if ((bird.transform.position.y < -0.8f || bird.transform.position.y > 2) 
                    && IsInPipe(pipes[count]))
                    GameOver();
            }
        }
    }
}
