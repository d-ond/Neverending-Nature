using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody2D rb;
    public GameObject bullet;
    public GameObject cursor;
    public Boolean isBulletActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        rb.transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            if (!isBulletActive ) { 
                Instantiate(bullet, cursor.transform.position, cursor.transform.rotation);
                isBulletActive = true;
            }
            
        }
    }
}
