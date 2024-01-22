using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Logic : MonoBehaviour
{
    private Vector2 location;
    private float timer = 5;
    private float counter = 0;
    public GameObject target;

    private void SetLocation()
    {
        location.x = Random.Range(-5, 5);
        location.y = Random.Range(-5, 5);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetLocation();
        MakeTargets();
    }

    // Update is called once per frame
    void Update()
    {
        counter += 1 * Time.deltaTime;
        if (counter > timer)
        {
            counter = 0;
            SetLocation();
            MakeTargets();
        }
    }

    private void MakeTargets()
    {
        Instantiate(target, location, transform.rotation);
    }
}
