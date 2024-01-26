using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMoverBig : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 direction = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}
