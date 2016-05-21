using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {
    public string desertLevel;
    public string forestLevel;
    public string mainMenu;
    
    // Loads desert scene.
    public void PlayDesert()
    {
        SceneManager.LoadScene(desertLevel);
    }

    // Loads forest scene.
    public void PlayForest()
    {
        SceneManager.LoadScene(forestLevel);
    }

    // Goes back to the main menu.
    public void BackToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
