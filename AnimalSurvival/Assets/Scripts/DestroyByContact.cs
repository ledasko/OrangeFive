﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private PlayerController playerController;
    private ScoreManager scoreManager;
    public int scoreValue;
    public float fruitValue;
    public GameObject DestructionPoint;
    private new AudioSource audio;

    void Start()
    {
        audio = GameObject.Find("FruitSound").GetComponent<AudioSource>();
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
        DestructionPoint = GameObject.Find("DestructionPoint");
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (fruitValue > 0 && other.tag == "Player")
        {
            audio.Play();
        }
        PlayerHealth playerHealth = playerController.GetComponent<PlayerHealth>();
        playerHealth.AddFruitValue(fruitValue);
        scoreManager.AddScore(scoreValue);
        gameObject.SetActive(false);
       
    }

    void Update()
    {
        if (transform.position.x < DestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
