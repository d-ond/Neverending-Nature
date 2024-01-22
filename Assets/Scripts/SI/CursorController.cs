using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    float angle;
    float timer = 1;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        counter += 1 * Time.deltaTime;
        if (counter > timer)
        {
            counter = 0;
            angle = Random.Range(0, 360);
        }
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
