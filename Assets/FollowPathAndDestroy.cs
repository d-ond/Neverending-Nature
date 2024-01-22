using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathAndDestroy : MonoBehaviour
{
    public float speed = 15f;
    private Vector2 direction;

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        // Move the object in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Add Score: 1");
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("TopWall"))
            Destroy(gameObject);
    }
}