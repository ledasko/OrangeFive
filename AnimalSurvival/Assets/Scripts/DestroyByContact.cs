using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private PlayerController playerController;
    private ScoreManager scoreManager;
    public int scoreValue;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if(playerControllerObject == null)
        {
            Debug.Log("error");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        scoreManager.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
