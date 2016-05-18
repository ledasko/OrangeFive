using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public GUIText scoreText;
    public GUIText highScoreText;

    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;

    public bool scoreIncrease;

    // Use this for initialization
    void Start()
    {
        if(PlayerPrefs.HasKey("Highscore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("Highscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncrease)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "Highscore: " + Mathf.Round(scoreCount);
    }

    public void AddScore(int value)
    {
        scoreCount += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    void UpdateHighScore()
    {
        highScoreText.text = "Highscore: " + highScoreText.ToString();
    }
}
