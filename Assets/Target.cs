using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool targetActive = false;
    private int hangTime = 10;
    private float counter = 0;
    private float grav;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    private float xDir;
    public bool isFrozen = false;
    private float timeFrozen = 4;
    private float frozenCounter = 0;

    private void HangTime()
    {
        while (counter < hangTime)
        {
            spriteRenderer.color = Color.yellow;
            targetActive = false;
            counter += 1 * Time.deltaTime;
        }
        targetActive = true;
    }
    // Start is called before the first frame update
    void Awake()
    {
        xDir = Random.Range(-0.5f, 0.5f);
        targetActive = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        grav = Random.Range(0.0001f, 0.0006f);
        HangTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetActive)
        {
            if (!isFrozen)
            {
                spriteRenderer.color = Color.green;
                float downMove = -0.8f;
                downMove += grav;
                direction = new Vector2(xDir, downMove);
                transform.Translate(direction * Time.deltaTime);
            }
            else
            {
                direction = Vector2.zero;
                frozenCounter += Time.deltaTime * 1;
                if (frozenCounter >= timeFrozen)
                {
                    frozenCounter = 0;
                    isFrozen = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scorer"))
        {
            if (isFrozen)
            {
                collision.gameObject.GetComponent<Scorer>().SetIsPrimed(true);
            }
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
    }
}
