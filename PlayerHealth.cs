using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private HealthBar healthBar;
    private PlayerController playerController;
    private float currentHealth;
    public bool isDead = false;
    public float maxValue;
    private AudioSource deathAudio;

	void Start () {
        deathAudio = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        currentHealth = maxValue;
        Component[] components = GetComponentsInChildren<Image>();
        healthBar = GameObject.FindGameObjectWithTag("Health bar").GetComponent<HealthBar>();
        healthBar.MaxValue = maxValue;
        healthBar.Init();
        playerController= GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            Debug.Log("Nigga you dead");
            deathAudio.Play();
            FindObjectOfType<GameManager>().RestartGame();
        }

        if (playerController.transform.position.y <= -8.840001)
        {
            AddFruitValue(-0.25f);
        }
	}

    public void AddFruitValue(float fruitValue)
    {
        if(!isDead && (currentHealth + fruitValue) <= maxValue)
        {
            currentHealth += fruitValue;
            healthBar.CurValue = currentHealth;
            if (currentHealth <= 0)
            {
                isDead = true;
                //deathAudio.Play();
                return;
            }
           
        }
    }

    // TODO Resets health values upon death.
    public void ResetHealth()
    {
        currentHealth = maxValue;
    }
}
