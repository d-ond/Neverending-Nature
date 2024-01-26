using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private float topBound = 2f;
    private float botBound = -1f;
    private float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > topBound || transform.position.y < botBound)
        {
            speed *= -1f;
        }
    }
}
