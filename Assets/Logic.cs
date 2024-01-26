using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;


public class Logic : MonoBehaviour
{
    public enum GamePhase
    {
        BEGIN,
        END
    }
    public AudioSource small;
    public AudioSource med;
    public AudioSource big;

    private static int gameLength = 60;
    public float timerLength;
    private int endTimePhase = (gameLength / 4);
    private Vector2 location;
    private float timer = 2;
    private float counter = 0;
    public GameObject target;
    private int score = 0;
    public Text scoreDisplay;
    public Text timerDisplay;
    private float numTargets = 2;

    // Start is called before the first frame update
    void Start()
    {
        location.x = Random.Range(-4.75f, 4.75f);
        location.y = Random.Range(1.25f, 3f);
        MakeTargets();
        timerLength = (float) gameLength;
    }



    // Update is called once per frame
    void Update()
    {
        counter += 1 * Time.deltaTime;
        timerLength -= 1 * Time.deltaTime;
        if (counter > timer)
        {
            counter = 0;
            MakeTargets();
        }
        scoreDisplay.text = score.ToString();
        timerDisplay.text = ((int) timerLength).ToString();

        if (timerLength <= endTimePhase)
        {
            timer = 1.5f;
        }

        if (timerLength <= 0)
        {
            EndGame();
        }
    }

    private void MakeTargets()
    {
        for (int i = 0; i < numTargets; i++)
        {
            location.x = Random.Range(-4.75f, 4.75f);
            location.y = Random.Range(1.25f, 3f);
            Instantiate(target, location, transform.rotation);
        }
    }

    public void addScore(int amount, bool combo, int bounces)
    {
        int scoreToAdd = 0;
        if (!combo)
        {
            scoreToAdd = (int) (amount * Mathf.Pow(1.1f, bounces));
        }
        else
        {
            scoreToAdd = (int) (amount * Mathf.Pow(1.1f, bounces)) * 2;
        }
        if (scoreToAdd >= 25)
        {
            small.Play();
        }
        else if (scoreToAdd > 100) 
        {
            med.Play();
        }
        else if (scoreToAdd >= 100)
        {
            big.Play();
        }
        score += scoreToAdd;
    }

    void EndGame()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        SceneManager.LoadScene("EndScreen");
    }
}
