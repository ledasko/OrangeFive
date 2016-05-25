using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Util : MonoBehaviour {

    //private float volumeStore=0;
    
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject aboutMenu;
    public GameObject soundOn;
    public GameObject soundOff;
    private float startSpeed;
    private float speedIncrease;
    public Slider startSpeedSlider;
    public Slider speedIncreaseSlider;


    void Awake()
    {
        startSpeed = PlayerPrefs.GetFloat("moveSpeed");
        startSpeedSlider.value = startSpeed;
        speedIncrease = PlayerPrefs.GetFloat("speedMultiplier");
        speedIncreaseSlider.value = speedIncrease;

    }

	// Use this for initialization
	void Start () {
        
        soundOn.SetActive(AudioListener.pause);
        soundOff.SetActive(!AudioListener.pause);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
     public void setMoveSpeed(float speed)
        {
            startSpeed = speed;
            PlayerPrefs.SetFloat("moveSpeed", startSpeed);
            
        }

    public void setSpeedIncrease(float speed)
    {
        speedIncrease = speed;
        PlayerPrefs.SetFloat("speedMultiplier", speedIncrease);
    }
    
    public void SoundOff() {
        AudioListener.pause = true;
        soundOn.SetActive(true);
        soundOff.SetActive(false);
    
    }
    
    public void SoundOn() {
        AudioListener.pause = false;        
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }
    
    
    public void activateMainMenu() {
        optionsMenu.SetActive(false);
        aboutMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    public void activateOptionsMenu() {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    
    public void activateAboutMenu() {
        aboutMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}


