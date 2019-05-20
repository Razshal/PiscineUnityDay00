using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
    private float timer = 0;
    public float maximumTime = 30;

    private float size = 2;
    public float maximumSize = 10;
    public float blowValue = 1;
    public float decreaseValue = 0.04f;

    private float breath = 0;
    public float breathPulse = 2;
    public float maximumBreath = 5;

    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            if (value > maximumTime && Size < maximumSize / 2)
                GameOver();
            timer = value;
        }
    }

    public float Size
    {
        get
        {
            return size;
        }
        set
        {
            if (value > maximumSize || value < 0)
                GameOver();
            else
            {
                size = value;
                gameObject.transform.localScale = new Vector3(size, size, size);
            }
        }
    }

    public float Breath
    {
        get
        {
            return breath;
        }
        set
        {
            if (value < 0)
                breath = 0;
            else
                breath = value;
        }
    }

    void GameOver()
    {
        Debug.Log("Ballon life time: " + Mathf.RoundToInt(timer) + "s");
        Destroy(gameObject);
    }


    void Update()
    {
        Size -= decreaseValue;
        Breath -= decreaseValue * 2.2f;
		Timer += Time.deltaTime;

        if (Input.GetKeyDown("space") && Breath < maximumBreath)
        {
            Size += blowValue;
            breath += breathPulse;
        }
    }
}
