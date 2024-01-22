using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 10f;
    public Vector2 direction;
    private float angle;
    private float x;
    private float y;
    public PlayerController controller;
    public GameObject scorer;

    public GameObject object1Prefab;
    public GameObject object2Prefab;
    public GameObject object3Prefab;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - transform.position;
        angle = Vector2.SignedAngle(Vector2.right, direction);
        if (angle < 20 && angle >= -90)
        {
            angle = 20;
        }
        if (angle < -90 || angle > 160)
        {
            angle = 160;
        }
        setAngle(angle);
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        direction = new Vector2(x, y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void setAngle(float angle)
    {
        this.angle = angle;
        x = Mathf.Cos(this.angle * Mathf.Deg2Rad);
        y = Mathf.Sin(this.angle * Mathf.Deg2Rad);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopWall"))
        {
            direction.y *= -1;
        }
        else if (collision.gameObject.CompareTag("Death"))
        {
            controller.isBulletActive = false;
            Destroy(gameObject);
        }
        else
        {
            direction.x *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            // Create objects upon hitting the target
            CreateObjects();

            // Destroy the target and the projectile
            controller.isBulletActive = false;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void CreateObjects()
    {
        // Instantiate Object1Prefab
        GameObject object1 = Instantiate(object1Prefab, transform.position, Quaternion.identity);

        // Instantiate Object2Prefab
        GameObject object2 = Instantiate(object2Prefab, transform.position, Quaternion.identity);

        // Instantiate Object3Prefab
        GameObject object3 = Instantiate(object3Prefab, transform.position, Quaternion.identity);

        // Set the directions for the new objects
        object1.GetComponent<FollowPathAndDestroy>().SetDirection(direction);
        object2.GetComponent<FollowPathAndDestroy>().SetDirection(new Vector2(-direction.y, direction.x)); // Rotate 90 degrees
        object3.GetComponent<FollowPathAndDestroy>().SetDirection(new Vector2(direction.y, -direction.x)); // Rotate -90 degrees
    }
}
