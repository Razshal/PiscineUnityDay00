using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    public GameObject[] cubes;
    public GameObject[] lines;
    public float timer = 0;
    public float spawnTimer = 1;
    public int cubeNumber = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTimer)
        {
            cubeNumber = Random.Range(0, cubes.Length);
            Instantiate(cubes[cubeNumber], 
                        new Vector2(lines[cubeNumber].transform.position.x, 4), 
                        lines[cubeNumber].transform.rotation);
            timer = 0;
        }
    }
}
