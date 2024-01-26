using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public float speed = 15f;
    private Vector2 direction;
    private Logic logic;
    public GameObject object1Prefab;
    public GameObject object2Prefab;
    public GameObject object3Prefab;
    public GameObject object4Prefab;
    public GameObject object5Prefab;
    private bool isCombo = false;
    private bool isPrimed = false;
    private SpriteRenderer spriteRenderer;
    private int bounces = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isCombo)
        {
            spriteRenderer.color = Color.blue;
        }
    }

    public void SetBounces(int bounces)
    {
        this.bounces = bounces;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
        logic = GameObject.Find("Logic").GetComponent<Logic>();
    }

    public void SetIsCombo(bool isCombo)
    {
        this.isCombo = isCombo;
    }

    public void SetIsPrimed(bool isPrimed)
    {
        this.isPrimed = isPrimed;
    }

    void Update()
    {
        // Move the object in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
        if (isCombo ) {
            speed = 14f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BigGoal"))
        {
            logic.addScore(100, isCombo, bounces);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("MedGoal"))
        {
            logic.addScore(50, isCombo, bounces);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("SmallGoal"))
        {
            logic.addScore(25, isCombo, bounces);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Target"))
        {
            // Create objects upon hitting the target
            if (isPrimed || bounces >= 4)
            {
                CreateMoreObjects();

            }
            else
            {
                CreateObjects();
            }

            // Destroy the target and the projectile
            if (!collision.gameObject.GetComponent<Target>().isFrozen) { 
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("TopWall") || collision.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("MoveWall"))
        {
            if (!isCombo)
            {
                Destroy(gameObject);
            }
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
        object1.GetComponent<Scorer>().SetDirection(direction);
        object1.GetComponent<Scorer>().SetIsPrimed(true);
        object1.GetComponent<Scorer>().SetBounces(bounces);
        object2.GetComponent<Scorer>().SetDirection(new Vector2(-direction.y, direction.x)); // Rotate 90 degrees
        object2.GetComponent<Scorer>().SetIsPrimed(true);
        object2.GetComponent<Scorer>().SetBounces(bounces);
        object3.GetComponent<Scorer>().SetIsPrimed(true);
        object3.GetComponent<Scorer>().SetBounces(bounces);
        object3.GetComponent<Scorer>().SetDirection(new Vector2(direction.y, -direction.x)); // Rotate -90 degrees
    }

    void CreateMoreObjects()
    {
        GameObject object1 = Instantiate(object1Prefab, transform.position, Quaternion.identity);
        GameObject object2 = Instantiate(object2Prefab, transform.position, Quaternion.identity);
        GameObject object3 = Instantiate(object3Prefab, transform.position, Quaternion.identity);
        GameObject object4 = Instantiate(object3Prefab, transform.position, Quaternion.identity);

        object1.GetComponent<Scorer>().SetDirection(direction);
        object1.GetComponent<Scorer>().SetIsCombo(true);
        object1.GetComponent<Scorer>().SetBounces(bounces);
        //float angleInRadians = 45f * Mathf.Deg2Rad; // Convert degrees to radians
        //float cosTheta = Mathf.Cos(angleInRadians);
        //float sinTheta = Mathf.Sin(angleInRadians);

        //float rotatedX = direction.x * cosTheta - direction.y * sinTheta;
        //float rotatedY = direction.x * sinTheta + direction.y * cosTheta;

        //Vector2 rotatedDirection = new Vector2(rotatedX, rotatedY);
        object4.GetComponent<Scorer>().SetDirection(-direction);
        object4.GetComponent<Scorer>().SetBounces(bounces);
        object4.GetComponent<Scorer>().SetIsCombo(true);
        //angleInRadians = -45f * Mathf.Deg2Rad;
        //cosTheta = Mathf.Cos(angleInRadians);
        //sinTheta = Mathf.Sin(angleInRadians);
        //rotatedX = direction.x * cosTheta - direction.y * sinTheta;
        //rotatedY = direction.x * sinTheta + direction.y * cosTheta;
        //rotatedDirection = new Vector2(rotatedX, rotatedY);
        //object5.GetComponent<Scorer>().SetDirection(rotatedDirection);
        //object5.GetComponent<Scorer>().SetIsCombo(true);
        object2.GetComponent<Scorer>().SetDirection(new Vector2(-direction.y, direction.x)); // Rotate 90 degrees
        object2.GetComponent<Scorer>().SetIsCombo(true);
        object2.GetComponent<Scorer>().SetBounces(bounces);
        object3.GetComponent<Scorer>().SetDirection(new Vector2(direction.y, -direction.x)); // Rotate -90 degrees
        object3.GetComponent<Scorer>().SetIsCombo(true);
        object3.GetComponent<Scorer>().SetBounces(bounces);
    }
}