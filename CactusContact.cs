using UnityEngine;
using System.Collections;

public class CactusContact : MonoBehaviour {

    private new AudioSource audio;
    private PlayerHealth playerHealth;
    public float damage;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
            playerHealth.AddFruitValue(damage);
        }
       
    }
}
