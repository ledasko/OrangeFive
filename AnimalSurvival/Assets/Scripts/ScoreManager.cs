using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public string loadedScene;

    public Text scoreText;
    public Text highScoreText;

    public Text deathHighscore;

    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;

    public bool scoreIncrease;

    private float scoreMultiplier;
    private float baseSpeed;
    private PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        loadedScene = SceneManager.GetActiveScene().name;

        deathHighscore.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("Highscore" + loadedScene))
        {
            highScoreCount = PlayerPrefs.GetFloat("Highscore" + loadedScene);
        }

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //baseSpeed = playerController.moveSpeed;
        baseSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        scoreMultiplier = (playerController.moveSpeed - baseSpeed) + playerController.speedMultiplier;
        if (scoreIncrease)
        {
            scoreCount += pointsPerSecond * Time.deltaTime*scoreMultiplier;
        }

        if (scoreCount < 0)
        {
            scoreCount = 0;
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "Highscore: " + Mathf.Round(highScoreCount);
    }

    public void AddScore(int value)
    {
        scoreCount += value;
    }

    public void NewHighscore()
    {
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore" + loadedScene, highScoreCount);
            deathHighscore.gameObject.SetActive(true);
            deathHighscore.text = "Congratulations! Your new highscore: " + Mathf.Round(highScoreCount);
        }
    }
}
