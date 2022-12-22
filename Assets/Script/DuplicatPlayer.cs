using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatPlayer : MonoBehaviour
{
    public float speedMove, xMin, xMax;
    float direction = 1;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (transform.position.x < xMin)
        {
            direction = 1;
        }

        else if (transform.position.x > xMax)
        {
            direction = -1;
        }
        transform.Translate(Vector3.right * speedMove * direction * Time.deltaTime);
    }
}
