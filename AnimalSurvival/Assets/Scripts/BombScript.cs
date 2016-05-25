using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

    public string audioSourceName;
    private AudioSource audio;
    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start () {
        audio = GameObject.Find(audioSourceName).GetComponent<AudioSource>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) { 
        if (other.tag == "Player")
        {
         audio.Play();
        }
    }
}
