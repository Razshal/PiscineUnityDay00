using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject club;
    public GameObject hole;
    public float acceleration;
    private float force;
    private Vector3 startingPoint;
    public float deceleration = 0.01f;
    public float forceIncrese = 0.01f;
    public float maxForce = 1.2f;
    private bool touchedWall = false;
    private bool pressedSpace = false;
    private int score = -15;

    private bool IsAccelerationNull()
    {
        return acceleration <= 0;
    }

    private bool CanEnterInTheHole()
    {
        if (gameObject.transform.position.y > (hole.transform.position.y - 0.5f)
            && gameObject.transform.position.y < (hole.transform.position.y + 0.5f)
            && acceleration < 0.1f)
            return true;
        return false;
    }

    private void MoveClub()
    {
        club.gameObject.transform.position
            = new Vector3(gameObject.transform.position.x - 0.2f,
                          gameObject.transform.position.y - 0.3f,
                          gameObject.transform.position.z);
    }

    void Update()
    {
        if (!CanEnterInTheHole())
        {
            // Increasing ball force
            if (IsAccelerationNull())
            {
                if (Input.GetKey("space"))
                {
                    touchedWall = false;
                    pressedSpace = true;
                    startingPoint = gameObject.transform.position;
                    force += forceIncrese;
                }
                else if (!Input.GetKey("space"))
                {
                    acceleration = Mathf.Clamp(force, 0, maxForce);
                    force = 0;
                }
                if (pressedSpace && force <= 0 && acceleration <= 0)
                {
                    Debug.Log("Score: " + (score += 5));
                    pressedSpace = false;
                    MoveClub();
                }
            }
            else
            {
                // Defining ball movement
                if (gameObject.transform.position.y >= 4.6f)
                    touchedWall = true;
                if (gameObject.transform.position.y <= -4.6f)
                    touchedWall = false;
                if (touchedWall || startingPoint.y > hole.gameObject.transform.position.y)
                    gameObject.transform.Translate(0, -acceleration, 0);
                else
                    gameObject.transform.Translate(0, acceleration, 0);

                // Decelerate trough time
                acceleration -= deceleration;
            }
        }
    }
}
