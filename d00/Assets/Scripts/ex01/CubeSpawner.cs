using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    public GameObject keyPrefab;
    public float timer = 0;
    public float spawnTimer = 3;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            Instantiate(keyPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            timer = 0;
        }
    }
}
