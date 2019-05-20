using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private float speed;
    private float lifeTime = 3;
    public string key = "a";
    public GameObject downLine;

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            Destroy(gameObject);
        gameObject.transform.Translate(0, -speed, 0);
        if (Input.GetKeyDown(key))
        {
            Debug.Log("Precision: " + (gameObject.transform.position.y - downLine.transform.position.y));
            Destroy(gameObject);
        }
    }
}
