using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float movespeed = 10f;
    public GameObject straight;
    private Vector3 direction = Vector3.up;

    public void setDirection(float xDir, float yDir)
    {
        direction.x = xDir;
        direction.y = yDir;
        direction.z = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(straight, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        straight.transform.Translate(Vector3.up * movespeed * Time.deltaTime);
    }
}
